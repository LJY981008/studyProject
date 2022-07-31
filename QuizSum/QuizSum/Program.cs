using System;

namespace QuizSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("입력 1 : ");
            string str1 = Console.ReadLine();

            Console.Write("입력 2 : ");
            string str2 = Console.ReadLine();

            int n1 = Convert.ToInt32(str1);
            int n2 = Convert.ToInt32(str2);

            int sum = 0;

            for(int i = 0; i < n1; i++)
            {
                sum += (n2 % 10);
                n2 /= 10;
            }

            Console.WriteLine("출력"+sum);

        }
    }
}
