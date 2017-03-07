using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Agency>();

            // See how long the process takes
            //Agency.RunAndPrintTime();

            // // Useful for profiling 
            // // (no need to press any key, it goes straight to the report)
            // Agency.RunAndQuit();

            // // See the average time it takes, after optimizing Dog & Flea
            // Agency.PrintAverage(10);
        }
    }
}
