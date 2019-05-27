using System.Collections.Generic;
using System.Linq;
using BridgeCompetition.business.WholeCardGenerate;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardConvert
{
    public class CardGeneralConverter : ICardConverter
    {
        private readonly List<Card> _wholeCards;

        private List<int> _comparingValues;

        public CardGeneralConverter(IWholeCardGenerator wholeCardGenerator)
        {
            _wholeCards = wholeCardGenerator.Generate();
        }

        public Card Convert(string cardDescription)
        {
            var descriptionStrs = cardDescription.ToCharArray();
            if (descriptionStrs.Length != 2)
            {
                return null;
            }

            return _wholeCards.FirstOrDefault(x =>
                x.Number.DisplayNumber.Equals(descriptionStrs[0].ToString()) &&
                x.Shape.DisplayShape.Equals(descriptionStrs[1].ToString()));
        }

        public List<Card> ConvertToList(string cardDescription)
        {
            var cardStrs = cardDescription.Split(" ");
            if (cardStrs == null || cardStrs.Length != 5)
            {
                return null;
            }

            List<Card> cards = new List<Card>();
            foreach (var cardStr in cardStrs)
            {
                var card = Convert(cardStr);
                if (card == null)
                {
                    return null;
                }

                cards.Add(card);
            }

            cards.Sort(new CardComparer());

            return cards;
        }
        
        public CardsInHand ConvertToCardsInHand(string cardDescription)
        {
            var cards = ConvertToList(cardDescription);

            return cards == null ? null : GetType(cards);
        }

        private CardsInHand GetType(List<Card> cards)
        {
            var distinctValues = cards.Select(x => x.Number.Value).Distinct().ToList();

            if (distinctValues.Count == 2)
            {
                return GetTwoDistinctValueCardsInHand(cards);
            }

            if (distinctValues.Count == 3)
            {
                return GetThreeDistinctValueCardsInHand(cards);
            }

            if (distinctValues.Count == 4)
            {
                return GetFourDistinctValueCardsInHand(cards);
            }

            if (distinctValues.Count == 5)
            {
                return GetFiveDistinctValueCardsInHand(cards);
            }

            return null;
        }
        
        private CardsInHand GetFiveDistinctValueCardsInHand(List<Card> cards)
        {
            var comparingValues = new List<int>();
            var distinctValues = cards.Select(x => x.Number.Value).Distinct().ToList();
            
            if (IsTongHuaShun(cards))
            {
                comparingValues.Add(distinctValues[0]);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetTongHuaShunType()};
            }

            if (IsTongHua(cards))
            {
                comparingValues.AddRange(distinctValues);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetTongHuaType()};
            }

            if (IsShunZi(cards))
            {
                comparingValues.Add(distinctValues[0]);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetShunZiType()};
            }

            comparingValues.AddRange(distinctValues);
            return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetSanPaiType()};
        }

        private CardsInHand GetFourDistinctValueCardsInHand(List<Card> cards)
        {
            var comparingValues = new List<int>();
            var distinctValues = cards.Select(x => x.Number.Value).Distinct().ToList();
            foreach (var value in distinctValues)
            {
                if (cards.FindAll(x=>x.Number.Value == value).Count == 2)
                {
                    comparingValues.Add(value);
                }
            }

            distinctValues.Remove(comparingValues[0]);
            comparingValues.AddRange(distinctValues);
                
            return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetDuiZiType()};
        }
        
        private CardsInHand GetThreeDistinctValueCardsInHand(List<Card> cards)
        {
            var comparingValues = new List<int>();
            var list = cards.FindAll(x => x.Number.Value == cards[0].Number.Value);
            if (list.Count == 1)
            {
                if (cards.FindAll(x => x.Number.Value == cards[1].Number.Value).Count == 1)
                {
                    comparingValues.Add(cards[2].Number.Value);
                    return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetSanTiaoType()};
                }
                    
                if (cards.FindAll(x => x.Number.Value == cards[1].Number.Value).Count == 3)
                {
                    comparingValues.Add(cards[1].Number.Value); 
                    return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetSanTiaoType()};
                }
            }

            if (list.Count == 3)
            {
                comparingValues.Add(cards[0].Number.Value);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetSanTiaoType()};
            }

            comparingValues.AddRange(cards.Select(x => x.Number.Value).Distinct().ToList());
            return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetLiangDuiType()};
        }

        private CardsInHand GetTwoDistinctValueCardsInHand(List<Card> cards)
        {
            var list = cards.FindAll(x => x.Number.Value == cards[0].Number.Value);
            var comparingValues = new List<int>();
                
            if (list.Count == 1)
            {
                comparingValues.Add(cards[1].Number.Value);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetTieZhiType()};
            }

            if (list.Count == 2)
            {
                comparingValues.Add(cards[1].Number.Value);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetHuLuType()};
            }

            if (list.Count == 3)
            {
                comparingValues.Add(cards[0].Number.Value);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetHuLuType()};
            }

            if (list.Count == 4)
            {
                comparingValues.Add(cards[0].Number.Value);
                return new CardsInHand{ComparingValues = comparingValues,Type = CardsInHandTypeFactory.GetTieZhiType()};
            }

            return null;
        }

        private bool IsTongHuaShun(List<Card> cards)
        {
            return IsTongHua(cards) && IsShunZi(cards);
        }

        private bool IsShunZi(List<Card> cards)
        {
            for (var i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Number.Value - cards[i + 1].Number.Value != 1)
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool IsTongHua(List<Card> cards)
        {
            for (var i = 0; i < cards.Count - 1; i++)
            {
                if (!cards[i].Shape.DisplayShape.Equals(cards[i + 1].Shape.DisplayShape))
                {
                    return false;
                }
            }

            return true;
        }
    }
}