using System;

namespace BridgeCompetition.Entities
{
    public class Card : IComparable
    {
        public CardShape Shape { get; set; }
        public CardNumber Number { get; set; }
        public int CompareTo(object obj)
        {
            return obj is Card card ? Number.value.CompareTo(card.Number.value) : 1;
        }
    }
}