using System.Linq;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class Task4
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, NumberOfPairs(new int[] {1, 3, 6, 2, 2, 0, 4, 5}, 5));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(1, NumberOfPairs(new int[] {1, 3, 6, 2, 2, 0, 4, 5}, 10));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(0, NumberOfPairs(new int[] {10}, 10));
        }

        private int NumberOfPairs(int[] array, int target)
        {
            var numbersList = array.ToList();
            int amountOfPairs = 0;
            int length = numbersList.Count;
            for (int i = 0; i < length; i++)
            {
                amountOfPairs += numbersList.Count(num => num + numbersList[0] == target);
                if(numbersList[0] * 2 == target) amountOfPairs -= 1; 
                numbersList.RemoveAt(0);
            }
            return amountOfPairs;
        }
    }
}