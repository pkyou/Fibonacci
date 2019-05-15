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

            return cards;
        }

        public CardsInHandType ConvertToType(string cardDescription)
        {
            List<Card> cards = ConvertToList(cardDescription);
            if (cards == null)
            {
                return null;
            }

            if (IsTongHuaShun(cards))
            {
                return new CardsInHandType{Name = "TongHuaShun",Order = 9};
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