using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            DateModifier.DatesDifference(firstInput, secondInput);
        }
    }
}
