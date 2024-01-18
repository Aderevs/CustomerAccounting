using System;

namespace CustomerAccounting
{
    internal class Customer
    {
        private byte patience;
        private TimeOfDay arrivalTime;
        private TimeOfDay leaveTime;

        public Customer(TimeOfDay arrivalTime, byte patience)
        {
            Patience = patience;
            this.arrivalTime = arrivalTime;
        }

        public byte Patience
        {
            get { return patience; }
            set
            {
                if (value <= 100)
                {
                    patience = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("patient cant be more than 100");
                }
            }
        }

        public TimeOfDay ArrivalTime
        {
            get { return arrivalTime; }
        }
        public TimeOfDay LeaveTime
        {
            get { return leaveTime; }
            set
            {
                if (value >= arrivalTime)
                {
                    leaveTime = value;
                }
                else
                {
                    throw new ArgumentException("leaving time cant be earlyer than arrival time");
                }
            }
        }
        public override string ToString()
        {
            string customerInfo = $"Arrival time: {arrivalTime}\tLeave time: {leaveTime}";
            return customerInfo;
        }

    }
}
