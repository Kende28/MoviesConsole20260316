namespace MoviesConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
			if (args.Length > 0 && args[0] == "--stat")
			{
				Statisztika statisztika = new Statisztika();
				statisztika.ElsoFeladat();
				statisztika.MasodikFeladat();
				statisztika.HarmadikFeladat();
				statisztika.NegyedikFeladat();
				statisztika.OtodikFeladat();
				statisztika.HatodikFeladat();
			}
		}
    }
}
