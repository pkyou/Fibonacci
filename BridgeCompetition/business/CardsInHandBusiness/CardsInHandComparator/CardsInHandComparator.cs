using BridgeCompetition.business.CardConvert;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator
{
    public class CardsInHandComparator : ICardsInHandComparator
    {
        private readonly ICardConverter _converter;
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
                result.ResultEnum = CompareResultEnum.Error;
                return result;
            }

            if (blackCardsInHand.Type.Order > whiteCardsInHand.Type.Order)
            {
                result.ResultEnum = CompareResultEnum.Blackwin;
                return result;
            }

            if (blackCardsInHand.Type.Order < whiteCardsInHand.Type.Order)
            {
                result.ResultEnum = CompareResultEnum.Whitewin;
                return result;
            }

            var blackComparingValues = blackCardsInHand.ComparingValues;
            var whiteComparingValues = whiteCardsInHand.ComparingValues;
            
            if (blackComparingValues.Count != whiteComparingValues.Count)
            {
                result.ResultEnum = CompareResultEnum.Error;
                return result;
            }

            for (var i = 0; i < blackComparingValues.Count; i++)
            {
                if (blackComparingValues[i] > whiteComparingValues[i])
                {
                    result.ResultEnum = CompareResultEnum.Blackwin;
                    return result;
                }

                if (blackComparingValues[i] < whiteComparingValues[i])
                {
                    result.ResultEnum = CompareResultEnum.Whitewin;
                    return result;
                }
            }

            result.ResultEnum = CompareResultEnum.Tie;


            return result;
        }
    }
}