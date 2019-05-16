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

        [Fact]
        public void ShouldReturnCardsIfCorrectDescription()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var cards = _cardConverter.ConvertToList("2D 3H 5C 9S KH");
            Assert.Equal(5,cards.Count);
            Assert.Equal("H",cards[1].Shape.DisplayShape);
            Assert.Equal(5,cards[2].Number.value);
        }

        [Theory]
        [InlineData("qweqwe")]
        [InlineData("2D 3H 5C 9S KH KH")]
        [InlineData("2D 3H 5C 9S kh")]
        public void ShouldReturnListNullIfDescriptionIsWrong(string description)
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var cards = _cardConverter.ConvertToList(description);
            Assert.Null(cards);
        }
        
        [Theory]
        [InlineData("6D 5D 4D 3D 2D",9,1)]
        [InlineData("6D 6H 6C 6S 2D",8,1)]
        [InlineData("6D 6H 6C 2S 2D",7,1)]
        [InlineData("6D 3D 7D 9D 8D",6,5)]
        [InlineData("6D 5H 7D 9D 8D",5,1)]
        [InlineData("6D 6H 6C 9D 8D",4,1)]
        [InlineData("6D 6H 5C 5D 8D",3,3)]
        [InlineData("6D 6H 5C 7D 8D",2,4)]
        [InlineData("6D AH 5C 7D 8D",1,5)]
        public void ShouldReturnCorrectCardsInHand(string description,int order,int comparingCount)
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var cardsInHand = _cardConverter.ConvertToCardsInHand(description);
            Assert.Equal(order,cardsInHand.Type.Order);
            Assert.Equal(comparingCount,cardsInHand.ComparingVaules.Count);
        }
    }
}