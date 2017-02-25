using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<IDog> dogs = Agency.GetAllDogs();

            var toFind = Agency.DogToFind();
            if (!dogs.Contains(toFind))
            {
                throw new Exception("Can't find the dog. Please try again.");
            }
        }
    }
}
