using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        public static String GetFormattedNumberString(int N)
        {
            String result = "N = " + N + ": ";
            for (int i = 0; i <= N; i++)
            {
                if ( i == N - 1)
                {
                    result += (i+1) + " .";
                    break;
                }

                result += (i + 1) + " , "; 
                
            }
           
            return result;
        }

        public static void PrintStars(int N)
        {
            
            if (N % 2 != 0 && N != 0 )
            {
                int center = N / 2; ;
                for (int i = 0; i < N; i++){
                    
                    
                  for (int j = 0; j < N; j++)
                  {
                        if (i == center && j == center)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("*");
                        }

                            


                  }
                        Console.WriteLine();
                    

                    




                }
                
            }
            else
            {
                Console.WriteLine("You wrote an even number. Try again!");
                return;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please input some number");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Which case dou you wanna check: 1 or 2?");
            String caseCheck = Console.ReadLine();
            if (caseCheck == "1" || caseCheck =="2" )
            {
                switch (caseCheck)
                {
                    case "1": Console.WriteLine(GetFormattedNumberString(N)); break;
                    case "2": PrintStars(N); break;
                    default: Console.WriteLine("Error! try again"); break;
                }
            }
            


            Console.ReadKey();
        }
    }
}
