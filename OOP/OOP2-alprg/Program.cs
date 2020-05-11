using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_alprg
{
    class Feltoltes
    {
        public int[] tomb = new int[10];
        public int osszeg = 0;

        public double Kiirat(double a, double b) {
            double c = a / b;
            return c;
        }
        public void Feltolt()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write("A tomb {0}. eleme=", i);
                string strErtek = Console.ReadLine();
                tomb[i] = Int32.Parse(strErtek);
            }
        }
        public void Kiiras()
        {
            Console.Write("A tomb elemei: ");
            for (int i = 0; i < tomb.Length; i++)
                Console.Write("{0}, ", tomb[i]);
            Console.WriteLine();
        }
        public void OsszegSzamitas()
        {
            osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
                osszeg = osszeg + tomb[i];
        }
        class PeldaProgram
        {
            static void Main(string[] args)
            {
                Feltoltes x = new Feltoltes();
                x.Feltolt();
                x.Kiiras();
                double y = x.Kiirat(6.2, 3.4);
                Console.WriteLine(y);
                x.OsszegSzamitas();
                Console.WriteLine("A tomb elemek osszege={0}"
                , x.osszeg);
                Console.ReadKey();
            }
        }
    }
}