using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophyRepository
    {
        private List<Trophy> trophies = new List<Trophy>();
        public void Add(Trophy trophy)
        {
            if (trophies.Contains(trophy))
                throw new ArgumentException("Trophy already exists");
            trophies.Add(trophy);
        }
        public void Remove(Trophy trophy)
        {
            if (!trophies.Contains(trophy))
                throw new ArgumentException("Trophy does not exist");
            trophies.Remove(trophy);
        }
        public List<Trophy> GetAll()
        {
            return trophies;
        }
        public Trophy GetById(int id)
        {
            return trophies.Find(t => t.Id == id);
        }
        public List<Trophy> GetByCompetition(string competition)
        {
            return trophies.FindAll(t => t.Competition == competition);
        }
        public List<Trophy> GetByYear(int year)
        {
            return trophies.FindAll(t => t.Year == year);
        }
        public List<Trophy> GetByYearRange(int startYear, int endYear)
        {
            return trophies.FindAll(t => t.Year >= startYear && t.Year <= endYear);
        }
    }
}
