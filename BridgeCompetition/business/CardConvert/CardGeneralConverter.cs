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

        public CardsInHandType ConvertToType(string cardDescription)
        {
            List<Card> cards = ConvertToList(cardDescription);
            if (cards == null)
            {
                return null;
            }
            var values = cards.Select(x=>x.Number.value).Distinct().ToArray();

            if (values.Length == 2)
            {
                var list = cards.FindAll(x=>x.Number.value == cards[0].Number.value);
                if (list.Count == 1 || list.Count == 4)
                {
                    return new CardsInHandType{Name = "TieZhi",Order = 8};
                }

                return new CardsInHandType{Name = "HuLu",Order = 7};
            }

            if (values.Length == 3)
            {
                var list = cards.FindAll(x => x.Number.value == cards[0].Number.value);
                if (list.Count == 1 )
                {
                    if (cards.FindAll(x => x.Number.value == cards[1].Number.value).Count == 1)
                    {
                        return new CardsInHandType {Name = "SanTiao", Order = 4};
                    }
                }

                if (list.Count == 3)
                {
                    return new CardsInHandType {Name = "SanTiao", Order = 4};
                }
                
                return new CardsInHandType {Name = "LiangDui", Order = 3};
            }

            if (values.Length == 4)
            {
                return new CardsInHandType{Name = "DuiZi",Order = 2};
            }

            if (values.Length == 5)
            {
                if (IsTongHuaShun(cards))
                {
                    return new CardsInHandType{Name = "TongHuaShun",Order = 9};
                }

                if (IsTongHua(cards))
                {
                    return new CardsInHandType{Name = "TongHua",Order = 6};
                }
                if (IsShunZi(cards))
                {
                    return new CardsInHandType{Name = "ShunZi",Order = 5};
                }
                
                return new CardsInHandType{Name = "SanPai",Order = 1};
            }

            return null;
        }
        

        private bool IsTieZhi(List<Card> cards)
        {
            var values = cards.Select(x=>x.Number.value).ToArray();
            return values.Select(value => cards.FindAll(x => x.Number.value == value).Count == 4).FirstOrDefault();
        }

        private bool IsTongHuaShun(List<Card> cards)
        {
            return IsTongHua(cards) && IsShunZi(cards);

        }

        private bool IsShunZi(List<Card> cards)
        {
            for (var i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Number.value -  cards[i + 1].Number.value != 1)
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
                if (!cards[i].Shape.DisplayShape.Equals(cards[i+1].Shape.DisplayShape))
                {
                    return false;
                }
            }

            return true;
        }
    }
}