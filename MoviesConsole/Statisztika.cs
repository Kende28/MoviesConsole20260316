using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesConsole
{
	public class Statisztika
	{
		public List<Movies> Movies = new List<Movies>();

		public Statisztika() 
		{
			LoadMoviesFromDatabase();
		}
		
		private void LoadMoviesFromDatabase()
		{
			try
			{
				Movies = DataBase.LoadAllMovies();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Adatbázis hiba történt: {ex}");
			}
		}

		public void ElsoFeladat()
		{
			var count = 0;

			foreach (var item in Movies)
			{
				if (item.Genre.Equals("sci-fi"))
				{
					count++;
				}
			}

			Console.WriteLine($"Sci-fi témában {count} db film van!");

			count = Movies.Where(m => m.Genre.Equals("sci-fi")).Count();

			Console.WriteLine($"Sci-fi témában {count} db film van!");
		}

		public void MasodikFeladat()
		{
			Movies longest = Movies[0];

			foreach (var item in Movies)
			{
				if (item.Duration > longest.Duration)
				{
					longest = item;
				}
			}

			Console.WriteLine($"Leghosszabb film: {longest.Title} ({longest.Duration} perc)");

			longest = Movies.OrderByDescending(m => m.Duration).First();

			Console.WriteLine($"Leghosszabb film: {longest.Title} ({longest.Duration} perc)");
		}

		public void HarmadikFeladat()
		{
			Movies oldest = Movies[0];

			foreach (var item in Movies)
			{
				if (item.ReleaseDate < oldest.ReleaseDate)
				{
					oldest = item;
				}
			}

			Console.WriteLine($"A legrégebbi film: {oldest.Title} ({DateTime.Now.Year - oldest.ReleaseDate.Year} éves)");
		
			oldest = Movies.OrderBy(m => m.ReleaseDate).First();

			Console.WriteLine($"A legrégebbi film: {oldest.Title} ({DateTime.Now.Year - oldest.ReleaseDate.Year} éves)");
		}

		public void NegyedikFeladat()
		{
			int count = 0;

			foreach (var item in Movies)
			{
				if (item.OscarWinner)
				{
					count++;
				}
			}

			Console.WriteLine($"Oszkár nyertesek száma: {count}");

			count = Movies.Count(m => m.OscarWinner);

			Console.WriteLine($"Oszkár nyertesek száma: {count}");
		}

		public void OtodikFeladat()
		{
			List<Movies> huszeves = new List<Movies>();

			foreach (var item in Movies)
			{
				if (DateTime.Now.Year - item.ReleaseDate.Year > 20)
				{
					huszeves.Add(item);
				}
			}

			foreach (var item in huszeves)
			{
				Console.WriteLine($"{item.Title} ({DateTime.Now.Year - item.ReleaseDate.Year} éves)");
			}

			huszeves = Movies.Where(m => DateTime.Now.Year - m.ReleaseDate.Year > 20).ToList();

			foreach (var item in huszeves)
			{
				Console.WriteLine($"{item.Title} ({DateTime.Now.Year - item.ReleaseDate.Year} éves)");
			}
		}

		public void HatodikFeladat()
		{
			Console.Write("Adja meg egy film címét: ");
			string film = Console.ReadLine();

			Movies oscarWinner = null;

			foreach (var item in Movies)
			{
				if (item.Title == film && item.OscarWinner)
				{
					oscarWinner = item;
				}
			}

			if (oscarWinner != null && oscarWinner.OscarWinner)
			{
				Console.WriteLine($"{oscarWinner.Director} nyert Oszkárt");
			}
			else if (oscarWinner != null)
			{
				Console.WriteLine($"{oscarWinner.Director} nem nyert Oszkárt");
			}
			else
			{
				Console.WriteLine("Nincs ilyen című film");
			}

			oscarWinner = Movies.Where(m => m.Title == film && m.OscarWinner).FirstOrDefault();

			if (oscarWinner != null && oscarWinner.OscarWinner)
			{
				Console.WriteLine($"{oscarWinner.Director} nyert Oszkárt");
			}
			else if (oscarWinner != null)
			{
				Console.WriteLine($"{oscarWinner.Director} nem nyert Oszkárt");
			}
			else
			{
				Console.WriteLine("Nincs ilyen című film");
			}
		}
	}
}
