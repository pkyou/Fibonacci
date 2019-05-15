using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHand
{
    public class CardsInHandTypesGenerator : ICardsInHandTypesGenerater
    {
        private readonly List<CardsInHandType> _types = new List<CardsInHandType>
        {
            new CardsInHandType{Name = "SanPai",Order = 1},
            new CardsInHandType{Name = "DuiZi",Order = 2},
            new CardsInHandType{Name = "LiangDui",Order = 3},
            new CardsInHandType{Name = "SanTiao",Order = 4},
            new CardsInHandType{Name = "ShunZi",Order = 5},
            new CardsInHandType{Name = "TongHua",Order = 6},
            new CardsInHandType{Name = "HuLu",Order = 7},
            new CardsInHandType{Name = "TieZhi",Order = 8},
            new CardsInHandType{Name = "TongHuaShun",Order = 9}
        };

        public List<CardsInHandType> Generate()
        {
            return _types;
        }
    }
}