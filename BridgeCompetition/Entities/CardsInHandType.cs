using System.Collections.Generic;
using BridgeCompetition.business.CardsInHandBusiness.CardsInHandComparator;

namespace BridgeCompetition.Entities
{
    public class CardsInHandType
    {
        public string Name { get; set; }
        public int Order { get; set; }
        
        public List<int> ComparedValues { get; set; }
    }
}