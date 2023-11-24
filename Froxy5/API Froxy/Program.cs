using API_Froxy;
class Program
{
	static void Main(string[] args)
	{
		IApiService apiService = new ApiService();
		IApiService apiProxy = new ApiProxy(apiService);

		try
		{
			var data = apiProxy.GetData();
			Console.WriteLine($"Data diterima: {data}");
		}
		catch (UnauthorizedAccessException ex)
		{
			Console.WriteLine($"Error: {ex.Message}");
		}
	}
}
