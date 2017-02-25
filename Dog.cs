using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Dog : IDog
    {
        private List<IFlea> Fleas = new List<IFlea>();
        public void AddFlea(IFlea flea)
        {
            var fleaExists = false;
            foreach(var f in Fleas)
            {
                if (f.Name == flea.Name)
                {
                    fleaExists = true;
                }
            }
            if (!fleaExists)
            {
                Fleas.Add(flea);
            }
        }

        public string Name { get; set; }

        public override bool Equals(object other)
        {
            var otherDog = other as Dog;
            if (otherDog == null) return false;
            return
                FleasAreEqual(this.Fleas, otherDog.Fleas)
                && this.Name == otherDog.Name;
        }

        private bool FleasAreEqual(List<IFlea> fleas1, List<IFlea> fleas2)
        {
            var areEqual = true;
            
            foreach (var flea1 in fleas1)
            {
                var foundInSecond = false;
                foreach (var flea2 in fleas2)
                {
                    if (flea1.Name == flea2.Name)
                    {
                        foundInSecond = true;
                    }
                }
                if (areEqual && !foundInSecond)
                {
                    areEqual = false;
                }
            }

            return areEqual;
        }

        public override int GetHashCode()
        {
            var fleas = this.Fleas
                    .OrderBy(flea => flea.Name)
                    .Select(flea => flea.Name)
                    .Aggregate((finalStr, itemStr) => finalStr + "-" + itemStr);
            return (fleas + "-" + this.Name).GetHashCode();

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
