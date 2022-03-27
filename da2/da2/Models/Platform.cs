using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace da2.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfUsers { get; set; }

        public Platform(int id, string name, int numberOfUsers)
        {
            Id = id;
            Name = name;
            NumberOfUsers = numberOfUsers;
        }

        public Platform()
        {
            Name = "";
        }
    }
}
