namespace LaptopsCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Laptop> laptopok = new();

            foreach (var item in File.ReadAllLines(@"..\..\..\src\laptops.txt").Skip(1))
            {
                laptopok.Add(new Laptop(item));
            }

            foreach (var item in laptopok)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
