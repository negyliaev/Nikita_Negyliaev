using System;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class ExtraTask2
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("128.32.10.1", UIntToIPv4(2149583361));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual("0.0.0.32", UIntToIPv4(32));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual("0.0.0.0", UIntToIPv4(0));
        }

        private String UIntToIPv4(uint number)
        {
            int[] binaryArray = new int[32];
            uint binaryDigit = (uint) Math.Pow(2, 31);

            for (int i = 31; i >= 0; i--)
            {
                if (number >= binaryDigit)
                {
                    number -= binaryDigit;
                    binaryArray[i] = 1;
                }

                binaryDigit /= 2;
            }

            var octets = new uint[4];
            for (int i = 0; i < 32; i++)
            {
                binaryDigit = (uint) Math.Pow(2, i - i / 8 * 8);
                if (binaryArray[i] == 1)
                {
                    octets[3 - i / 8] += binaryDigit;
                }
            }

            string result = "";
            for (int i = 0; i < octets.Length; i++)
            {
                result += octets[i].ToString(); 
                if (i < octets.Length - 1) result += ".";
            }

            return result;
        }


    }
}