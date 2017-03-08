using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace PetShop
{
    public class Agency
    {
        static readonly Random Rnd = new Random();
        static HashSet<Dog> GetAllDogs()
        {
            int totalDogs = 999;
            int totalFleas = 1000;

            var dogs = new HashSet<Dog>();

            for (int i = 1; i <= totalDogs; i++)
            {
                string dogName = Rnd.Next(totalDogs).ToString();
                Dog dog = new Dog(dogName);

                for (int h = 1; h <= totalFleas; h++)
                {
                    var fleaName = Rnd.Next(totalFleas).ToString();
                    Flea flea = new Flea(fleaName);
                    dog.AddFlea(flea);
                }

                if (!dogs.Contains(dog))
                {
                    dogs.Add(dog);
                }
            }

            Dog toFind = DogToFind();
            dogs.Add(toFind);

            return dogs;
        }

        public static Dog DogToFind()
        {
            Dog toFind = new Dog("AAA");
            toFind.AddFlea(new Flea("ZZ"));
            return toFind;
        }

        public static void PrintAverage(int times)
        {
            var totalTimes = new List<double>();
            for(int i = 1; i <= times; i++)
            {
                var start = Stopwatch.StartNew();
                RunAndQuit();
                start.Stop();
                var totalSeconds = start.ElapsedMilliseconds;
                totalTimes.Add(totalSeconds);
            }
            var averageTime = totalTimes.Average();
            Console.WriteLine("Average in seconds: " + averageTime);
            Console.WriteLine("");
            Console.WriteLine("Press any key...");
            //Console.ReadKey();
        }
        public static void RunAndQuit()
        {
            HashSet<Dog> dogs = GetAllDogs();

            Dog toFind = DogToFind();

            if (!dogs.Contains(toFind))
            {
                throw new Exception("Can't find the dog. Please try again.");
            }
        }

        [Benchmark]
        public static void RunAndPrintTime()
        {
            PrintAverage(1);
        }
    }
}
