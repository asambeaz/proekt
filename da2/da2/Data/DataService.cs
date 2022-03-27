using da2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace da2.Data
{
    public class DataService
    {
        public static List<Game> GetGames()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Game> games = new List<Game>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM games";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Game game = new Game();
                    game.Id = reader.GetInt32(0);
                    game.Name = reader.GetString(1);
                    game.Rating = reader.GetDouble(3);
                    game.GenreId = reader.GetInt32(2);
                    game.PlatformId = reader.GetInt32(4);
                    game.PublisherId = reader.GetInt32(5);
                    game.Price = reader.GetDouble(6);
                    game.IsMultiplayer = reader.GetBoolean(7);

                    games.Add(game);
                }
            }
            return games;
        }

        public static void AddGame( string name, double rating, double price, int genre, int platform, int publisher, bool isMultiplayer)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO games(name, rating, genre_id, platform_id, publisher_id, price, is_multiplayer) " +
                                "VALUES (@name, @rating, @genre_id, @platform_id, @publisher_id, @price, @is_multiplayer) ";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@platform_id", platform);
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@publisher_id", publisher);
                command.Parameters.AddWithValue("@genre_id", genre);
                command.Parameters.AddWithValue("@is_multiplayer", isMultiplayer);
                command.Parameters.AddWithValue("@price", price);
                command.ExecuteNonQuery();
            }

        }
        public static void DeleteGame(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM games " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void EditGame(int id, string name, int platform, double rating, int publisher, int genre, bool isMultiplayer, double price)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "UPDATE games " +
                                "SET name = @name, rating = @rating, genre_id = @genre_id, platform_id = @platform_id, publisher_id = @publisher_id, price = @price, is_multiplayer = @is_multiplayer " +
                                "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@platform_id", platform);
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@publisher_id", publisher);
                command.Parameters.AddWithValue("@genre_id", genre);
                command.Parameters.AddWithValue("@is_multiplayer", isMultiplayer);
                command.Parameters.AddWithValue("@price", price);
                command.ExecuteNonQuery();
            }
        }

        public static List<Publisher> GetPublishers()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Publisher> publishers = new List<Publisher>();

            using (mySqlConnection)
            {
                string sql1 = "SELECT * FROM publishers";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                MySqlDataReader reader = command1.ExecuteReader();



                while (reader.Read())
                {
                    Publisher publisher = new Publisher();
                    publisher.Id = reader.GetInt32(0);
                    publisher.Name = reader.GetString(1);
                    publisher.Country = reader.GetString(2);
                    publisher.PublisherWorth = reader.GetInt32(3);

                    publishers.Add(publisher);
                }
            }
            return publishers;
        }
        public static void AddPublisher(string name, string country, int publisherworth)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql1 = "INSERT INTO publishers(name, country, publisher_worth) " +
                                "VALUES (@name, @country, @publisher_worth)";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@name", name);
                command1.Parameters.AddWithValue("@country", country);
                command1.Parameters.AddWithValue("@publisher_worth", publisherworth);
                command1.ExecuteNonQuery();
            }
        }
        public static void EditPublisher(int id, string name, string country, int publisherworth)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql1 = "UPDATE publishers " +
                                "SET name = @name, country = @country, publisher_worth = @publisher_worth " +
                                "WHERE id = @id";

                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@id", id);
                command1.Parameters.AddWithValue("@name", name);
                command1.Parameters.AddWithValue("@country", country);
                command1.Parameters.AddWithValue("@publisher_worth", publisherworth);
                command1.ExecuteNonQuery();
            }
        }
        public static void DeletePublisher(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql1 = "DELETE FROM publishers " +
                                "WHERE id = @id";
                MySqlCommand command1 = new MySqlCommand(sql1, mySqlConnection);
                command1.Parameters.AddWithValue("@id", id);
                command1.ExecuteNonQuery();
            }
        }

        public static List<Genre> GetGenres()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Genre> genres = new List<Genre>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM genres";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Genre genre = new Genre();
                    genre.Id = reader.GetInt32(0);
                    genre.Name = reader.GetString(1);
                    genre.AgeGroup = reader.GetString(2);
                    genre.Popularity = reader.GetInt32(3);

                    genres.Add(genre);
                }
            }

            return genres;
        }
        public static void AddGenre(string name, int popularity, string ageGroup)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO genres(name, popularity, age_group) " +
                                "VALUES (@name, @popularity, @age_group) ";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@popularity", popularity);
                command.Parameters.AddWithValue("@age_group", ageGroup);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteGenre(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM genres " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void EditGenre(int id, string name, string ageGroup, int popularity)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {

                string sql = "UPDATE genres " +
                                "SET name = @name, popularity = @popularity, age_group = @age_group " +
                                "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@age_group", ageGroup);
                command.Parameters.AddWithValue("@popularity", popularity);
                command.ExecuteNonQuery();
            }

        }

        public static List<Platform> GetPlatforms()
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();
            List<Platform> platforms = new List<Platform>();

            using (mySqlConnection)
            {
                string sql = "SELECT * FROM platforms";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Platform platform = new Platform();
                    platform.Id = reader.GetInt32(0);
                    platform.Name = reader.GetString(1);
                    platform.NumberOfUsers = reader.GetInt32(2);

                    platforms.Add(platform);
                }
            }

            return platforms;
        }
        public static void AddPlatform(string name, int numberOfUsers)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "INSERT INTO platforms(name, number_of_users) " +
                                "VALUES (@name, @number_of_users) ";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@number_of_users", numberOfUsers);
                command.ExecuteNonQuery();
            }
        }
        public static void DeletePlatform(int id)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {
                string sql = "DELETE FROM platforms " +
                                "WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        public static void EditPlatform(int id, string name, int numberOfUsers)
        {
            MySqlConnection mySqlConnection = DataBase.GetConnection();
            mySqlConnection.Open();

            using (mySqlConnection)
            {

                string sql = "UPDATE platforms " +
                                "SET name = @name, number_of_users = @number_of_users " +
                                "WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, mySqlConnection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@number_of_users", numberOfUsers);
                command.ExecuteNonQuery();
            }

        }
    }
}
