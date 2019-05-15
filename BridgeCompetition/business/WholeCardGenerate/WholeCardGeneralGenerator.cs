using System.Collections.Generic;
using System.Linq;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.WholeCardGenerate
{
    public class WholeCardGeneralGenerator : IWholeCardGenerator
    {
        private List<CardShape> _cardShapes = new List<CardShape>
        {
            new CardShape{DisplayShape = "D",Order = 1},
            new CardShape{DisplayShape = "S",Order = 1},
            new CardShape{DisplayShape = "H",Order = 1},
            new CardShape{DisplayShape = "C",Order = 1}
        };
        
        List<CardNumber> _cardNumbers = new List<CardNumber>
        {
            new CardNumber{DisplayNumber = "2",value = 2},
            new CardNumber{DisplayNumber = "3",value = 3},
            new CardNumber{DisplayNumber = "4",value = 4},
            new CardNumber{DisplayNumber = "5",value = 5},
            new CardNumber{DisplayNumber = "6",value = 6},
            new CardNumber{DisplayNumber = "7",value = 7},
            new CardNumber{DisplayNumber = "8",value = 8},
            new CardNumber{DisplayNumber = "9",value = 9},
            new CardNumber{DisplayNumber = "T",value = 10},
            new CardNumber{DisplayNumber = "J",value = 11},
            new CardNumber{DisplayNumber = "Q",value = 12},
            new CardNumber{DisplayNumber = "K",value = 13},
            new CardNumber{DisplayNumber = "A",value = 14}
        };
        public List<Card> Generate()
        {
            List<Card> cards = new List<Card>();
            
            foreach (var t in _cardNumbers)
            {
                cards.AddRange(_cardShapes.Select(t1 => new Card {Shape = t1, Number = t}));
            }

            return cards;
        }
    }
}