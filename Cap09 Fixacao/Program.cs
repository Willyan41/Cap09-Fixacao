using Cap09_Fixacao.Entities;
using Cap09_Fixacao.Enums;
using System;
using System.Globalization;

namespace Cap09_Fixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter order data:");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());




            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantityProduct = int.Parse(Console.ReadLine());

                Product product = new Product(nameProduct, priceProduct);

                OrderItem orderItem = new OrderItem(quantityProduct, priceProduct, product);


                order.AddItems(orderItem);

            }

            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);

        }
    }
}
