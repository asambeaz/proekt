using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace da2.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public double Rating { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public bool IsMultiplayer { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public double Price { get; set; }

        public Game(int id, string name, int platform, double rating, int publisher, int genre, bool isMultiplayer , double price)
        {
            Id = id;
            Name = name;
            PlatformId = platform;
            Rating = rating;
            PublisherId = publisher;
            GenreId = genre;
            IsMultiplayer = isMultiplayer;
            Price = price;
        }

        public Game()
        {
            Name = "";
            IsMultiplayer = false;
        }
    }
}
