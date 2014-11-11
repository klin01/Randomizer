using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLib.Interfaces
{
    public interface IRandomModel<T>
        where T: IRandomItem
    {
        void AddItem(T item);
        T GetRandomItem();
    }
}
