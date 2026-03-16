using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesConsole
{
	public class Movies
	{

		public string Title { get; }
		public string Genre { get; }
		public int Duration { get; }
		public DateTime ReleaseDate { get; }
		public string Director { get; }
		public bool OscarWinner { get; }

		public Movies(string title, string genre, int duration, DateTime releaseDate, string director, bool oscarWinner)
		{
			Title = title;
			Genre = genre;
			Duration = duration;
			ReleaseDate = releaseDate;
			Director = director;
			OscarWinner = oscarWinner;
		}
	}
}
