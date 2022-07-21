using System;

namespace QuizPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            int tens, units, sum;
            int result = 0;
            int cnt = 0;
            int n;
            string saveNum = "";


            do
            {
                Console.Write("입력(1~99) : ");
                n = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("입력된 값 : " + n);
                if (n <= 0 || n > 99) Console.WriteLine("범위 내의 수를 입력하세요.");
            } while (n <= 0 || n > 99);


            if (n < 10)
            {
                sum = n * 11;
                units = sum / 10;
                saveNum += sum;
            }
            else
            {
                sum = n;
                tens = sum / 10;
                units = sum % 10;
                sum = tens + units;
                
                result = (units * 10) + sum;
                saveNum += result;
            }
            

            
            while (result != n){
                cnt++;
                tens = units;
                units = sum % 10;
                sum = tens + units;
                if (cnt != 1)
                {
                    result = (tens * 10) + units;
                    saveNum += " " + result;
                }
            }
            Console.WriteLine(saveNum);
            Console.WriteLine("출력 : " + cnt);
            
        }
        
    }

    
}
