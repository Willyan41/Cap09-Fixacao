using Cap09_Fixacao.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cap09_Fixacao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItems(OrderItem items)
        {
            Items.Add(items);
        }

        public void RemoveItems(OrderItem items)
        {
            Items.Remove(items);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem items in Items)
            {
                sum += items.SubTotal();

            }
            return sum;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());

            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();

        }

    }
}
