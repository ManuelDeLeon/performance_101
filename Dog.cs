using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop
{
    public class Dog
    {
        public readonly HashSet<Flea> Fleas = new HashSet<Flea>(Flea.NameComparer);

        public Dog() { }

        public Dog(string name)
        {
            Name = name;
        }

        public Dog(string name, HashSet<Flea> fleas) : this(name)
        {
            Fleas = fleas;
        }

        public void AddFlea(Flea flea)
        {
            Fleas.Add(flea);
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Dog)obj);
        }

        private bool Equals(Dog other)
        {
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) && Fleas.SetEquals(other.Fleas);
        }

        public override int GetHashCode()
        {
            // wow, this implemention of GetHashCode improves significantly improves performance 
            return string.Join("-", Fleas.Select(flea => flea.Name), Name).GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
