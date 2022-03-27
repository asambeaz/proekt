using da2.Models;
using System.Collections.Generic;

namespace da2.Data
{
    public class GamesAndGenresAndPlatformsAndPublishers : Game
    {
        public List<Genre> Genres;
        public List<Platform> Platforms;
        public List<Publisher> Publishers;
        public Game game;
    }
}