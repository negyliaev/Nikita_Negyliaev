using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class ExtraTask1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(21, NextBigger(12));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(531, NextBigger(513));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual(-1, NextBigger(531));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(2071, NextBigger(2017));
        }

        

        private int NextBigger(int num)
        {
            List<int> digits = num.ToString().Select(ch => int.Parse(ch.ToString())).Reverse().ToList();
            int sum = 0; 
            int exponent = 1;
            bool found = false;
            for (int i = 0; i < digits.Count-1; i++)
            {
                if(digits[i] > digits[i+1] && !found)
                {
                    (digits[i + 1], digits[i]) = (digits[i], digits[i + 1]);
                    found = true;
                }
                sum += digits[i] * exponent;
                exponent *= 10;
            }
            sum += digits[digits.Count - 1] * exponent;
            if (!found) return -1;
            return sum;
        }
    }
}