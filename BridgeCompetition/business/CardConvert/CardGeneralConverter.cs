using System;
using System.Collections.Generic;
using System.Linq;
using BridgeCompetition.business.WholeCardGenerate;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardConvert
{
    public class CardGeneralConverter : ICardConverter
    {
        private IWholeCardGenerator _wholeCardGenerator;

        private List<Card> _wholeCards;

        private List<int> _comparingValues;

        public CardGeneralConverter(IWholeCardGenerator wholeCardGenerator)
        {
            _wholeCardGenerator = wholeCardGenerator;
            _wholeCards = _wholeCardGenerator.Generate();
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
            var cardsInHand = new CardsInHand();

            if (cards == null)
            {
                return null;
            }

            _comparingValues = new List<int>();
            cardsInHand.Cards = cards;
            cardsInHand.Type = getType(cards);
            cardsInHand.ComparingVaules = _comparingValues;
            return cardsInHand;
        }

        private CardsInHandType getType(List<Card> cards)
        {
            var values = cards.Select(x => x.Number.value).Distinct().ToList();
            var tieZhiType = new CardsInHandType {Name = "TieZhi", Order = 8};
            var huLuType = new CardsInHandType {Name = "HuLu", Order = 7};
            var sanTiaoType = new CardsInHandType {Name = "SanTiao", Order = 4};
            var liangDuiType = new CardsInHandType {Name = "LiangDui", Order = 3};


            if (values.Count == 2)
            {
                var list = cards.FindAll(x => x.Number.value == cards[0].Number.value);
                
                if (list.Count == 1)
                {
                    _comparingValues.Add(cards[1].Number.value);
                    return tieZhiType ;
                }

                if (list.Count == 2)
                {
                    _comparingValues.Add(cards[1].Number.value);
                    return huLuType;
                }

                if (list.Count == 3)
                {
                    _comparingValues.Add(cards[0].Number.value);
                    return huLuType;
                }

                if (list.Count == 4)
                {
                    _comparingValues.Add(cards[0].Number.value);
                    return tieZhiType;
                }

                return huLuType;
            }

            if (values.Count == 3)
            {
                var list = cards.FindAll(x => x.Number.value == cards[0].Number.value);
                if (list.Count == 1)
                {
                    if (cards.FindAll(x => x.Number.value == cards[1].Number.value).Count == 1)
                    {
                        _comparingValues.Add(cards[2].Number.value);
                        return sanTiaoType;
                    }
                    
                    if (cards.FindAll(x => x.Number.value == cards[1].Number.value).Count == 3)
                    {
                        _comparingValues.Add(cards[1].Number.value);
                        return sanTiaoType;
                    }
                }

                if (list.Count == 3)
                {
                    _comparingValues.Add(cards[0].Number.value);
                    return sanTiaoType;
                }

                _comparingValues.AddRange(values);
                return liangDuiType;
            }

            if (values.Count == 4)
            {
                foreach (var value in values)
                {
                    if (cards.FindAll(x=>x.Number.value == value).Count == 2)
                    {
                        _comparingValues.Add(value);
                    }
                }

                values.Remove(_comparingValues[0]);
                _comparingValues.AddRange(values);
                
                return new CardsInHandType {Name = "DuiZi", Order = 2};
            }

            if (values.Count == 5)
            {
                if (IsTongHuaShun(cards))
                {
                    _comparingValues.Add(values[0]);
                    return new CardsInHandType {Name = "TongHuaShun", Order = 9};
                }

                if (IsTongHua(cards))
                {
                    _comparingValues.AddRange(values);
                    return new CardsInHandType {Name = "TongHua", Order = 6};
                }

                if (IsShunZi(cards))
                {
                    _comparingValues.Add(values[0]);
                    return new CardsInHandType {Name = "ShunZi", Order = 5};
                }

                _comparingValues.AddRange(values);
                return new CardsInHandType {Name = "SanPai", Order = 1};
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
                if (cards[i].Number.value - cards[i + 1].Number.value != 1)
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