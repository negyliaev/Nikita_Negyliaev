using System;
using NUnit.Framework;

namespace CSharp_tasks
{
    [TestFixture]
    public class Task5
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)", InvitationRearrange("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill"));
        }
        
        [Test]
        public void Test2()
        {
            Assert.AreEqual("(BROWN, TONY)(CORWILL, ALEX)(CORWILL, FRED)(CORWILL, FRED)", InvitationRearrange("Fred:Corwill;Fred:Corwill;Alex:Corwill;Tony:Brown"));
        }
        
        [Test]
        public void Test3()
        {
            Assert.AreEqual("", InvitationRearrange(""));
        }

        private string InvitationRearrange(string invitation)
        {
            if (invitation.Length == 0) return "";
                
            invitation = invitation.ToUpper();
            //var People = new List<Person>();
            string[] people = invitation.Split(';');
            for (int i = 0; i < people.Length; i++)
            {
                string[] nameAndSurname = people[i].Split(':');
                people[i] = nameAndSurname[1] + ", " + nameAndSurname[0];
            }
            Array.Sort(people);
            string res = "";
            foreach (var person in people)
            {
                res += "(" + person + ")";
            }
            return res;
        }
    }
}