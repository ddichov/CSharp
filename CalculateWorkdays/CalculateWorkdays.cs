using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace _05.CalculateWorkdays
{
    class CalculateWorkdays
    {
        private static DateTime InputDate()
        {
            DateTime date2;
            string dateStr;
            do
            {
                Console.Write("Enter future date 'yyyy-MM-dd' : ");
                dateStr = Console.ReadLine();
            } while (DateTime.TryParseExact(dateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date2) == false);
            return date2;
        }

        private static int CountWorkdays(ref DateTime today, DateTime fdate, DateTime[] holidays)
        {
            int counter = 0;
            while (fdate >= today)
            {
                bool isHoliday = false;
                for (int i = 0; i < holidays.Length; i++)
                {
                    if (today.Month == holidays[i].Month && today.Day == holidays[i].Day)
                    {
                        isHoliday = true;
                        break;
                    }
                }
                if (today.DayOfWeek.ToString() != "Sunday" && today.DayOfWeek.ToString() != "Saturday" && !isHoliday)
                {
                    counter++;
                }
                today = today.AddDays(1);
            }
            return counter;
        }



        static void Main()
        {
            Console.WriteLine("This program calculates the number of workdays between today and given date, passed as parameter. \n ");

            DateTime today = DateTime.Now;
            DateTime fdate = InputDate();

            DateTime[] holidays = new DateTime[]
            {
                new DateTime( 2013,01,01),
                new DateTime( 2013,02,25),
                new DateTime( 2013,03,08),
                new DateTime( 2013,04,28),
                new DateTime( 2013,05,06),
                new DateTime( 2013,06,01),
                new DateTime( 2013,07,25),
                new DateTime( 2013,08,08),
                new DateTime( 2013,09,06),
                new DateTime( 2013,10,01),
                new DateTime( 2013,11,25),
                new DateTime( 2013,12,24),
                new DateTime( 2013,12,25),
            };

            Console.WriteLine("\nThere are {0} workdays!\n",CountWorkdays(ref today, fdate, holidays));

        }


      
    }
}
