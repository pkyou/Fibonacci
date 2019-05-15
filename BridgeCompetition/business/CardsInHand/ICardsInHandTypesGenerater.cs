using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHand
{
    public interface ICardsInHandTypesGenerater
    {
        List<CardsInHandType> Generate();
    }
}