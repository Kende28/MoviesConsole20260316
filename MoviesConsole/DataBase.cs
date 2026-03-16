using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesConsole
{
	public class DataBase
	{
		public const string ConnectionString = "Server=localhost;port=3306;Database=movies;Uid=root;Pwd=;";
		public static List<Movies> LoadAllMovies() 
		{
			string sql = "SELECT id, title, genre, duration, duration, release_date, director, oscar_winner FROM movies ORDER BY id";

			var connection = new MySqlConnection(ConnectionString);

			connection.Open();

			var cmd = new MySqlCommand(sql, connection);

			var reader = cmd.ExecuteReader();

			List<Movies> result = new List<Movies>();

			while (reader.Read())
			{
				string title = reader.GetString("title");
				string genre = reader.GetString("genre");
				int duration = reader.GetInt32("duration");
				DateTime releaseDate = reader.GetDateTime("release_date");
				string director = reader.GetString("director");
				bool oscarWinner = reader.GetBoolean("oscar_winner");

				result.Add(new Movies(title, genre, duration, releaseDate, director, oscarWinner));
			}

			return result;
		}
	}
}
