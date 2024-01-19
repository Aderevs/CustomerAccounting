using System;

namespace CustomerAccounting
{

    internal struct TimeOfDay
    {
        private byte hours;
        private byte minutes;

        public TimeOfDay() { }
        public TimeOfDay(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }

        public byte Hours
        {
            get { return hours; }

            //prevent the hours value from overflowing
            set
            {
                if (value < 24)
                {
                    hours = value;
                }
                else
                {
                    throw new FormatException("hours out of range");
                }
            }
        }
        public int Minutes
        {
            get { return minutes; }

            //use Hours (property) to prevent the hours value from overflowing, but it is allowed to overflow the minutes value
            set
            {
                if (value < 60)
                {
                    minutes = (byte)value;
                }
                else
                {
                    if (hours + value / 60 < 24)
                    {
                        Hours += (byte)(value / 60);
                    }
                    else
                    {
                        Hours = (byte)(hours + value / 60);
                    }
                    minutes = (byte)(value % 60);
                }
            }
        }

        public static bool operator >=(TimeOfDay time1, TimeOfDay time2)
        {
            if (time1.hours != time2.hours)
            {
                return time1.hours >= time2.hours;
            }
            else
            {
                return time1.minutes >= time2.minutes;
            }
        }
        public static bool operator <=(TimeOfDay time1, TimeOfDay time2)
        {
            if (time1.hours != time2.hours)
            {
                return time1.hours <= time2.hours;
            }
            else
            {
                return time1.minutes <= time2.minutes;
            }
        }
        public static bool operator >(TimeOfDay time1, TimeOfDay time2)
        {
            if (time1.hours != time2.hours)
            {
                return time1.hours > time2.hours;
            }
            else
            {
                return time1.minutes > time2.minutes;
            }
        }
        public static bool operator <(TimeOfDay time1, TimeOfDay time2)
        {
            if (time1.hours != time2.hours)
            {
                return time1.hours < time2.hours;
            }
            else
            {
                return time1.minutes < time2.minutes;
            }
        }

        public override string ToString()
        {
            return $"{hours.ToString("00")}:{minutes.ToString("00")}";
        }
    }
}
