using BridgeCompetition.business.CardConvert;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator
{
    public class CardsInHandComparator : ICardsInHandComparator
    {
        private ICardConverter _converter;
        public CardsInHandComparator(ICardConverter converter)
        {
            _converter = converter;
        }
        public CardsInHandCompareResult Compare(string blackCards, string whiteCards)
        {
            CardsInHandCompareResult result = new CardsInHandCompareResult();
            var blackCardsInHand = _converter.ConvertToCardsInHand(blackCards);
            var whiteCardsInHand = _converter.ConvertToCardsInHand(whiteCards);

            if (blackCardsInHand == null || whiteCardsInHand == null || blackCardsInHand.Type == null ||
                whiteCardsInHand.Type == null)
            {
                result.ResultEnum = CompareResultEnum.ERROR;
                return result;
            }

            if (blackCardsInHand.Type.Order > whiteCardsInHand.Type.Order)
            {
                result.ResultEnum = CompareResultEnum.BLACKWIN;
                return result;
            }

            if (blackCardsInHand.Type.Order < whiteCardsInHand.Type.Order)
            {
                result.ResultEnum = CompareResultEnum.WHITEWIN;
                return result;
            }

            if (blackCardsInHand.Type.Order == whiteCardsInHand.Type.Order)
            {
                var blackComparingValues = blackCardsInHand.ComparingVaules;
                var whiteComparingValues = whiteCardsInHand.ComparingVaules;
                if (blackComparingValues.Count != whiteComparingValues.Count)
                {
                    result.ResultEnum = CompareResultEnum.ERROR;
                    return result;
                }

                for (int i = 0; i < blackComparingValues.Count; i++)
                {
                    if (blackComparingValues[i] > whiteComparingValues[i])
                    {
                        result.ResultEnum = CompareResultEnum.BLACKWIN;
                        return result;
                    }

                    if (blackComparingValues[i] < whiteComparingValues[i])
                    {
                        result.ResultEnum = CompareResultEnum.WHITEWIN;
                        return result;
                    }
                }

                result.ResultEnum = CompareResultEnum.TIE;
            }
    
            return result;
        }
    }
}