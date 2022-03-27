using da2.Models;
using System.Collections.Generic;

namespace da2.Data
{
    public class GamesAndGenresAndPlatformsAndPublishers : Game
    {
        public List<Genre>? Genres;
        public List<Platform>? Platforms;
        public List<Publisher>? Publishers;
        public Game? game;
    }

  /*      public DreamTeamAndPlayersAndManager()
        {
            GoalKeepers = new List<Player>();
            RightDefenders = new List<Player>();
            LeftDefenders = new List<Player>();
            RightMidfielders = new List<Player>();
            LeftMidfielders = new List<Player>();
            RightForwards = new List<Player>();
            LeftForwards = new List<Player>();
            Managers = new List<Manager>();
        }
    }*/
}