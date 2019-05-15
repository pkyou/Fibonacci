using System.Collections.Generic;
using BridgeCompetition.Entities;

namespace BridgeCompetition.business.WholeCardGenerate
{
    public interface IWholeCardGenerator
    {
        List<Card> Generate();
    }
}