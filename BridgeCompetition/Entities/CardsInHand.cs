using System.Collections.Generic;

namespace BridgeCompetition.Entities
{
    public class CardsInHand
    {
        public List<Card> Cards { get; set; }
        
        public CardsInHandType Type { get; set; }
    }
}