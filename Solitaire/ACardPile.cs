using Solitaire.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Solitaire
{
    public abstract class ACardPile : Panel
    {
        protected List<Card> cards;
        public List<ACardPile> TableauPiles { get; set; }
        public Dictionary<Suit, ACardPile> BuildPiles { get; private set; } = new Dictionary<Suit, ACardPile>();

        public ACardPile(Control parent, List<Card> cards)
        {
            this.Width = 1;
            this.Height = 1;

            this.Parent = parent;
            this.cards = cards;
            this.BackColor = System.Drawing.Color.Green;

            foreach (var item in this.cards)
            {
                item.Pile = this;
            }
            
            this.DragLeave += CardPile_DragLeave; this.BorderStyle = BorderStyle.None;
        }

        public void SendToSuitablePile(Card src)
        {
            if (!SendToBuild(src))
            {
                int index = FindASuitableTableau(src);
                if (index > -1)
                {
                    TableauPiles[index].Add(src.Pile.RemoveToEnd(src));
                }
            }
        }

        public bool SendToBuild(Card src)
        {
            bool response = false;
            if (CanAddToBuild(src))
            {
                ImageTransition transition = new ImageTransition(src, BuildPiles[src.Suit].Location, 40);
                transition.GoToDestination();
                BuildPiles[src.Suit].Add(src.Pile.RemoveToEnd(src));
                response = true;
            }
            return response;
        }

        public bool CanAddToBuild(Card src)
        {
            if (src.IsOnPileBottom())
            {
                if (!src.Pile.GetType().Equals(typeof(BuildPile)))
                {
                    if (BuildPiles[src.Suit].CanAddToPile(src))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int FindASuitableTableau(Card src)
        {
            int response = -1;

            for (int i = 0; i < TableauPiles.Count; i++)
            {
                if (TableauPiles[i] != src.Pile)
                {
                    if (TableauPiles[i].CanAddToPile(src))
                    {
                        response = i;
                    }
                }
            }

            return response;
        }

        protected void CardPile_DragLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }

        public void DoLayout(Size cardSize, Point location)
        {
            this.Size = cardSize;
            this.Location = location;
            this.SendToBack();

            foreach (var item in this.cards)
            {
                item.Size = cardSize;
                item.Location = this.Location;
                item.BringToFront();

                ((Control)item).AllowDrop = false;
            }
        }

        public abstract void Add(List<Card> srcCards);

        public abstract bool CanAddToPile(Card c);

        /** Remove all cards starting at <code>first</code>*/
        public abstract List<Card> RemoveToEnd(Card first);

        public List<Card> RemoveAllCards()
        {
            List<Card> response = new List<Card>();

            response.AddRange(this.cards);
            this.cards.Clear();

            return response;
        }

        public bool IsOnPileBottom(Card c)
        {
            return c == this.cards.Last();
        }
        
        public bool IsEmpty()
        {
            return this.cards.Count == 0;
        }
    }
}
