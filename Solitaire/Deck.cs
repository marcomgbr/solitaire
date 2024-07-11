using Solitaire.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace Solitaire
{
    /**
     * A deck of cards
     */
    class Deck
    {
        List<Card> cards = new List<Card>();
         public Deck(Control parent, string cardImageFilesDir)
        {
            try
            {
                var imageFiles = Directory.EnumerateFiles(cardImageFilesDir, "*.png");

                foreach (string item in imageFiles)
                { 
                    string key = item.Substring(cardImageFilesDir.Length + 1, 5);
                    string valueStr = item.Substring(cardImageFilesDir.Length + 4, 2);
                    int value = Int32.Parse(valueStr);

                    Bitmap frontImage = new Bitmap(item);
                    Bitmap backImage = new Bitmap(cardImageFilesDir + @"\xtras\back.png");

                    Card card = new Card(parent, key, value, frontImage, backImage);
                    
                    card.FaceUp = false;

                    string suit = item.Substring(cardImageFilesDir.Length + 1, 3);
                    if (suit.Equals("clb"))
                    {
                        card.Suit = Common.Suit.Clubs;
                    } 
                    else if (suit.Equals("spd"))
                    {
                        card.Suit = Common.Suit.Spades;
                    }
                    else if (suit.Equals("dmn"))
                    {
                        card.Suit = Common.Suit.Diamonds;
                    }
                    else if (suit.Equals("hrt"))
                    {
                        card.Suit = Common.Suit.Hearts;
                    }

                    cards.Add(card);
                }

                Shuffle();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            this.cards = this.cards.OrderBy(x => random.Next()).ToList();
        }

        public List<Card> DrawCards(int count)
        {
            List<Card> response = new List<Card>();

            if (count > cards.Count)
            {
                return response;
            }
            
            response.AddRange(cards.GetRange(0, count));
            cards.RemoveRange(0, count);

            return response;
        }

        public List<Card> DrawAllCards()
        {
            List<Card> response = new List<Card>();

            response.AddRange(cards);
            cards.Clear();

            return response;
        }

        public void Add(List<Card> cards)
        {
            this.cards.AddRange(cards);
        }
    }
}
