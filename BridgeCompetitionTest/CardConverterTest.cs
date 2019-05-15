using System;
using BridgeCompetition.business.CardConvert;
using BridgeCompetition.business.WholeCardGenerate;
using Xunit;
using Xunit.Sdk;

namespace BridgeCompetitionTest
{
    public class CardConverterTest
    {
        private readonly IWholeCardGenerator _wholeCardGenerator = new WholeCardGeneralGenerator();
        
        private ICardConverter _cardConverter ;
        

        [Fact]
        public void ShouldReturnWholeCards()
        {
            var cards = _wholeCardGenerator.Generate();
            Assert.Equal(52,cards.Count);
        }
        
        [Fact]
        public void ShouldReturnCorrectCardIfDescriptionIs2D()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);
            var card = _cardConverter.Convert("AS");
            Assert.Equal(1,card.Shape.Order);
            Assert.Equal("S",card.Shape.DisplayShape);
            Assert.Equal(14,card.Number.value);
        }

        [Fact]
        public void ShouldReturnNullIfDescriptionIsWrong()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);
            var card = _cardConverter.Convert("BK");
            Assert.Null(card);
        }
        
    }
}