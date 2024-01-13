using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (queue[i].LeaveTime <customer.ArrivalTime)
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
                queue.Add(customer);
                leaving = timeLastCustomerStart;
                leaving.Minutes += ServeOneCustomerMinutes * queue.Count;
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
    }
}
