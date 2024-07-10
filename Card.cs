using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MMG.CustomControls;
using Solitaire.Common;

namespace Solitaire
{
    public class Card : PictureBox
    {
        Bitmap frontImageBmp;
        Bitmap backImageBmp;

        public Card(Control parent, string key, int value, string frontImageFile, string backImageFile)
        {
            this.Parent = parent;
            this.Key = key;
            this.Value = value;

            this.frontImageBmp = new Bitmap(frontImageFile);
            this.backImageBmp = new Bitmap(backImageFile);
            this.Image = frontImageBmp;

            Init();
        }

        #region Getters & Setters
        public string Key { get; set; }

        public int Value { get; set; }

        public ACardPile Pile { get; set; }

        public ACardPile BuildPile { get; set; }

        public List<TableauPile> TableauPiles { get; set; }

        Suit suit;
        public Suit Suit
        {
            get
            {
                return this.suit;
            }
            set
            {
                this.suit = value;
                if(this.suit == Suit.Clubs || this.suit == Suit.Spades)
                {
                    this.Color = CardColor.Black;
                }
                else
                {
                    this.Color = CardColor.Red;
                }
            }
        }

        public CardColor Color { get; set; }

        private bool faceUp;
        public bool FaceUp
        {
            get
            {
                return this.faceUp;
            }
            set
            {
                if (!this.faceUp && value) // prevent double event subscription
                {
                    this.Image = this.frontImageBmp;

                    this.DoubleClick += Card_DoubleClick;
                    this.DragEnter += Card_DragEnter;
                    this.DragLeave += Card_DragLeave;
                    this.DragDrop += Card_DragDrop;
                    this.SizeChanged += Card_SizeChanged;
                }
                else if (!value)
                {
                    this.Image = this.backImageBmp;

                    this.DoubleClick -= Card_DoubleClick;
                    this.DragEnter -= Card_DragEnter;
                    this.DragLeave -= Card_DragLeave;
                    this.DragDrop -= Card_DragDrop;
                    this.SizeChanged -= Card_SizeChanged;
                }

                this.faceUp = value;
            }
        }
        #endregion

        private void Init()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BorderStyle = BorderStyle.None;
            this.Width = 120;
            this.Height = 175;

            this.MouseDown += Card_MouseDown;
        }

        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            Card c = (Card)sender;

            if (e.Clicks == 1) // this line of code avoids double click event failure
            {
                if (c.FaceUp)
                {
                    DoDragDrop(c, DragDropEffects.Move);
                }
                else if (c.Pile.GetType().Equals(typeof(StockPile)))
                {
                    ((StockPile)c.Pile).sendToWastePile(c);
                }

                GameSession.Instance.StartTimer();
            }
        }

        private void Card_DoubleClick(object sender, EventArgs e)
        {
            SendToSuitablePile((Card)sender);
        }

        public bool SendToBuildPile()
        {
            bool response = CanAddToBuild();
            if (response)
            {
                ImageTransition transition = new ImageTransition(this, this.BuildPile.Location);
                transition.GoToDestination();
                response = SendToBuild(this.Pile.RemoveToEnd(this));
            }
            return response;
        }

        private void SendToSuitablePile(Card c)
        {
            if (CanAddToBuild())
            {
                ImageTransition transition = new ImageTransition(this, this.BuildPile.Location, 40);
                transition.GoToDestination();
                SendToBuild(this.Pile.RemoveToEnd(c));
            }
            else
            {
                var (canAdd, indexOfPile) = CanAddToTableau();
                if (canAdd)
                {
                    SendToTableau(this.Pile.RemoveToEnd(c), indexOfPile);
                }
            }
        }

        private bool CanAddToBuild()
        {
            if (this.Pile.IsOnPileBottom(this))
            {
                if ( !this.Pile.GetType().Equals(typeof(BuildPile)))
                {
                    if (this.BuildPile.CanAddToPile(this))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool SendToBuild(List<Card> srcCards)
        {
            if (!srcCards.First().Pile.GetType().Equals(typeof(BuildPile)))
            {
                this.BuildPile.Add(srcCards);
                return true;
            }

            return false;
        }

        private (bool canAdd, int indexOfPile) CanAddToTableau()
        {
            foreach (var item in TableauPiles)
            {
                if (item != this.Pile)
                {
                    if (item.CanAddToPile(this))
                    {
                        return (true, TableauPiles.IndexOf(item));
                    }
                }
            }

            return (false, -1);
        }

        private void SendToTableau(List<Card> srcCards, int indexOfPile)
        {
            TableauPiles[indexOfPile].Add(srcCards);
        }

        private void Card_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));

                if (this.Pile.CanAddToPile(srcCard))
                {
                    e.Effect = DragDropEffects.Move;
                    this.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private void Card_DragLeave(object sender, EventArgs e)
        {
           this.BorderStyle = BorderStyle.None;
        }

        private void Card_DragDrop(object sender, DragEventArgs e)
        {
            this.BorderStyle = BorderStyle.None;

            if (e.Data.GetDataPresent(typeof(Card)))
            {
                Card srcCard = (Card)e.Data.GetData(typeof(Card));
                if (this.Pile.CanAddToPile(srcCard))
                {
                    List<Card> cards = srcCard.Pile.RemoveToEnd(srcCard);
                    this.Pile.Add(cards);
                }
            }
        }

        private void Card_SizeChanged(object sender, EventArgs e)
        {
            int joinRadius = (int)(this.Size.Height * 0.04014285714285714285714285714286);
            //this.JoinRadius = joinRadius > 2 ? joinRadius : 2;
        }
    }
}
