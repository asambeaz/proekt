using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace da2.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public string AgeGroup { get; set; }
       

        public Genre(int id, string name, int popularity, string ageGroup)
        {
            Id = id;
            Name = name;
            Popularity = popularity;
            AgeGroup = ageGroup;
        }

        public Genre()
        {
            Name = "";
            AgeGroup = "";
        }
    }
}
