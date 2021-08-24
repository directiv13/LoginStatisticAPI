using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginStatistic
{
    public class DateTimeGenerator
    {
        private Random generator;
        private DateTime startTime = new DateTime(2016, 1, 1);
        private int start;
        private int end;
        private int step;
        public DateTimeGenerator()
        {
            generator = new Random();
            step = 1440;               //1 day in minutes 
            start = 0;   
        }
        public DateTime Next()
        {
            int days = generator.Next(0, 90);
            end = start + step * days;
            int minutes = generator.Next(start, end);
            start = end;

            DateTime result = startTime.AddMinutes(minutes);
            return result < DateTime.Now ? result : DateTime.Now;
        }
    }
}
