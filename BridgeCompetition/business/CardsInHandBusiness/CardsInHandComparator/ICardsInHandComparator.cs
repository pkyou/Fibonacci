using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator
{
    public interface ICardsInHandComparator
    {
        CardsInHandCompareResult Compare(string blackCards, string whiteCards);    
    }
}