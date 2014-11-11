using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomLib.Interfaces;
using RandomLib.Models;

namespace RandomLib.Tests
{
    [TestClass]
    public class WeightedRandomModelTests
    {
        public class WeightedRandomString : IWeightedRandomItem
        {
            public int Id { get; set; }
            public int Weight { get; set; }
            public string Value { get; set; }
        }

        private readonly string[] values = {"TestValue1", "TestValue2", "TestValue3", "TestValue4"};
            
        [TestMethod]
        public void Test_ZeroWeightItemNeverOccurs()
        {
            var items = new List<WeightedRandomString>
            {
                new WeightedRandomString() { Value = "Test0", Weight = 0 },
                new WeightedRandomString() { Value = "Test1", Weight = 1 },
                new WeightedRandomString() { Value = "Test2", Weight = 2 },
                new WeightedRandomString() { Value = "Test3", Weight = 3 },
                new WeightedRandomString() { Value = "Test4", Weight = 4 }
            };

            var model = new WeightedRandomModel<WeightedRandomString>(items);
            for (var i = 0; i < 1000; i++)
            {
                Assert.AreNotEqual(model.GetRandomItem().Value, "Test0");
            }
        }
    }
}
