using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardConvert
{
    public interface ICardConverter
    {
        Card Convert(string cardDescription);
    }
}