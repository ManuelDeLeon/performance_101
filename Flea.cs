using System;
using System.Collections.Generic;

namespace PetShop
{
    public class Flea : IEquatable<Flea>
    {
        public Flea() { }

        public Flea(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Flea other)
        {
            return string.Equals(Name, other?.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Flea) obj);
        }

        public override int GetHashCode()
        {
            int hashcode = Name?.ToLower().GetHashCode() ?? 0;

            return hashcode;
        }

        private sealed class NameEqualityComparer : IEqualityComparer<Flea>
        {
            public bool Equals(Flea x, Flea y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
            }

            public int GetHashCode(Flea obj)
            {
                int hashcode = obj.Name?.ToLower().GetHashCode() ?? 0;

                return hashcode;
            }
        }

        public static IEqualityComparer<Flea> NameComparer { get; } = new NameEqualityComparer();
    }
}
