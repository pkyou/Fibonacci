using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return y.Number.Value.CompareTo(x.Number.Value);
        }
    }
}