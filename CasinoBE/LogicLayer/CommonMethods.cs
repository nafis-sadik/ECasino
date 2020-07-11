using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public static class CommonMethods
    {
        public static List<Card> Shuffle(List<Card> deck, int factor)
        {
            int range = deck.Count;
            if (factor <= range / 2) { factor = range; }
            var rand = new Random();
            int shuffleCount = rand.Next(range / 2, factor);
            for (int i = 0; i < shuffleCount; i++)
            {
                int firstElementIndex = rand.Next(0, range);
                int secondElementIndex = rand.Next(0, range);
                if (firstElementIndex == secondElementIndex) { secondElementIndex++; }
                var temp = deck[firstElementIndex];
                deck[firstElementIndex] = deck[secondElementIndex];
                deck[secondElementIndex] = temp;
            }
            return deck;
        }
    }
}
