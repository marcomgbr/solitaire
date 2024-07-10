using MMG.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Solitaire
{
    public class StockPile : ACardPile
    {
        WastePile wastePile;

        public StockPile(Control parent, List<Card> cards, WastePile wastePile) : base(parent, cards)
        {
            this.wastePile = wastePile; 
            this.MouseClick += StockPile_MouseClick;

            GameSession.Instance.StockCount = this.cards.Count;
        }

        public override void Add(List<Card> srcCards)
        {
            if (srcCards.Count > 0 && !CanAddToPile(srcCards.First()))
            {
                throw new InvalidOperationException("This card cannot be added to this pile!");
            }

            int lastIndex = srcCards.Count - 1;
            for (int i = lastIndex; i > -1; i--)
            {
                ((Control)srcCards[i]).AllowDrop = false;
                srcCards[i].Pile = this;
                srcCards[i].Location = this.Location;
                srcCards[i].FaceUp = false;
                srcCards[i].BringToFront();


                this.cards.Add(srcCards[i]);
            }

            GameSession.Instance.StockCount = this.cards.Count;
        }

        public override bool CanAddToPile(Card c)
        {
            bool response = true;

            if ( !c.Pile.GetType().Equals(typeof(WastePile)))
            {
                response = false;
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

            GameSession.Instance.StockCount = this.cards.Count;

            return response;
        }

        public void sendToWastePile(Card c)
        {
            this.wastePile.Add(RemoveToEnd(c));
            GameSession.Instance.StockCount = this.cards.Count;
        }

        private void StockPile_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.cards.Count == 0)
            {
                this.Add(this.wastePile.RemoveAllCards());
                this.SendToBack();
                GameSession.Instance.WasteCount = 0;
                GameSession.Instance.StockCount = this.cards.Count;
                GameSession.Instance.Score -= 3;
            }
            else
            {
                throw new InvalidOperationException("It is not allowed to add cards to non-empty stock pile!");
            }
        }
    }
}
