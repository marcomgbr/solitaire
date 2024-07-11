using MMG.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Solitaire
{
    public class WastePile : ACardPile
    {
        public WastePile(Control parent) : base(parent, new List<Card>())
        {
        }

        public override void Add(List<Card> srcCards)
        {
            if (!CanAddToPile(srcCards.First()))
            {
                throw new InvalidOperationException("This card cannot be added to OpenStock pile!");
            }

            ((Control)srcCards.First()).AllowDrop = false;
            srcCards.First().Pile = this;
            srcCards.First().Location = this.Location;
            srcCards.First().FaceUp = true;
            srcCards.First().BringToFront();

            this.cards.Add(srcCards.First());

            GameSession.Instance.WasteCount = this.cards.Count;
        }

        public override bool CanAddToPile(Card c)
        {
            bool response = true;
            Type t = c.Pile.GetType();
            if ( !c.Pile.GetType().Equals(typeof(StockPile)))
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

            GameSession.Instance.WasteCount = this.cards.Count;

            return response;
        }

        public bool SendTopToBuild()
        {
            bool response = this.cards.Count > 0;
            if (response)
            {
                response = SendToBuild(this.cards.Last());
                //response = GameSession.Instance.Controller.SendToBuild(this.cards.Last());
            }

            return response;
        }
    }
}
