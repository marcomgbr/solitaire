using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MMG.CustomControls;
using Solitaire.Common;

namespace Solitaire
{
    public class Card : RoundedPictureBox
    {
        Bitmap frontImageBmp;
        Bitmap backImageBmp;
        Cursor cardCursor;

        public Card(Control parent, string key, int value, Bitmap frontImage, Bitmap backImage)
        {
            this.Parent = parent;
            this.Key = key;
            this.Value = value;

            this.frontImageBmp = frontImage;
            this.backImageBmp = backImage;
            this.Image = frontImageBmp;

            Init();
        }

        #region Getters & Setters
        public string Key { get; set; }

        public int Value { get; set; }

        public ACardPile Pile { get; set; }

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

        public bool IsOnPileBottom()
        {
            return this.Pile.IsOnPileBottom(this);
        }
        #endregion

        private void Init()
        {
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BorderStyle = BorderStyle.None;
            this.Width = 120;
            this.Height = 175;

            this.GiveFeedback += Card_GiveFeedback;
            this.MouseDown += Card_MouseDown;
        }

        private void Card_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect.Equals(DragDropEffects.Move))
            {
                Cursor.Current = this.cardCursor;
            }
            else
            {
                Cursor.Current = this.cardCursor;
            }
            e.UseDefaultCursors = false;
        }

        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            Card c = (Card)sender;

            if (e.Clicks == 1) // this line of code avoids double click event failure
            {
                if (c.FaceUp)
                {
                    CreateCursor();
                    DoDragDrop(c, DragDropEffects.Move);
                }
                else if (c.Pile.GetType().Equals(typeof(StockPile)))
                {
                    ((StockPile)c.Pile).sendToWastePile(c);
                }

                GameSession.Instance.StartTimer();
            }
        }

        private void CreateCursor()
        {
            Bitmap bmp = new Bitmap(this.Image);
            bmp = ResizeBitmap(bmp, this.Width/2, this.Height/2);
            this.cardCursor = new Cursor(bmp.GetHicon());
        }

        public Bitmap ResizeBitmap(Bitmap originalBitmap, int newWidth, int newHeight)
        {
            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalBitmap, 0, 0, newWidth, newHeight);
            }
            return resizedBitmap;
        }

        private void Card_DoubleClick(object sender, EventArgs e)
        {
            GameSession.Instance.Controller.SendToSuitablePile((Card)sender);
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
            this.JoinRadius = joinRadius > 2 ? joinRadius : 2;
        }
    }
}
