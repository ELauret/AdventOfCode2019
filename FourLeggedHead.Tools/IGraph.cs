using System;
using System.Collections.Generic;
using System.Text;

namespace FourLeggedHead.Tools
{
    public interface IGraph :IEnumerable<IVertex>
    {
        T MaxDistance<T>();
        T AddDistance<T>(T firstDistance, T secondDistance);
        IEnumerable<IVertex> GetNeighbors(IVertex vertex);
    }
}
