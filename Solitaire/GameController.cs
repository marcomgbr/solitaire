using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MMG.Forms;
using Solitaire.Common;

namespace Solitaire
{
    class GameController
    {
        readonly Deck deck;
        StockPile stockPile;
        WastePile wastePile;
        readonly List<TableauPile> tableauPiles = new List<TableauPile>();
        readonly Dictionary<Suit, BuildPile> buildPiles = new Dictionary<Suit, BuildPile>();

        Control parent;

        public GameController(Control parent, string deckImageFilesDir)
        {
            this.parent = parent;
            CreateBuildPiles();
            this.deck = new Deck(parent, deckImageFilesDir);
            CreateRemainingPiles();
        }

        public void CreateBuildPiles()
        {
            buildPiles.Add(Suit.Clubs, new BuildPile(parent, Suit.Clubs));
            buildPiles.Add(Suit.Spades, new BuildPile(parent, Suit.Spades));
            buildPiles.Add(Suit.Diamonds, new BuildPile(parent, Suit.Diamonds));
            buildPiles.Add(Suit.Hearts, new BuildPile(parent, Suit.Hearts));
        }

        public void CreateRemainingPiles()
        {
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(1)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(2)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(3)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(4)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(5)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(6)));
            tableauPiles.Add(new TableauPile(parent, this.deck.DrawCards(7)));

            this.wastePile = new WastePile(parent);
            this.stockPile = new StockPile(parent, this.deck.DrawAllCards(), this.wastePile);
        }

        public void DoLayout(Size cardSize, int horizontalPilesSpacing, Point screenTopLeft)
        {
            int hSpacing = horizontalPilesSpacing;

            this.stockPile.DoLayout(cardSize, screenTopLeft);

            this.wastePile.DoLayout(cardSize, new Point((this.stockPile.Left + this.stockPile.Width + hSpacing), this.stockPile.Top));

            int tableauTop = this.stockPile.Top + this.stockPile.Height + 35;
            tableauPiles[0].DoLayout(cardSize, new Point(this.stockPile.Left,  tableauTop));
            tableauPiles[1].DoLayout(cardSize, new Point((tableauPiles[0].Left + tableauPiles[0].Width + hSpacing), tableauTop));
            tableauPiles[2].DoLayout(cardSize, new Point((tableauPiles[1].Left + tableauPiles[1].Width + hSpacing), tableauTop));
            tableauPiles[3].DoLayout(cardSize, new Point((tableauPiles[2].Left + tableauPiles[2].Width + hSpacing), tableauTop));
            tableauPiles[4].DoLayout(cardSize, new Point((tableauPiles[3].Left + tableauPiles[3].Width + hSpacing), tableauTop));
            tableauPiles[5].DoLayout(cardSize, new Point((tableauPiles[4].Left + tableauPiles[4].Width + hSpacing), tableauTop));
            tableauPiles[6].DoLayout(cardSize, new Point((tableauPiles[5].Left + tableauPiles[5].Width + hSpacing), tableauTop));

            buildPiles[Suit.Clubs]   .DoLayout(cardSize, new Point(tableauPiles[3].Left, this.stockPile.Top));
            buildPiles[Suit.Spades]  .DoLayout(cardSize, new Point(tableauPiles[4].Left, this.stockPile.Top));
            buildPiles[Suit.Diamonds].DoLayout(cardSize, new Point(tableauPiles[5].Left, this.stockPile.Top));
            buildPiles[Suit.Hearts]  .DoLayout(cardSize, new Point(tableauPiles[6].Left, this.stockPile.Top));
        }

        public void SendToSuitablePile(Card src)
        {
            if (!SendToBuild(src))
            {
                int index = FindASuitableTableau(src);
                if (index > -1)
                {
                    tableauPiles[index].Add(src.Pile.RemoveToEnd(src));
                }
            }
        }

        public bool SendToBuild(Card src)
        {
            bool response = false;
            if (CanAddToBuild(src))
            {
                ImageTransition transition = new ImageTransition(src, buildPiles[src.Suit].Location, 40);
                transition.GoToDestination();
                buildPiles[src.Suit].Add(src.Pile.RemoveToEnd(src));
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
                    if (buildPiles[src.Suit].CanAddToPile(src))
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

            for (int i = 0; i < tableauPiles.Count; i++)
            {
                if (tableauPiles[i] != src.Pile)
                {
                    if (tableauPiles[i].CanAddToPile(src))
                    {
                        response = i;
                    }
                }
            }

            return response;
        }

        public void SendAllToBuildPiles()
        {
            bool sentToBuild = false;

            do
            {
                foreach (var item in tableauPiles)
                {
                    sentToBuild = item.SendTopToBuild();
                    if (sentToBuild) break;
                }
            }
            while (sentToBuild);

            while (this.wastePile.SendTopToBuild());
            {
            }
        }

        public void CheckEndOfGame()
        {
            if (IsGameOver())
            {
                GameSession.Instance.StopTimer();

                GameResult result = GameSession.Instance.User.CreateGameResult();
                result.GameDuration = GameSession.Instance.GameDuration;
                result.Score = GameSession.Instance.Score;
                result.Date = DateTime.Now;
                GameSession.Instance.User.AddGameResult(result);

                GameSession.Instance.UserDataFile.Save();   

                MsgBox.Format().p.b.t($"Game Over").eb.ep
                    .p.t($"Score: {result.Score} - Duration: {result.GameDuration:hh\\:mm\\:ss}").ep.Show();

                ScoresForm scoreForm = new ScoresForm();
                scoreForm.ShowDialog();

                this.parent.Enabled = false;
            }
        }

        public bool IsGameOver()
        {
            bool isGameOver = false;

            foreach (var item in buildPiles)
            {
                isGameOver = item.Value.IsSequenceComplete();
                if (!isGameOver) break;
            }

            return isGameOver;
        }
    }
}
