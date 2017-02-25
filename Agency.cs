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
        public static HashSet<Dog> GetAllDogs()
        {
            var totalDogs = 999;
            var totalFleas = 10000;
            var dogs = new HashSet<Dog>();
            for (int i = 1; i <= totalDogs; i++)
            {
                var dogName = Rnd.Next(999).ToString();
                Dog dog = new Dog { Name = dogName };
                for(int h = 1; h <= totalFleas; h ++)
                {
                    var fleaName = Rnd.Next(99).ToString();
                    Flea flea = new Flea { Name = fleaName };
                    dog.AddFlea(flea);
                }
                if (!dogs.Contains(dog))
                {
                    dogs.Add(dog);
                }
            }

            var toFind = DogToFind();
            dogs.Add(toFind);
            return dogs;
        }

        public static Dog DogToFind()
        {
            Dog toFind = new Dog { Name = "AAA" };
            toFind.AddFlea(new Flea { Name = "ZZ" });
            return toFind;
        }
    }
}
