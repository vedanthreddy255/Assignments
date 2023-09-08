using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo1
{
    internal class Program
    {
        class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int UnitPrice { get; set; }

            public int Quantity { get; set; }
            public override string ToString()
            {
                string str = string.Format("{0},{1},{2},{3}", ProductId,ProductName,UnitPrice,Quantity);
                return str;
            }
        }
        static void Main(string[] args)
        {
          

            List<Product> products = new List<Product>();
            for(int i = 0; i < 5; i++)
            {
                Product objectName = new Product();
                Console.WriteLine("Enter Product Id:");
                objectName.ProductId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name:");
                objectName.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Unit Price:");
                objectName.UnitPrice = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Quantity:");
                objectName.Quantity = int.Parse(Console.ReadLine());
                products.Add(objectName);
            }

            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
            }

            Console.WriteLine("Enter a id to remove it:");
            int id=int.Parse(Console.ReadLine());
            int index = -1;
            for(int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductId ==id)
                {
                    index = i; break;
                }
            }
            products.RemoveAt(index);
            Console.ReadLine();

        }

    }
}
