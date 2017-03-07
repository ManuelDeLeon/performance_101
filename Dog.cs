using System.Collections.Generic;
using System.Linq;

namespace PetShop
{
    public class Dog
    {
        private readonly List<Flea> _fleas = new List<Flea>();

        public void AddFlea(Flea flea)
        {
            var fleaExists = false;
            foreach(var f in _fleas)
            {
                if (f.Name == flea.Name)
                {
                    fleaExists = true;
                }
            }
            if (!fleaExists)
            {
                _fleas.Add(flea);
            }
        }

        public string Name { get; set; }

        public override bool Equals(object other)
        {
            var otherDog = other as Dog;
            if (otherDog == null) return false;
            return
                FleasAreEqual(this._fleas, otherDog._fleas)
                && this.Name == otherDog.Name;
        }

        private bool FleasAreEqual(List<Flea> fleas1, List<Flea> fleas2)
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
            var fleas = this._fleas
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
