using MMG.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Solitaire
{
    public class TableauPile : ACardPile
    {
        public TableauPile(Control parent, List<Card> cards) : base(parent, cards)
        {
            this.AllowDrop = true;
            this.DragEnter += TableauPile_DragEnter;
            this.DragDrop += TableauPile_DragDrop;
            this.DragLeave += TableauPile_DragLeave;
        }

        public new void DoLayout(Size cardSize, Point pileLocation)
        {
            this.Size = cardSize;
            this.Location = pileLocation;
            this.SendToBack();

            foreach (var item in this.cards)
            {
                item.Location = pileLocation;
                item.Size = cardSize;
                item.BringToFront();

                ((Control)item).AllowDrop = false;

                pileLocation.Y += (int)(cardSize.Height * 0.15);
            }

            if (this.cards.Count > 0)
            {
                ((Control)this.cards.Last()).AllowDrop = true;
                this.cards.Last().FaceUp = true;
            }
        }

        public override void Add(List<Card> srcCards)
        {
            if (!CanAddToPile(srcCards.First()))
            {
                throw new InvalidOperationException("This card cannot be added to this pile!");
            }

            foreach (var item in srcCards)
            {
                ((Control)item).AllowDrop = false;
                item.Pile = this;

                if (this.cards.Count == 0)
                {
                    item.Location = this.Location;
                }
                else
                {
                    item.Location = this.cards.Last().Location;
                    item.Top += (int)(this.cards.Last().Height * 0.15);
                }
                item.BringToFront();
                this.cards.Add(item);
            }

            if (this.cards.Count > 0)
            {
                ((Control)this.cards.Last()).AllowDrop = true;
            }
        }

        public override bool CanAddToPile(Card c)
        {
            bool response = false;

            if (this.cards.Count == 0)
            {
                if (c.Value == 13)
                {
                    response = true;
                }
            }
            else
            {
                if (this.cards.Last().Color != c.Color)
                {
                    if (this.cards.Last().Value == c.Value + 1)
                    {
                        response = true;
                    }
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
                this.cards.Last().FaceUp = true;
            }

            return response;
        }

        public bool SendTopToBuild()
        {
            bool response = this.cards.Count > 0;
            if(response)
            {
                response = GameSession.Instance.Controller.SendToBuild( this.cards.Last());
            }

            return response;
        }

        private void TableauPile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));
                
                if (srcCard.Value == 13)
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

        private void TableauPile_DragLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        private void TableauPile_DragDrop(object sender, DragEventArgs e)
        {
            this.BorderStyle = BorderStyle.None;

            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));

                if (srcCard.Value == 13)
                {
                    List<Card> cards = srcCard.Pile.RemoveToEnd(srcCard);
                    this.Add(cards);
                }
            }
        }
    }
}
