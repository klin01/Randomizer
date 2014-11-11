using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomLib.Interfaces;
using RandomLib.Models;

namespace RandomLib.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public class SomeRandomThing : IRandomItem
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private readonly string[] _names = { "Kevin", "Mike", "Greg", "Ken" };

        private SomeRandomThing GenerateRandomItem()
        {
            var randomItems = (from name in _names
                               select new SomeRandomThing()
                               {
                                   Value = name
                               }).ToList();

            var model = new RandomModel<SomeRandomThing>(randomItems);

            return model.GetRandomItem();
        }

        [TestMethod]
        public void Test_RandomItemIsNotNull()
        {
            var randomItem = GenerateRandomItem();
            Assert.IsTrue(randomItem != null);
        }

        [TestMethod]
        public void Test_RandomItemIsFromListOfNames()
        {
            var randomItem = GenerateRandomItem();
            Assert.IsTrue(_names.Contains(randomItem.Value));
        }
    }
}
