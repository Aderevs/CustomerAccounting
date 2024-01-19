using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerAccounting
{
    internal class Barbershop
    {
        private TimeOfDay timeLastCustomerStart;
        private List<Customer> queue;
        private List<Customer> todayCustomers;
        private bool isBarberfree;
        private const int ServeOneCustomerMinutes = 20;

        public Barbershop()
        {
            queue = new List<Customer>();
            todayCustomers = new List<Customer>();
            isBarberfree = true;
        }
        public List<Customer> TodayCustomers
        {
            get { return todayCustomers; }
        }

        public void CustomerArrive(Customer customer)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].LeaveTime <= customer.ArrivalTime)
                {
                    CustomerLeave(queue[i]);
                    i--;
                }
            }
            if (isBarberfree)
            {
                isBarberfree = false;
                timeLastCustomerStart = customer.ArrivalTime;
            }
            TimeOfDay leaving = customer.ArrivalTime;
            if (customer.Patience >= queue.Count)
            {
                try
                {
                    queue.Add(customer);
                    leaving = timeLastCustomerStart;
                    leaving.Minutes += ServeOneCustomerMinutes * queue.Count;
                }
                catch (FormatException)
                {
                    queue.Remove(customer);
                    leaving = customer.ArrivalTime;
                }
            }
            customer.LeaveTime = leaving;
            todayCustomers.Add(customer);
        }
        private void CustomerLeave(Customer customer)
        {
            queue.Remove(customer);
            if (queue.Count > 0)
            {
                timeLastCustomerStart = customer.LeaveTime;
            }
            else
            {
                isBarberfree = true;
            }
        }

        public Customer[] ReadCustomersFromFileTxt(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int counter = 0;
                int numberOfCustomers;
                Customer[] customers;
                string line;
                string[] splitValues;
                byte arrivalHours, arrivalMinutes, patienceValue;

                if (int.TryParse(reader.ReadLine(), out numberOfCustomers))
                {
                    customers = new Customer[numberOfCustomers];
                }
                else
                {
                    throw new FormatException("invalid format in 1 line of input file");
                }

                while ((line = reader.ReadLine()) != null)
                {
                    splitValues = line.Split(' ');

                    if (splitValues.Length == 3)
                    {
                        if (byte.TryParse(splitValues[0], out arrivalHours) &&
                            byte.TryParse(splitValues[1], out arrivalMinutes) &&
                            byte.TryParse(splitValues[2], out patienceValue))
                        {
                            customers[counter] = new Customer(new TimeOfDay(arrivalHours, arrivalMinutes), patienceValue);
                        }
                        else
                        {
                            throw new FormatException($"invalid format in {counter + 1} line of inout file");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("It wasn't possible to obtain the required values for three variables");
                    }
                    counter++;
                }
                return customers;
            }
        }
    }
}
