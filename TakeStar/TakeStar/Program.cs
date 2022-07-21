using System;

namespace TakeStar
{
    class Program
    {
        static void Main(string[] args)
        {
            //별찍기 1
            /*Console.Write("층 입력 : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }*/

            //별찍기 2
            Console.Write("층 입력 : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < i+1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
