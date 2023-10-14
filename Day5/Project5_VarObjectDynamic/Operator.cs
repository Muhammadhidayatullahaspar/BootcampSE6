namespace Project5_VarObjectDynamic;

public class Food // kelas food
{
	
}

public class Calculator
{
	
	public void Operator(object x, object y) // tipe data object
	{
		if (x is int && y is int)
		{
			int a = (int)x;
			int b = (int)y;
			Console.WriteLine($"Hasil penjumlahan dua buah bilangan {a} dan {b} tersebut adalah  { a + b }"); // fungsi keluarkan nilai 
			Console.WriteLine($"Hasil pengurangan dua buah bilangan {a} dan {b} tersebut adalah  { a - b }"); // keluarkan nilai hasil operator
		}
		else
		{
			Console.WriteLine("Tidak dapat diproses"); // jika nilai yang dimasukkan bukan int
		}
	}

}