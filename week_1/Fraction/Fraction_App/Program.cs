using System.Collections;

namespace Fraction_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction = new Fraction(2, 5);

            var fractionsHashtable = new Hashtable()
            {
                {2, 3}
            };

            foreach (var pair in fractionsHashtable)
                Console.WriteLine("Key: {0}, Value: {1}", pair.ToString(), pair.GetHashCode());

            var fractionsDictionary = new Dictionary<int, Fraction>()
            {
                {1, fraction},
            };

            foreach(var pair in fractionsDictionary)
                Console.WriteLine(pair.ToString(), pair.GetHashCode());

            var fractionsHeshSet = new HashSet<Fraction>()
            {
                new Fraction(2, 5),
                new Fraction(1, 6),
            };

            foreach (var pair in fractionsHeshSet)
                Console.WriteLine(pair.GetHashCode());
        }
    }
}

