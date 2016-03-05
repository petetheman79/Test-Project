using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Program Calculates the result of two numbers");

            Console.WriteLine("Enter Number 1: ");
            var number1String = Console.ReadLine();
            var number1 = 0;
            int.TryParse(number1String, out number1);

            Console.WriteLine("Enter Number 2: ");
            var number2String = Console.ReadLine();
            var number2 = 0;
            int.TryParse(number2String, out number2);


            var calculator = new Calculator();
            int result = calculator.Sum(number1, number2);

            Console.WriteLine(string.Format("Result is: {0}", result.ToString()));
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
