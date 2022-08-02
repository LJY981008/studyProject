using System;
using System.IO;

namespace RecursiveStar
{
    class Program
    {
       
        static void Bound(int row, int col, int n)
        {

            if (n == 3)
            {
                if (row % n == 1 && col % n == 1) Console.Write(" ");
                else Console.Write("*");
            }
            else if ((row / (n / 3)) % 3 == 1 && (col / (n / 3)) % 3 == 1) Console.Write(" ");
            else Bound(row, col, n / 3);
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("1~7의 수 입력 : ");
            int k = int.Parse(Console.ReadLine());

            if (0 < k && k < 8)
            {
                int num = (int)Math.Pow(3, k);
                Console.WriteLine("값 : " + num);
                for(int i = 0; i < num; i++)
                {
                    for(int j = 0; j < num; j++)
                    {
                        Bound(i, j, num);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("범위안의 수를 입력해 주세요.");
            }

        }
        
        
    }
}
