public delegate void Film(string name);
class program
{
	static void Main()
	
	{
		TvProject project = new TvProject();
	}
	
		public class TvProject
		{
			private Film _film;
			public void AddFilm(Film add)
			{
				if(!_film.GetInvocationList().Contains(add)) 
				{
					_film += add;
				}
			}
			public void EndFilm()
			{
				_film?.Invoke("namafilm");
			}
		}
}