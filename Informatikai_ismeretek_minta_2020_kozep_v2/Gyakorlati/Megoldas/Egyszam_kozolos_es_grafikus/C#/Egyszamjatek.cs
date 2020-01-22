using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Egyszamjatek
{
    class Jatekos
    {
        public string Nev { get; private set; }
        public List<int> Tippek { get; private set; }
        public Jatekos(string sor)
        {
            string[] m = sor.Split();
            Nev = m[0];
            Tippek = new List<int>();
            foreach (var i in m.Skip(1)) Tippek.Add(int.Parse(i));
        }
    }

    class Egyszamjatek
    {
        static void Main()
        {
            List<Jatekos> t = new List<Jatekos>();
            foreach (var i in File.ReadAllLines("egyszamjatek1.txt")) t.Add(new Jatekos(i));

            Console.WriteLine($"3. feladat: Játékosok száma: {t.Count} fő");

            Console.Write($"4. feladat: Kérem a forduló sorszámát: ");
            int fordulóSorszáma = int.Parse(Console.ReadLine());

            Console.WriteLine($"5. feladat: A megadott forduló tippjeinek átlaga: {t.Average(x=>x.Tippek[fordulóSorszáma -1]):F2}");

            Console.ReadKey();
        }
    }
}
