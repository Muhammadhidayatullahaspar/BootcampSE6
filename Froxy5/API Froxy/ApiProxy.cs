namespace API_Froxy;

public class ApiProxy : IApiService
{
    private readonly IApiService _apiService;

    public ApiProxy(IApiService apiService)
    {
        _apiService = apiService;
    }

    public string GetData()
    {
        // Contoh kontrol akses sederhana
        if (!UserHasAccess())
        {
            throw new UnauthorizedAccessException("Akses ditolak.");
        }

        // Logging sebelum memanggil API asli
        Console.WriteLine("Memanggil API...");

        // Panggil metode pada API asli
        var data = _apiService.GetData();

        // Logging setelah memanggil API
        Console.WriteLine("Panggilan API selesai.");

        return data;
    }

    private bool UserHasAccess()
    {
        // Implementasi kontrol akses (sederhana)
        // Di dunia nyata, ini akan lebih kompleks
        return false; // Semua user diizinkan untuk contoh ini
    }
}
