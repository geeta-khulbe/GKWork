using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Concept
{
    internal class BasicProgram : IBasicConcept
    {
        public void FibnocciSerires()
        {
            //0,1,1,2,3,5,8,13
            int val1 = 0;
            int val2= 1;
            int val3= 0;
            Console.WriteLine("Fibonacci series:");
            Console.Write(val1 + " " + val2 + " ");
            for (int i = 2; i < 15; i++)
            {
                val3 = val1 + val2;
                Console.Write(val3 + "  ");
                val1 = val2; // 2
                val2 = val3;


            }
           //hrow new NotImplementedException();
        }

        public void Pallindrom()
        {
            //string palDrom = "MALAYALAM";
            //MALAYALAM
            Console.WriteLine("Write the String");
            string palDrom = Console.ReadLine();
            int len = palDrom.Length;
            string reverseString = string.Empty;
            for(int i = len - 1; i >= 0;i--)
            {
                reverseString += palDrom[i];
            }
            Console.WriteLine(reverseString);

            //throw new NotImplementedException();
        }

        public bool Pallindrom(int number)
        {
            //66677666  4534
            int num = number;
            
            int  qus, sum = 0 , reminder = 0;
            while(number >  0 )
            {
                reminder = number % 10;

                sum = sum * 10 + reminder;

                number = number / 10;
             }

            if (sum == num)
                return true;
            else
                return false;
        }
    }
}
