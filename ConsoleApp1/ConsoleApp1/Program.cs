using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string[] betu = new string[100];
        static string[] morzejel = new string[100];
        static int db = 0;
        static string[] szerzo = new string[200];
        static string[] cim = new string[200];
        static int db2 = 0;
        static string tetszolegesszoveg = "KRUMPLIS TÉSZTA";
        static string kodoltszoveg = tetszolegesszoveg;
        static string baba = "baba";

        public static void Main(string[] args)
        
        {
            //2. Beolvasás morzeabc.txt
            Beolvasas("morzeabc.txt");

            //3. Karakterszám meghatározása
            Karakterszam();

            //4. Tetszőleges karatker morzekódjának kiiratása, karakter bekéréssel
            TetszolegesKarakter();

            //5. Beolvasás morze.txt
            Beolvasas2("morze.txt");

            //6. Előre megadott szöveg Morze szöveggé alakítása és kiiratása
            Morze2Szoveg(kodoltszoveg);
            Console.WriteLine("Teszt: {0}");
            

            Console.ReadKey();
        }

        public static string Morze2Szoveg( string ki)
        {
            int kodolthossz = kodoltszoveg.Length;
            string kikodolt = "";
            for (int i = 0; i < kodolthossz; i++)
            {
                string kikod = "";
                for (int z = 0; z < db; z++)
                {
                    if (betu[z] == kodoltszoveg.Substring(i, 1))
                    {
                        //Console.Write("{0} ", morzejel[z]);
                        kikod += morzejel[z];
                    }
                }
                kikodolt = kikod;
            }

            return kikodolt;
        }

        private static void Beolvasas2(string fajlNev)
        {
            try
            {

                StreamReader be = new StreamReader(fajlNev);
                string egysor;
                while ((egysor = be.ReadLine()) != null)
                {
                    string[] darabok2 = egysor.Split(';');
                    szerzo[db2] = darabok2[0];
                    cim[db2] = darabok2[1];
                    //Console.WriteLine("{0},{1}", szerzo[db2], cim[db2]);
                    db2++;
                }
                Console.WriteLine("A(z) {0} beolvasása sikeres volt!", fajlNev);
                be.Close();
            }

            catch (IOException)
            {
                Console.WriteLine("A(z) {0} beolvasása sikertelen!", fajlNev);
            }
        }

        private static void TetszolegesKarakter()
        {

            Console.Write("Kérek egy karaktert: ");
            string keresett = Console.ReadLine();
            string keresett2 = keresett.ToUpper();
            int mintaindex = -1;

            for (int i = 0; i < db; i++)
            {
                if (keresett2 != betu[i])
                {

                }
                else
                {
                    mintaindex = i;
                }
            }

            if (mintaindex == -1)
            {
                Console.WriteLine("Nem található a kódtárban ilyen karakter!");
            }
            else
            {
                Console.WriteLine("A(z) {0} karakter morze kódja: {1} ", keresett, morzejel[mintaindex]);
            }
        }

        private static void Karakterszam()
        {
            Console.WriteLine("A morzeabc.txt állomány {0} karakter morze kódját tartalmazza", db);
        }

        private static void Beolvasas(string fajlNev)
        {

            try
            {

                StreamReader be = new StreamReader(fajlNev);
                string egysor;
                be.ReadLine();
                while ((egysor = be.ReadLine()) != null)
                {
                    string[] darabok = egysor.Split('\t');
                    betu[db] = darabok[0];
                    morzejel[db] = darabok[1];
                    db++;
                }
                Console.WriteLine("A(z) {0} beolvasása sikeres volt!", fajlNev);
                be.Close();
            }

            catch (IOException)
            {
                Console.WriteLine("A(z) {0} beolvasása sikertelen!", fajlNev);
            }
        }
    }
}
