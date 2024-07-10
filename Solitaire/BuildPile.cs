using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MMG.CustomControls;
using Solitaire.Common;

namespace Solitaire
{
    /**
     * The pile that will contain a whole suit of cards.
     */
    class BuildPile : ACardPile
    {
        public BuildPile(Control parent, Suit suit) : base(parent, new List<Card>())
        {
            this.suit = suit;
            this.AllowDrop = true;
            this.DragEnter += BuildPanel_DragEnter;
            this.DragDrop += BuildPanel_DragDrop;
        }

        #region Getters & Setters
        Suit suit;
        public Suit CardSuit
        {
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = value;
            }
        }
        #endregion

        public new void DoLayout(Size cardSize, Point pileLocation) 
        {
            base.DoLayout(cardSize, pileLocation);

            if (this.cards.Count > 0)
            {
                ((Control)this.cards.Last()).AllowDrop = true;
            }
        }

        public override void Add(List<Card> srcCards)
        {
            if (!CanAddToPile(srcCards.First()))
            {
                throw new InvalidOperationException("This card cannot be added to this build pile!");
            }

            if (this.cards.Count > 0)
            {
                ((Control)this.cards.Last()).AllowDrop = false;
            }

            srcCards.First().Pile = this;
            srcCards.First().Location = this.Location;
            srcCards.First().BringToFront();
            this.cards.Add(srcCards.First());
  
            ((Control)this.cards.Last()).AllowDrop = true;

            GameSession.Instance.Score += 3;
            GameSession.Instance.Controller.CheckEndOfGame();
        }

        public override bool CanAddToPile(Card c)
        {
            bool response = false;

            if (this.cards.Count == 0 && c.Value == 1 && c.Suit == this.suit)
            {
                response = true;
            }
            else if (this.cards.Count > 0 && c.Suit == this.suit)
            {
                if(this.cards.Last().Value == c.Value -1)
                {
                    response = true;
                }
            }

            return response;
        }

        public override List<Card> RemoveToEnd(Card first)
        {
            List<Card> response = new List<Card>();

            if (this.cards.Count == 0)
            {
                return response;
            }

            int firstIndex = this.cards.IndexOf(first);
            int rangeSize = this.cards.Count - firstIndex;
            response.AddRange(this.cards.GetRange(firstIndex, rangeSize));
            this.cards.RemoveRange(firstIndex, rangeSize);

            if (this.cards.Count > 0)
            {
                ((Control)this.cards.Last()).AllowDrop = true;
            }

            GameSession.Instance.Score -= 5;

            return response;
        }

        private void BuildPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));

                if (srcCard.Value == 1 && srcCard.Suit == this.suit)
                {
                    e.Effect = DragDropEffects.Move;
                    this.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    this.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void BuildPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));

                if (srcCard.Suit == this.suit && srcCard.Value == 1)
                {
                    var cards = srcCard.Pile.RemoveToEnd(srcCard);
                    this.Add(cards);
                }
            }
        }

        public bool IsSequenceComplete()
        {
            bool response = true;

            if (this.cards.Count != 13)
            {
                response = false;
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    if (this.cards[i].Value != (i + 1))
                    {
                        response = false;
                        break;
                    }
                }
            }

            return response;
        }
    }
}
