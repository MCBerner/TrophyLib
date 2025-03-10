using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophyRepository
    {
        private int _nextId = 1;
        private readonly List<Trophy> trophies = new List<Trophy>();
        private readonly int Id;

        public TrophyRepository()
        {

        }

        public Trophy? GetById(int id)
        {
            return trophies.Find(trophy => trophy.Id == id);
        }

        public Trophy? Add(Trophy trophy)
        {
            if (trophy == null)
            {
                throw new ArgumentNullException(nameof(trophy));
            }
            trophy.Id = _nextId++;
            trophies.Add(trophy);
            return trophy;
        }
        public Trophy? Remove(Trophy trophy)
        {
            Trophy? movie = GetById(Id);
            if (trophy == null)
            {
                throw new ArgumentException("Trophy not found, id");
            }
            trophies.Remove(trophy);
            return trophy;
        }
        

        public List<Trophy> Get(int? Year = null, string? trophyFragment = null, string? sortby = null)
        {
            var result = new List<Trophy>(trophies);
            if (Year != null)
            {
                result = result.FindAll(a => a.Year >= Year);
            }
            if (trophyFragment != null)
            {
                result = result.FindAll(a => a.Competition.Contains(trophyFragment));
            }
            if (sortby != null)
            {
                switch (sortby)
                {
                    case "Name":
                        result.Sort((a1, a2) => a1.Competition.CompareTo(a2.Competition));
                        break;
                    case "yearLast":
                        result.Sort((a1, a2) => a1.Year - a2.Year);
                        break;
                    case "yearFirst":
                        result.Sort((a1, a2) => a2.Year - a1.Year);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
        public Trophy Update(int id, Trophy updatedTrophy)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                throw new ArgumentException("Trophy not found, id");
            }
            trophy.Competition = updatedTrophy.Competition;
            trophy.Year = updatedTrophy.Year;
            return trophy;
        }
    }
}
