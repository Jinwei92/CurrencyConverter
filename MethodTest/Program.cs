using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime endDate = DateTime.Now;
            List<DateTime> Dates = ObtainGapDates(endDate.AddDays(-30), endDate);
            foreach(DateTime date in Dates)
            {
                Console.WriteLine(date.ToString("yyyy-MM-dd"));
            }
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            Console.ReadKey();
            
        }
        private static List<DateTime> ObtainGapDates(DateTime start, DateTime end)
        {
            List<DateTime> Dates = new List<DateTime>();
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                Dates.Add(date);
            }
            return Dates;
        }
    }
}
