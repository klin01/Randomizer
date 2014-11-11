using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomLib.Interfaces;

namespace RandomLib.Models
{
    public class WeightedRandomModel<T> : IRandomModel<T>
        where T : IWeightedRandomItem
    {
        private readonly Random _randomObj;
        private readonly List<T> _itemList;
 
        public WeightedRandomModel()
        {
            _itemList = new List<T>();
            _randomObj = new Random();
        }

        public WeightedRandomModel(List<T> items) : this()
        {
            _itemList = items;
        }

        public void AddItem(T item)
        {
            _itemList.Add(item);
        }

        public T GetRandomItem()
        {
            var weights = _itemList.Select(i => i.Weight);
            var gcdOfWeights = GCD(weights);

            var weightedItemList = new List<T>();
            _itemList.ForEach(i =>
            {
                var reducedWeight = i.Weight/gcdOfWeights;
                for(var j = 0; j < reducedWeight; j++)
                    weightedItemList.Add(i);
            });

            var model = new RandomModel<T>(weightedItemList);
            return model.GetRandomItem();
        }

        private static int GCD(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(GCD);
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
