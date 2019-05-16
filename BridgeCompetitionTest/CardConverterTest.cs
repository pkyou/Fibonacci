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

        [Fact]
        public void ShouldReturnTongHuaShunType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 5D 4D 3D 2D");
            Assert.Equal(9,type.Order);
        }
        
        [Fact]
        public void ShouldReturnTieZhiType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 6H 6C 6S 2D");
            Assert.Equal(8,type.Order);
        }

        [Fact]
        public void ShouldReturnHuLuType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 6H 6C 2S 2D");
            Assert.Equal(7,type.Order);
        }

        [Fact]
        public void ShouldReturnTongHua()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 3D 7D 9D 8D");
            Assert.Equal(6,type.Order);
        }

        [Fact]
        public void ShouldReturnShunZi()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 5H 7D 9D 8D");
            Assert.Equal(5,type.Order);
        }

        [Fact]
        public void ShouldReturnSanTiaoType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 6H 6C 9D 8D");
            Assert.Equal(4,type.Order);
        }

        [Fact]
        public void ShouldReturnLiangDuiType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 6H 5C 5D 8D");
            Assert.Equal(3,type.Order);
        }

        [Fact]
        public void ShouldReturnDuiZiType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D 6H 5C 7D 8D");
            Assert.Equal(2,type.Order);
        }

        [Fact]
        public void ShouldReturnSanPaiType()
        {
            _cardConverter = new CardGeneralConverter(_wholeCardGenerator);

            var type = _cardConverter.ConvertToType("6D AH 5C 7D 8D");
            Assert.Equal(1,type.Order);
        }
        
    }
}