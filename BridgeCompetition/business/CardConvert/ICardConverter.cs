using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardConvert
{
    public interface ICardConverter
    {
        Card Convert(string cardDescription);

        List<Card> ConvertToList(string cardDescription);

        CardsInHand ConvertToCardsInHand(string cardDescription);
    }
}