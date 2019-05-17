using System.Collections.Generic;
using System.Linq;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.WholeCardGenerate
{
    public class WholeCardGeneralGenerator : IWholeCardGenerator
    {
        private readonly List<CardShape> _cardShapes = new List<CardShape>
        {
            new CardShape{DisplayShape = "D",Order = 1},
            new CardShape{DisplayShape = "S",Order = 1},
            new CardShape{DisplayShape = "H",Order = 1},
            new CardShape{DisplayShape = "C",Order = 1}
        };

        private readonly List<CardNumber> _cardNumbers = new List<CardNumber>
        {
            new CardNumber{DisplayNumber = "2",Value = 2},
            new CardNumber{DisplayNumber = "3",Value = 3},
            new CardNumber{DisplayNumber = "4",Value = 4},
            new CardNumber{DisplayNumber = "5",Value = 5},
            new CardNumber{DisplayNumber = "6",Value = 6},
            new CardNumber{DisplayNumber = "7",Value = 7},
            new CardNumber{DisplayNumber = "8",Value = 8},
            new CardNumber{DisplayNumber = "9",Value = 9},
            new CardNumber{DisplayNumber = "T",Value = 10},
            new CardNumber{DisplayNumber = "J",Value = 11},
            new CardNumber{DisplayNumber = "Q",Value = 12},
            new CardNumber{DisplayNumber = "K",Value = 13},
            new CardNumber{DisplayNumber = "A",Value = 14}
        };
        public List<Card> Generate()
        {
            var cards = new List<Card>();
            
            foreach (var t in _cardNumbers)
            {
                cards.AddRange(_cardShapes.Select(t1 => new Card {Shape = t1, Number = t}));
            }

            return cards;
        }
    }
}