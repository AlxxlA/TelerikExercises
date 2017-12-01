using System;
using System.Collections.Generic;

namespace _2.Cards
{
    class Cards
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            const long fullDeck = 4503599627370495;

            long cards = 0;
            long odd = 0;

            for (int i = 0; i < n; i++)
            {
                long hand = long.Parse(Console.ReadLine());

                cards = hand | cards;
                odd = hand ^ odd;
            }

            if (cards == fullDeck)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }

            var binary = Convert.ToString(odd, 2).PadLeft(52, '0');

            List<string> deck = FillDeck();
            int index = 0;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                {
                    Console.Write("{0} ", deck[index]);
                }
                index++;
            }         
        }

        static List<String> FillDeck()
        {
            string[] colors = new string[] { "c", "d", "h", "s" };
            string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

            List<string> deck = new List<string>(52);

            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < cards.Length; j++)
                {
                    string card = cards[j] + colors[i];
                    deck.Add(card);
                }
            }

            return deck;
        }
    }
}