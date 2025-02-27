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

            Console.WriteLine("5. feladat - Kiírás");
            for (int i = 0; i < laptopok.Count; i++)
            {
                Console.WriteLine($"{i+1} {laptopok[i]} | {laptopok[i].Price * 4.12} HUF");
            }

            Console.WriteLine("6. feladat - Keresés");

            var i7ProcvagySSDLaptopok = laptopok.Where(l => l.CPU.Contains("Intel Core i7") && l.Storage.Contains("SSD"));

            for (int i = 0; i < laptopok.Count; i++)
            {
                Console.WriteLine($"[{i+1}] {laptopok[i]}");
            }

            Console.WriteLine($"A laptopok átlagára: {i7ProcvagySSDLaptopok.Average(i => i.Price)} INR");

            Console.WriteLine("7. feladat: Fájlba írás");

            using StreamWriter sw = new(@"..\..\..\src\cheap.txt");
            var legolcsobbGamingLaptopok = laptopok.Where(l => l.Category.CategoryName == "Gaming").OrderBy(l => l.Price).Take(20);

            foreach (var item in legolcsobbGamingLaptopok)
            {
                sw.WriteLine($"{item.Manufacturer.ManufacturerName} {item.Model}");
                sw.WriteLine($"\t{item.CPU}");
                sw.WriteLine($"\t{item.Storage}");
                sw.WriteLine($"\t{item.Screen}");
                sw.WriteLine("\n");
            }

            Console.ReadKey();
        }
    }
}
