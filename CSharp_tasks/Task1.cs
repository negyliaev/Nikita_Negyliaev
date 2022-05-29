using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class Task1
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(new List<int>() { 1, 2 }, GetIntegersFromList(new List<object>() { 1, 2, "a", "b" }));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 0, 15 }, GetIntegersFromList(new List<object>() { 1, 2, "a", "b", 0, 15, "123"}));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 123 }, GetIntegersFromList(new List<object>() { 1, 2, "a", "b", "aasf", "1", "123", 123}));
        }

        private List<int> GetIntegersFromList(List<object> inputList)
        {
            return inputList.Where(item => item is Int32).Select(item => (int)item).ToList();
        }
    }
}