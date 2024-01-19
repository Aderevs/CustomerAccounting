using System;
using System.Collections.Generic;

namespace CustomerAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barbershop barbershop = new Barbershop();
            string inputFilePath = "E:\\CyberByonicSystematics\\TermProjects\\Essential.Console\\CustomerAccounting\\input.txt";
            try
            {
                List<Customer> inputCustomers = new List<Customer>(barbershop.ReadCustomersFromFileTxt(inputFilePath));
                foreach (var customer in inputCustomers)
                {
                    barbershop.CustomerArrive(customer);
                }
                var outputCustomers = barbershop.TodayCustomers;

                foreach (var customer in outputCustomers)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
