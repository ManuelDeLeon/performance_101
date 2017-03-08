using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PetShop
{
    [TestFixture]
    public class FleaTests
    {
        [Test]
        public void are_not_equal__fleas_with_different_name()
        {
            Flea f = new Flea("Pete");
            Flea f2 = new Flea("Horace");

            Assert.AreNotEqual(f, f2);
            Assert.AreNotEqual(f.GetHashCode(), f2.GetHashCode());
        }

        [Test]
        public void are_equal__fleas_with_same_name()
        {
            Flea f = new Flea("pete");
            Flea f2 = new Flea("PETE");

            Assert.AreEqual(f, f2);
            Assert.IsTrue(f.Equals(f2));
            Assert.AreEqual(f.GetHashCode(), f2.GetHashCode());
        }

        [Test]
        public void are_equal__fleas_with_default_constructor()
        {
            Flea f = new Flea();
            Flea f2 = new Flea();

            Assert.AreEqual(f, f2);
            Assert.IsTrue(f.Equals(f2));
            Assert.AreEqual(f.GetHashCode(), f2.GetHashCode());
        }

        [Test]
        public void are_equal__hashset_with_same_fleas()
        {
            var fleas = new HashSet<Flea>(Flea.NameComparer)
            {
                new Flea("horace"), new Flea("pete")
            };

            var fleas2 = new HashSet<Flea>(Flea.NameComparer)
            {
                new Flea("horace"), new Flea("pete")
            };

            Assert.AreEqual(fleas, fleas2);
            Assert.IsTrue(fleas.SetEquals(fleas2));
        }

        [Test]
        public void are_not_equal__hashset_with_different_fleas()
        {
            var fleas = new HashSet<Flea>
            {
                new Flea("horace"), new Flea("pete")
            };

            var fleas2 = new HashSet<Flea>
            {
                new Flea("horace"), new Flea("uncle pete")
            };

            Assert.AreNotEqual(fleas, fleas2);
            Assert.IsFalse(fleas.SetEquals(fleas2));
            Assert.AreNotEqual(fleas.GetHashCode(), fleas2.GetHashCode());
        }

        [Test]
        public void is_true__hashset_contains_flea()
        {
            var fleas = new HashSet<Flea>
            {
                new Flea("horace"), new Flea("pete")
            };

            Assert.IsTrue(fleas.Contains(new Flea("horace")));
            Assert.IsTrue(fleas.Contains(new Flea("HORACE")));
        }

        [Test]
        public void is_true__hashset_contains_flea_using_name_flea_comparer()
        {
            var fleas = new HashSet<Flea>(Flea.NameComparer)
            {
                new Flea("horace"), new Flea("pete")
            };

            Assert.IsTrue(fleas.Contains(new Flea("horace")));
            Assert.IsTrue(fleas.Contains(new Flea("HORACE")));
        }

        [Test]
        public void are_equal__hashset_with_zero_fleas()
        {
            var fleas = new HashSet<Flea>(Flea.NameComparer);
            var fleas2 = new HashSet<Flea>(Flea.NameComparer);

            Assert.AreEqual(fleas, fleas2);
            Assert.IsTrue(fleas.SetEquals(fleas2));
        }

        [Test]
        public void are_equal__hashset_with_zero_fleas_from_dog()
        {
            Dog d = new Dog();
            Dog d2 = new Dog();
            
            Assert.AreEqual(d.Fleas, d2.Fleas);
            Assert.IsTrue(d.Fleas.SetEquals(d2.Fleas));
        }
    }

    [TestFixture]
    public class DogTests
    {
        [Test]
        public void Test()
        {
            Dog d = Agency.DogToFind();
            Console.WriteLine(d.GetHashCode());
            var dogs = new HashSet<Dog> {d};

            var dog = Agency.DogToFind();
            Console.WriteLine(dog.GetHashCode());
            Assert.IsTrue(dogs.Contains(dog));
        }

        [Test]
        public void are_not_equal__dogs_with_different_name()
        {
            Dog pete = new Dog("Pete");
            Dog horace = new Dog("Horace");

            Assert.AreNotEqual(horace, pete);
        }

        [Test]
        public void are_not_equal__hashset_with_different_dogs()
        {
            var dogs = new HashSet<Dog>
            {
                new Dog("horace"), new Dog("pete")
            };

            var dogs2 = new HashSet<Dog>
            {
                new Dog("horace"), new Dog("uncle pete")
            };

            Assert.AreNotEqual(dogs, dogs2);
        }

        [Test]
        public void are_equal__dogs_with_same_name()
        {
            Dog pete = new Dog("pete", new HashSet<Flea> { new Flea("horace"), new Flea("uncle pete") });
            Dog pete2 = new Dog("PETE", new HashSet<Flea> { new Flea("horace"), new Flea("uncle pete") });

            Assert.AreEqual(pete2, pete);
        }

        [Test]
        public void are_equal__dogs_with_default_constructor()
        {
            Dog d = new Dog();
            Dog d2 = new Dog();

            Assert.AreEqual(d, d2);
        }

        [Test]
        public void are_equal__hashset_with_same_dogs()
        {
            var dogs = new HashSet<Dog>
            {
                new Dog("horace"), new Dog("pete")
            };

            var dogs2 = new HashSet<Dog>
            {
                new Dog("horace"), new Dog("pete")
            };

            Assert.AreEqual(dogs, dogs2);
            Assert.IsTrue(dogs.SetEquals(dogs2));
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
    }
}
