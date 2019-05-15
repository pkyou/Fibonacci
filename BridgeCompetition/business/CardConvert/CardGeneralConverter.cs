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
    }
}