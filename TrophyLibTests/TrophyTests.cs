using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void CompetitionTest()
        {
            Trophy trophy = new Trophy();
            trophy.Competition = "Abc";
            Assert.AreEqual("Abc", trophy.Competition);
            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new Trophy();
            trophy.Id = 1;
            trophy.Competition = "DM i skiskydning";
            trophy.Year = 1970;
            string result = trophy.ToString();
            Assert.AreEqual("Id: 1, Competition: DM i skiskydning, Year: 1970", result);
        }
    }
}