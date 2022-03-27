using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace da2.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int PublisherWorth { get; set; }

        
        public Publisher(int id, string name, string country, int publisherworth)
        {
            Id = id;
            Name = name;
            Country = country;
            PublisherWorth = publisherworth;
        }

        public Publisher()
        {
            Name = "";
            Country = "";
        }
    }
}
