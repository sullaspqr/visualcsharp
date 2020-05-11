using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Ember
    {
        public int a;
        public string b;
        public char c;
        public void Kiir() {
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
    class Kutya {
        public string Nev;

        public void Nevkiiro() {
            Console.WriteLine(Nev+" kutya vagyok... szia!");
        }
        private int Ehsegjelzo=50;
        public void Etet(int étel) {
            Ehsegjelzo -= étel;
            Console.WriteLine("Eszik...");
        }

        public void Jatek()
        {
            if (Ehsegjelzo <= 80)
            {
                Ehsegjelzo += 50;
                Console.WriteLine("Játszik...");
            }
            else { Console.WriteLine("A kutya éhes, nem tudsz vele játszani!"); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ember e = new Ember();
            e.a = 12;
            e.b = "abcd";
            e.c = 'a';
            e.Kiir();

            Kutya k = new Kutya();
            k.Nev = "Bodri";
            k.Nevkiiro();
            k.Jatek();
            k.Jatek();
            k.Jatek();
            k.Etet(30);
            k.Jatek();

            Console.ReadKey();
        }
    }
}
