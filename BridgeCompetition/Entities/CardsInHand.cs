using System.Collections.Generic;

namespace BridgeCompetition.Entities
{
    public class CardsInHand
    {
        public CardsInHandType Type { get; set; }
        
        public List<int> ComparingValues { get; set; }
    }
}