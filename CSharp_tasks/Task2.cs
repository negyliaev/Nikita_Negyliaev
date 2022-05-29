using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class Task2
    {

        [Test]
        public void Test1()
        {
           Assert.AreEqual("t", first_non_repeating_letter("stress"));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual("T", first_non_repeating_letter("sTreSS"));
        }
        

        private string first_non_repeating_letter(string input)
        {
            string loweredInput = input.ToLower();
            List<char> chars = loweredInput.Select(ch => ch).Distinct().ToList(); 
            for (int i = 0; i< loweredInput.Length; i++)
            {
                if (loweredInput.Count(ch => ch == loweredInput[i]) == 1) 
                {
                    return input.IndexOf(loweredInput[i]) == -1 ? loweredInput[i].ToString().ToUpper() : loweredInput[i].ToString();
                }
            }   
            return "";
            
        }
    }
}