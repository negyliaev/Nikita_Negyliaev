using System;
using System.Linq;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class Task3
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, DigitalRoot(1));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual(6, DigitalRoot(942));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(6, DigitalRoot(132189));
        }
        
        [Test]
        public void Test4()
        {
            Assert.AreEqual(2, DigitalRoot(493193));
        }

        private int DigitalRoot(int number)
        {
            while (true)
            {
                Console.Write(number);
                var digits = number.ToString().Select(ch => int.Parse(ch.ToString()));
                int digitsSum = digits.Sum();
                if (digitsSum > 9)
                {
                    number = digitsSum;
                    continue;
                }

                return digitsSum;
                break;
            }
        }
    }
}