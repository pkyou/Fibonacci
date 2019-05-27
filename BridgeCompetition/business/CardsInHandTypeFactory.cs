using BridgeCompetition.Entities;

namespace BridgeCompetition.business
{
    
    public class CardsInHandTypeFactory
    {
        static CardsInHandType sanPaiType = new CardsInHandType {Name = "SanPai", Order = 1};
        static CardsInHandType duiZiType = new CardsInHandType {Name = "DuiZi", Order = 2};
        static CardsInHandType liangDuiType = new CardsInHandType {Name = "LiangDui", Order = 3};
        static CardsInHandType sanTiaoType = new CardsInHandType {Name = "SanTiao", Order = 4};
        static CardsInHandType shunZiType = new CardsInHandType {Name = "ShunZi", Order = 5};
        static CardsInHandType tongHuaType = new CardsInHandType {Name = "TongHua", Order = 6};
        static CardsInHandType huLuType = new CardsInHandType {Name = "HuLu", Order = 7};
        static CardsInHandType tieZhiType = new CardsInHandType {Name = "TieZhi", Order = 8};
        static CardsInHandType tongHuaShunType = new CardsInHandType {Name = "TongHuaShun", Order = 9};

        public static CardsInHandType GetSanPaiType()
        {
            return sanPaiType;
        }

        public static CardsInHandType GetDuiZiType()
        {
            return duiZiType;
        }

        public static CardsInHandType GetLiangDuiType()
        {
            return liangDuiType;
        }

        public static CardsInHandType GetSanTiaoType()
        {
            return sanTiaoType;
        }

        public static CardsInHandType GetShunZiType()
        {
            return shunZiType;
        }

        public static CardsInHandType GetTongHuaType()
        {
            return tongHuaType;
        }

        public static CardsInHandType GetHuLuType()
        {
            return huLuType;
        }
        
        public static CardsInHandType GetTieZhiType ()
        {
            return tieZhiType;
        }

        public static CardsInHandType GetTongHuaShunType()
        {
            return tongHuaShunType;
        }

    }
}