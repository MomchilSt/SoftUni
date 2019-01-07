using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public static void DatesDifference(string firstInput, string secondInput)
        {
            int[] dateOne = firstInput.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] dateTwo = secondInput.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime firstDate = new DateTime(dateOne[0], dateOne[1], dateOne[2]);
            DateTime secondDate = new DateTime(dateTwo[0], dateTwo[1], dateTwo[2]);

            TimeSpan difference = firstDate.Subtract(secondDate);
            Console.WriteLine(Math.Abs(difference.TotalDays));
        }
    }
}
