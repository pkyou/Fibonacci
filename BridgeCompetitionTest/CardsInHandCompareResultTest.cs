using System.Runtime.CompilerServices;
using BridgeCompetition.business.CardConvert;
using BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator;
using BridgeCompetition.business.WholeCardGenerate;
using BridgeCompetition.Entities;
using Xunit;

namespace BridgeCompetitionTest
{
    public class CardsInHandCompareResultTest
    {
        private readonly IWholeCardGenerator _wholeCardGenerator = new WholeCardGeneralGenerator();
        
        private ICardConverter _cardConverter ;
        private ICardsInHandComparator _comparator;

        [Theory]
        [InlineData(CompareResultEnum.ERROR,"6D 5D 4D 3D 2D","AD 5D 4D 3D")]
        [InlineData(CompareResultEnum.BLACKWIN,"6D 5D 4D 3D 2D","AD 5D 4D 3D 2D")]
        [InlineData(CompareResultEnum.WHITEWIN,"AH 5D 4D 3D 2D","AD 5D 4D 3D 2D")]
        [InlineData(CompareResultEnum.BLACKWIN,"AH 5D 4D 3D 2D","9S 5D 4D 3D 2D")]
        [InlineData(CompareResultEnum.WHITEWIN,"2H 3D 5S 9C KD","2C 3H 4S 8C AH")]
        [InlineData(CompareResultEnum.BLACKWIN,"2H 4S 4C 2D 4H","2S 8S AS QS 3S")]
        [InlineData(CompareResultEnum.BLACKWIN,"2H 3D 5S 9C KD","2C 3H 4S 8C KH")]
        [InlineData(CompareResultEnum.TIE,"2H 3D 5S 9C KD","2D 3H 5C 9S KH")]
        public void ShouldReturnCorrectResult(CompareResultEnum resultEnum,string blackCards,string whiteCards)
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);
            _comparator = new CardsInHandComparator(_cardConverter);
            var result = _comparator.Compare(blackCards, whiteCards);
            Assert.Equal(resultEnum, result.ResultEnum);
        }    
    }
}