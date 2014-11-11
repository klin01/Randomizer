using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLib.Interfaces
{
    public interface IWeightedRandomItem : IRandomItem
    {
        int Weight { get; set; }
    }
}
