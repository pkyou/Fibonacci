using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator
{
    public interface ICardsInHandComparator
    {
        CardsInHandCompareResult Compare(List<Card> blackCards, List<Card> whiteCards);
    }
}