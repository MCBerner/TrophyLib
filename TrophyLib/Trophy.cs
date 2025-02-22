using System.Diagnostics;
using System;

namespace TrophyLib
{
    public class Trophy
    {
        private string competition;
        private int year;

        public int Id { get; set; }
        public string Competition
        {
            get => competition;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Competition is null");

                if (value.Length < 3)
                    throw new ArgumentException("Length must be greater than 2");
                competition = value; ;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (value < 1970 || value > 2025)
                    throw new ArgumentOutOfRangeException("Year must be between 1970 and 2025");
                year = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }
    }
}
