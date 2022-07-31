using System;

namespace LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("입력 : ");
            string str = Console.ReadLine();
            int year = Convert.ToInt32(str);
            int result = 0;

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) result = 1;

            Console.WriteLine("결과 : " + result);
        }
    }
}
