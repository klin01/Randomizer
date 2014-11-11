using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomLib.Models;

namespace RandomizerConsole
{
    class Program
    {
        private static readonly List<RandomString> Items = new List<RandomString>(); 

        static void Main(string[] args)
        {
            if (args.Length < 2)
                Console.WriteLine("You must enter at least 2 arguments.");

            Console.WriteLine("You have entered the following values:");
            foreach (var item in args)
            {
                Console.WriteLine(item);
                AddItem(new RandomString { Value = item });
            }
            Console.WriteLine();

            var model = new RandomModel<RandomString>(Items);
            Console.WriteLine("The randomly selected value is: " + model.GetRandomItem().Value);
        }

        private static void AddItem(RandomString item)
        {
            Items.Add(item);
        }
    }
}
