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
        [InlineData(CompareResultEnum.Error,"6D 5D 4D 3D 2D","AD 5D 4D 3D")]
        //同花顺
        [InlineData(CompareResultEnum.Blackwin,"6D 5D 4D 3D 7D","6D 5D 4D 3D 2D")]
        //铁支
        [InlineData(CompareResultEnum.Blackwin,"5H 5D 5S 5C KD","4C 3H 3S 3C 3D")]
        //葫芦
        [InlineData(CompareResultEnum.Blackwin,"5H 5D 5S 4C 4D","3C 3H 3S 7C 7D")]
        //同花
        [InlineData(CompareResultEnum.Blackwin,"AD 5D 4D 3D 7D","9D 5D 4D 3D 2D")]
        //顺子
        [InlineData(CompareResultEnum.Blackwin,"6D 5H 4H 8D 7D","6H 5D 4D 3H 2D")]
        //三条
        [InlineData(CompareResultEnum.Blackwin,"5H 5D 5S 7C 8D","3C 3H 3S 9C AD")]
        //两对
        [InlineData(CompareResultEnum.Whitewin,"5H 5D 4S 4C AD","6C 6H 5S 5C 7D")]
        [InlineData(CompareResultEnum.Blackwin,"5H 5D 7S 7C AD","5C 5H 6S 6C 7D")]
        //对子
        [InlineData(CompareResultEnum.Whitewin,"5H 5D 4S 7C 8D","6C 6H 5S 9C 7D")]
        //散牌
        [InlineData(CompareResultEnum.Blackwin,"2H 3D 5S 9C KD","2C 3H 4S 8C KH")]
        [InlineData(CompareResultEnum.Tie,"2H 3D 5S 9C KD","2D 3H 5C 9S KH")]
        public void ShouldReturnCorrectResult(CompareResultEnum resultEnum,string blackCards,string whiteCards)
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);
            _comparator = new CardsInHandComparator(_cardConverter);
            var result = _comparator.Compare(blackCards, whiteCards);
            Assert.Equal(resultEnum, result.ResultEnum);
        }    
    }
}