using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomLib.Interfaces;

namespace RandomizerConsole
{
    class RandomString : IRandomItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
