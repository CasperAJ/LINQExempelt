using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LINQExample
{

    public static class MyLinq
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collection, Func<T, bool> cond)
        {
            foreach (var elem in collection)
            {
                if (cond(elem))
                {
                    yield return elem;
                }
            }
        }

        public static IEnumerable<R> MySelect<T, R>(this IEnumerable<T> collection, Func<T, R> selector)
        {
            foreach (var elem in collection)
            {
                yield return selector(elem);
            }
        }

        public static IEnumerable<T> MyDistinct<T>(this IEnumerable<T> collection)
        {
            var seen = new HashSet<T>();
            foreach (var elem in collection)
            {
                if (seen.Contains(elem)==false)
                {
                    yield return elem;
                    seen.Add(elem);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var data = new[]
            {
                new {Name = "Priscilla Woods", Age = 40, Email = "metus@vitaerisus.org", ID = 1},
                new {Name = "Holmes Macdonald", Age = 20, Email = "Fusce.mi@egestasDuisac.org", ID = 2},
                new {Name = "Erich Solis", Age = 44, Email = "nisl.Maecenas.malesuada@sedestNunc.co.uk", ID = 3},
                new {Name = "Nehru Daniel", Age = 31, Email = "Integer@facilisis.net", ID = 4},
                new {Name = "Gareth Sharp", Age = 41, Email = "sit@necmauris.ca", ID = 5},
                new {Name = "Piper Gallagher", Age = 38, Email = "malesuada@auctor.com", ID = 6},
                new {Name = "Ivy Tyler", Age = 43, Email = "ac@massa.org", ID = 7},
                new {Name = "Cairo Spence", Age = 45, Email = "Phasellus.in.felis@etmagnisdis.com", ID = 8},
                new {Name = "Rafael Hammond", Age = 34, Email = "tempor@habitantmorbitristique.com", ID = 9},
                new {Name = "Timon Ruiz", Age = 35, Email = "mi@pede.com", ID = 10},
                new {Name = "Fatima Burns", Age = 25, Email = "posuere@inmagnaPhasellus.edu", ID = 11},
                new {Name = "Chastity Nelson", Age = 41, Email = "lacinia.Sed@non.org", ID = 12},
                new {Name = "Jason Farley", Age = 33, Email = "feugiat.Lorem.ipsum@dictumeleifend.com", ID = 13},
                new {Name = "Xenos Huff", Age = 35, Email = "egestas@nasceturridiculus.co.uk", ID = 14},
                new {Name = "Luke Charles", Age = 22, Email = "Aliquam@hendrerit.co.uk", ID = 15},
                new {Name = "Sean Lawson", Age = 25, Email = "arcu.iaculis@cursus.ca", ID = 16},
                new {Name = "Janna Sykes", Age = 42, Email = "ipsum.primis@famesac.org", ID = 17},
                new {Name = "Charity Heath", Age = 31, Email = "dui@etpedeNunc.co.uk", ID = 18},
                new {Name = "Hammett Hebert", Age = 22, Email = "et@urnaVivamus.edu", ID = 19},
                new {Name = "Timon Marsh", Age = 50, Email = "est@augueid.ca", ID = 20},
                new {Name = "Hop Baker", Age = 48, Email = "In.at@malesuadafringilla.net", ID = 21},
                new {Name = "Peter Dennis", Age = 32, Email = "Ut.nec@ultricies.com", ID = 22},
                new {Name = "Brittany Riley", Age = 46, Email = "lectus.Nullam@dolorDonecfringilla.ca", ID = 23},
                new {Name = "Julian Doyle", Age = 41, Email = "In@libero.ca", ID = 24}
            };
            // First test on LINQ programming
            var number = Enumerable.Range(1, 5);
                    // LINQ below  // Lambda below
            //var q = number.Where  (x => x % 2 == 0);

            // Select x's id and x's name from data where x's age is above 35
            var q = data
                .MyWhere(x => x.Age > 35)
                .MySelect(x => new {Id = x.ID, x.Name})
                .OrderBy(x => x.Name);


            foreach (var i in data
                .Where(x=> x.Age>35)
                .Select(x=> new { Id = x.ID, x.Name}))
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
