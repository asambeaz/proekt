using MySql.Data.MySqlClient;

namespace da2.Data
{
    public static class DataBase
    {
        private const string ConnectionString = "Server=localhost;Database=da2;Uid=root;Pwd=Mindil12345;";
        // Mahaite parolata 

        static DataBase()
        {
            MySqlConnection connection = GetConnection();
            connection.Open();

            using (connection)
            {
                string sqlGame = "CREATE TABLE IF NOT EXISTS games( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "genre_id INT NOT NULL, " +
                                    "rating DOUBLE, " +
                                    "platform_id INT NOT NULL," +
                                    "publisher_id INT NOT NULL," +
                                    "price DOUBLE, " +
                                    "is_multiplayer BOOLEAN, " +
                                    "CONSTRAINT fk_games_publishers " +
                                    "FOREIGN KEY(publisher_id) REFERENCES publishers(id) ON DELETE CASCADE, " +
                                    "CONSTRAINT fk_games_genres " +
                                    "FOREIGN KEY(genre_id) REFERENCES genres(id) ON DELETE CASCADE, " +
                                    "CONSTRAINT fk_games_platforms " +
                                    "FOREIGN KEY(platform_id) REFERENCES platforms(id) ON DELETE CASCADE " +
                                    ")";

                MySqlCommand commandGame = new MySqlCommand(sqlGame, connection);
                commandGame.ExecuteNonQuery();

                string sqlGenre = "CREATE TABLE IF NOT EXISTS genres( " +
                                    "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                    "name VARCHAR(50) NOT NULL, " +
                                    "age_group VARCHAR(50) NOT NULL, " +
                                    "popularity INT " +
                                    ")";

                MySqlCommand commandGenre = new MySqlCommand(sqlGenre, connection);
                commandGenre.ExecuteNonQuery();

                string sqlPlatform = "CREATE TABLE IF NOT EXISTS platforms( " +
                                     "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                     "name VARCHAR(50) NOT NULL, " +
                                     "Number_of_users INT " +
                                     ")";

                MySqlCommand commandPlatform = new MySqlCommand(sqlPlatform, connection);
                commandPlatform.ExecuteNonQuery();

                string sqlPublisher = "CREATE TABLE IF NOT EXISTS publishers( " +
                                      "id INT PRIMARY KEY AUTO_INCREMENT, " +
                                      "name VARCHAR(50) NOT NULL, " +
                                      "country VARCHAR(50) NOT NULL, " +
                                      "publisher_worth INT " +
                                      ")";

                MySqlCommand commandPublisher = new MySqlCommand(sqlPublisher, connection);
                commandPublisher.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
