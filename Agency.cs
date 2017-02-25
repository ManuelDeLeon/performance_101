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
        public static HashSet<IDog> GetAllDogs()
        {
            var totalDogs = 9999;
            var totalFleas = 100;
            var dogs = new HashSet<IDog>();
            for (int i = 1; i <= totalDogs; i++)
            {
                var dogName = Rnd.Next(999).ToString();
                IDog dog = new Dog { Name = dogName };
                for(int h = 1; h <= totalFleas; h ++)
                {
                    var fleaName = Rnd.Next(99).ToString();
                    IFlea flea = new Flea { Name = fleaName };
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

        public static IDog DogToFind()
        {
            IDog toFind = new Dog { Name = "AAA" };
            toFind.AddFlea(new Flea { Name = "ZZ" });
            return toFind;
        }
    }
}
