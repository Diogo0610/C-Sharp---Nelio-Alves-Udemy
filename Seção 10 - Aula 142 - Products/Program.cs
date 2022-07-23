namespace Products
{
    using Products.Entities;
    using System.Globalization;
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            Console.Write("Enter the number of products: ");
            int numProd = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numProd; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char productStatus = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (productStatus)
                {
                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime manufactDate = DateTime.Parse(Console.ReadLine());
                        list.Add(new UsedProduct(name, price, manufactDate));
                        break;
                    case 'i':
                        Console.Write("Customs Fee: ");
                        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        list.Add(new ImportedProduct(name, price, customsFee));
                        break;
                    default:
                        list.Add(new Product(name, price));
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}