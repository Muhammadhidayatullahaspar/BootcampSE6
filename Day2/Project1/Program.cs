using Hewan;
class Program 
{
	static void Main() // utama
	{
		Cat kucing = new Cat("Blacky", 22, true); // buat kucing
		kucing.PrintAnimal(); // panggil printanimal pada kucing dimana itu di parent
		kucing.Eat(); // panggil eat di parent 
		kucing.Walk(); // panggil walk, dimana itu tidak terdapat pada parent
		Console.WriteLine(""); // biar ada spasi yang pisahkan
		
		Bird elang = new Bird("Elang", 11, true); // buat elang
		elang.PrintAnimal(); // panggil construcnya
		elang.Eat(); // panggil eat pada parent
		elang.Fly(); // panggil fly yang tidak terdapat pada parent
		Console.WriteLine(""); // biar ada spasi yang pisahkan
		
		Shark biru = new Shark("Biru", 5, false); // buat hiu
		biru.PrintAnimal(); // panggil construcnya
		biru.Eat(); // panggil fungsi yang ada pada parent
		biru.Swim(); // panggil fungsi yang tidak ada pada parent
		
	}
}