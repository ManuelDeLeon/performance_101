using System;
using BenchmarkDotNet.Running;
using NUnit.Framework;

namespace PetShop
{
    [TestFixture]
    class PetShopTests
    {
        [Test]
        public void Run()
        {
            // See how long the process takes
            Agency.RunAndPrintTime();

            // // Useful for profiling 
            // // (no need to press any key, it goes straight to the report)
            // Agency.RunAndQuit();

            // // See the average time it takes, after optimizing Dog & Flea
            // Agency.PrintAverage(10);
        }

        //[Test]
        public void Benchmark()
        {
            var summary = BenchmarkRunner.Run<Agency>();

            //Console.WriteLine(summary.);
        }
    }
}
