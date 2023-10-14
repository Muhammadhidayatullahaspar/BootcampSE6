using Project5_VarObjectDynamic;
class program

{
	static void Main()
	{
		Console.WriteLine("");
		var nilai1 = 4;
		nilai1 = int.Parse("3"); // ubah nilai 4 jadi int 3
		Console.WriteLine(nilai1);
		Console.WriteLine("");
		
		int nilai2 = 5;
		Out output = new();
		output.Print(3);
		Console.WriteLine("");
		
		int nilai3 = 9;
		object obj = nilai3; // nilai3 yang berisi integer dibungkus dengan objecty
		float result = (int)obj; // unboxing obj, harus dibuka sesuai tipe data sebelumnya
		output.Print(result); // method yang mengeluarkan hasilnya
		Console.WriteLine("");
		
		output.Print("a");
		output.Print(true);
		output.Print(3.0f);
		output.Print(false); // print
		output.Print(3.5M);
		Console.WriteLine("");
		
		Calculator calc = new Calculator(); // construct method kalkulator yang dibuat di kelas kalkulator
		calc.Operator(5,2);
		calc.Operator(nilai1,nilai2);
		calc.Operator(new Food(), new Food()); // kelas tidak dapat di proses
		
	}
}
