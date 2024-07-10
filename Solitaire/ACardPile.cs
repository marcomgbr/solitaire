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
