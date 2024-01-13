using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> inputCustomers = new List<Customer>();
            Barbershop barbershop = new Barbershop();
            inputCustomers.Add(new Customer(new TimeOfDay(8, 0), 3));
            inputCustomers.Add(new Customer(new TimeOfDay(8, 3), 5));
            inputCustomers.Add(new Customer(new TimeOfDay(8, 4), 1));
            inputCustomers.Add(new Customer(new TimeOfDay(9, 30), 4));
            inputCustomers.Add(new Customer(new TimeOfDay(12, 40), 90));

            foreach (var customer in inputCustomers)
            {
                barbershop.CustomerArrive(customer);
            }
            var outputCustomers = barbershop.TodayCustomers;
            Console.WriteLine("-----------------------------------\n\n\n\n");
            foreach (var customer in outputCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
