using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Concept
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            IBasicConcept obj = new BasicProgram();
           // obj.Pallindrom();
            var result = obj.Pallindrom(12215);
            Console.WriteLine("Pallindrom result : " + result);
           // b.FibnocciSerires();
            Console.ReadLine();
        }
    }
}
