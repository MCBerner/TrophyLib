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
    public class TrophyRepositoryTests
    {
        private TrophyRepository? repo;


        [TestInitialize]
        public void Setup()
        {
            repo = new TrophyRepository();
            repo.Add(new Trophy() { Competition = "Dart 501", Year = 2001 });
            repo.Add(new Trophy() { Competition = "Golf", Year = 1993 });
            repo.Add(new Trophy() { Competition = "Hulla hop", Year = 2004 });
            // repo.Add(new Trophy() { Competition = "Tændstikkast", Year = 2010 });
            //repo.Add(new Trophy() { Competition = "Lakridsbånd på tid", Year = 2022 });
            repo.Add(new Trophy("Lakridsbånd på tid", 2022));

            Trophy t1 = new Trophy() { Competition = "Tændstikkast", Year = 2010 };
            repo.Add(t1);

            Trophy t2 = new Trophy(t1);
            repo.Add(t2);


        }

        [TestMethod()]
        public void GetTest()
        {
            //Get all trophies and check if there are 5
            List<Trophy> trophies = repo.Get();
            Assert.AreEqual(6, trophies.Count());
            Assert.AreEqual("Dart 501", trophies.First().Competition);

            //Get trophies from 2000 and check if there are 4
            List<Trophy> trophiesByYear = repo.Get(Year: 2000);
            Assert.AreEqual(5, trophiesByYear.Count());
            Assert.IsTrue(trophiesByYear.All(t => t.Year >= 2000));

            //Get trophies by fragment and check if there are 1
            List<Trophy> trophiesByFragment = repo.Get(trophyFragment: "Golf");
            Assert.AreEqual(1, trophiesByFragment.Count());
            Assert.AreEqual("Golf", trophiesByFragment.First().Competition);

            //Switch case name order by alphabetically
            List<Trophy> sortedByName = repo.Get(sortby: "Name");
            Assert.AreEqual("Dart 501", sortedByName.First().Competition);
            Assert.AreEqual("Tændstikkast", sortedByName.Last().Competition);

            //Switch case year last
            List<Trophy> sortedByYearLast = repo.Get(sortby: "yearLast");
            Assert.AreEqual(1993, sortedByYearLast.First().Year);
            Assert.AreEqual(2022, sortedByYearLast.Last().Year);

            //Switch case year first
            List<Trophy> sortedByYearFirst = repo.Get(sortby: "yearFirst");
            Assert.AreEqual(2022, sortedByYearFirst.First().Year);
            Assert.AreEqual(1993, sortedByYearFirst.Last().Year);

            //Get trophies by year and fragment
            List<Trophy> trophiesByYearAndFragment = repo.Get(Year: 2000, trophyFragment: "Dart");
            Assert.AreEqual(1, trophiesByYearAndFragment.Count());
            Assert.AreEqual("Dart 501", trophiesByYearAndFragment.First().Competition);

            //Get trophies by year and trophyfragment sorted by name
            List<Trophy> trophiesByAllParams = repo.Get(Year: 2000, trophyFragment: "a", sortby: "Name");
            Assert.AreEqual(5, trophiesByAllParams.Count());
            Assert.AreEqual("Dart 501", trophiesByAllParams.First().Competition);


        }

        [TestMethod()]
        public void AddTest()
        {
            Trophy t = new() { Competition = "Test", Year = 2015 };
            Assert.AreEqual(7, repo.Add(t).Id);
            Assert.AreEqual(7, repo.Get().Count());
            Assert.ThrowsException<ArgumentNullException>(() => repo.Add(null));
        }


        [TestMethod()]
        public void RemoveTest()
        {

            var removedTrophy = repo.GetById(1);
            repo.Remove(removedTrophy);
            Assert.AreEqual(1, removedTrophy?.Id);
            Assert.AreEqual(5, repo.Get().Count());
            Assert.ThrowsException<ArgumentException>(() => repo.Remove(null));


        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(repo.GetById(1));
            Assert.IsNull(repo.GetById(50));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(6, repo.Get().Count());
            Trophy t = new() { Competition = "Test", Year = 2016 };
            Assert.ThrowsException<ArgumentException>(() => repo.Update(50, t));
            Assert.AreEqual(5, repo.Update(5, t)?.Id);
            Assert.AreEqual(6, repo.Get().Count());
            Assert.AreEqual("Test", repo.GetById(5)?.Competition);

        }
    }
}