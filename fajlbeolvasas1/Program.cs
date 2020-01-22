using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // ezzel beaktiváljuk a fájlkezelést!

namespace fajlbeolvasas
{
    class Program
    {
        struct fajlbe { // a fájlból ebbe a struktúrába 
           public int id;     // fogjuk beolvasni az adatokat!
            public string abc;
            public char d;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\xampp\erettsegi.csv");
            List<string> x = new List<string>();
            while (!sr.EndOfStream) {
                x.Add(sr.ReadLine());
            }
            fajlbe[] y = new fajlbe[10];
            
            for (int i = 0; i < x.Count; i++)
            {
                string[] z = x[i].Split(';');
                y[i].id = int.Parse(z[0]);
                y[i].abc = z[1];
                y[i].d = Convert.ToChar(z[2]);
            }

            for (int j = 0; j < y.Length; j++) { // kiíratjuk a struktúra-elemeit:
                Console.WriteLine("Azonosító: {0}\nSzöveg: {1}\nKarakter:{2}", y[j].id, y[j].abc, y[j].d);
            }
            // Írjuk ki az azonosítók összegét:
            int osszeg = 0;
            for (int k = 0; k < y.Length; k++) {
                osszeg += y[k].id;
            }
            Console.WriteLine("Az id-k összege: "+osszeg);
            
            // Írjuk ki az azonosítók átlagát:
            double atlag; // kasztolás: "kierőszakoljuk" a típust!
            atlag = (double)osszeg / (double)y.Length;
            Console.WriteLine("Az id-k átlaga: " + atlag);
            
            // írjuk egymás után a struktúrában az abc stringeket!
            for (int l = 0; l < y.Length; l++) {
                Console.Write(" "+y[l].abc);
            }

                Console.ReadKey();

        }

    }
}
