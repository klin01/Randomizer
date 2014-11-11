using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomLib.Interfaces;

namespace RandomLib.Models
{
    public class RandomModel<T> : IRandomModel<T>
        where T : IRandomItem
    {
        private readonly Random _randomObj;
        private readonly List<T> _itemList;

        public RandomModel()
        {
            _randomObj = new Random();
            _itemList = new List<T>();
        }

        public RandomModel(List<T> items) : this()
        {
            _itemList = items;
        }

        public void AddItem(T item)
        {
            _itemList.Add(item);
        }

        public T GetRandomItem()
        {
            var randomIndex = _randomObj.Next(_itemList.Count);
            return _itemList[randomIndex];
        }
    }
}
