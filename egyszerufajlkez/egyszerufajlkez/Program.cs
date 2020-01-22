using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace egyszerufajlkez
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"U:\szamok.csv";
            string[] a = File.ReadAllLines(path);
            for (int i = 0; i < a.Length; i++) {
                Console.WriteLine(a[i]);
            }
                Console.ReadKey();
            }
        }
    }
