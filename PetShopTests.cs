using System;
using BenchmarkDotNet.Running;
using NUnit.Framework;

namespace PetShop
{
    [TestFixture]
    public class FleaTests
    {
        [Test]
        public void are_not_equal__fleas_with_different_name()
        {
            Flea pete = new Flea("Pete");
            Flea horace = new Flea("Horace");

            Assert.AreNotEqual(horace, pete);
        }

        [Test]
        public void are_equal__fleas_with_same_name()
        {
            Flea pete = new Flea("pete");
            Flea pete2 = new Flea("PETE");

            Assert.AreEqual(pete2, pete);
        }

        [Test]
        public void are_equal__fleas_with_default_constructor()
        {
            Flea f = new Flea();
            Flea f2 = new Flea();

            Assert.AreEqual(f, f2);
        }
    }

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
