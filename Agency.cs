using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Agency
    {
        static readonly Random Rnd = new Random();
        static HashSet<Dog> GetAllDogs()
        {
            var totalDogs = 999;
            var totalFleas = 1000;
            var dogs = new HashSet<Dog>();
            for (int i = 1; i <= totalDogs; i++)
            {
                var dogName = Rnd.Next(totalDogs).ToString();
                Dog dog = new Dog { Name = dogName };
                for(int h = 1; h <= totalFleas; h ++)
                {
                    var fleaName = Rnd.Next(totalFleas).ToString();
                    Flea flea = new Flea { Name = fleaName };
                    dog.AddFlea(flea);
                }
                dogs.Add(dog);
            }

            var toFind = DogToFind();
            dogs.Add(toFind);
            return dogs;
        }

        static Dog DogToFind()
        {
            Dog toFind = new Dog { Name = "AAA" };
            toFind.AddFlea(new Flea { Name = "ZZ" });
            return toFind;
        }

        public static void PrintAverage(int times)
        {
            var totalTimes = new List<double>();
            for(int i = 1; i <= times; i++)
            {
                var start = DateTime.Now;
                RunAndQuit();
                var end = DateTime.Now;
                var totalSeconds = (end - start).TotalSeconds;
                totalTimes.Add(totalSeconds);
            }
            var averageTime = totalTimes.Average();
            Console.WriteLine("Average in seconds: " + averageTime);
            Console.WriteLine("");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
        public static void RunAndQuit()
        {
            HashSet<Dog> dogs = Agency.GetAllDogs();

            var toFind = Agency.DogToFind();
            if (!dogs.Contains(toFind))
            {
                Console.WriteLine("Can't find one of the dogs. Something's wrong with the code.\n");
            }
            var flea1 = new Flea { Name = "xqzrbn" };
            var flea2 = new Flea { Name = "xqzrbn" };
            var flea3 = new Flea { Name = "krumld" };

            if (typeof(Flea).GetMethod("Equals").DeclaringType == typeof(Flea))
            {
                if (!flea1.Equals(flea2) || flea1.Equals(flea3))
                {
                    Console.WriteLine("Flea equality doesn't work.\nTwo fleas are the same if they have the same name.\n");
                }
            }

            var dog1 = new Dog { Name = "xqzrbn" };
            dog1.AddFlea(flea1);
            var dog2 = new Dog { Name = "xqzrbn" };
            dog2.AddFlea(flea2);
            var dog3 = new Dog { Name = "krumld" };
            dog3.AddFlea(flea2);
            var dog4 = new Dog { Name = "xqzrbn" };
            dog4.AddFlea(flea3);
            if (!dog1.Equals(dog2) || dog1.Equals(dog3) || dog1.Equals(dog4))
            {
                Console.WriteLine("Dog equality doesn't work.\nTwo dogs are the same if they have the same name and they have the same fleas (regardless of the order).\n");
            }
        }

        public static void RunAndPrintTime()
        {
            PrintAverage(1);
        }
    }
}
