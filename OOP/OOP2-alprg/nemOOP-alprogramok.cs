using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alprogramok
{ 
class PeldaProgram
{
    static int[] tomb = new int[10];
    static int osszeg = 0;
    //..................................................
    static void Main(string[] args)
    {
        Feltoltes();
        Kiiras();
        OsszegSzamitas();
        Console.WriteLine("A tomb elemek osszege={0}"
        , osszeg);
    }
    //..................................................
    static void Feltoltes()
    {
        for (int i = 0; i < tomb.Length; i++)
        {
            Console.Write("A tomb {0}. eleme=", i);
            string strErtek = Console.ReadLine();
            tomb[i] = Int32.Parse(strErtek);
        }
    }
    //.................................................
    static void Kiiras()
    {
        Console.Write("A tomb elemei: ");
        for (int i = 0; i < tomb.Length; i++)
            Console.Write("{0}, ", tomb[i]);
        Console.WriteLine();
    }
    //.................................................
    static void OsszegSzamitas()
    {
        osszeg = 0;
        for (int i = 0; i < tomb.Length; i++)
            osszeg = osszeg + tomb[i];
    }
    //..................................................
}