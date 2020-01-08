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
        static string kodoltszoveg = "TESZT SZOVEG!";
        static string morzeszoveg = "...   --..   ;.-       -...   .-   .-.   .--.-   -   ...   .--.-   --.       .-   --..   --..--       .-   --   ..";


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
            Szoveg2Morze(kodoltszoveg);
            Console.WriteLine("Teszt1: {0}", Szoveg2Morze(kodoltszoveg));

            Morze2Szoveg(morzeszoveg);

            Console.ReadKey();
        }

        public static void Morze2Szoveg(string morzeszoveg)
        {

            string bemenet2 = morzeszoveg;
            string keresett = "       ";
            int hanyszor = 0;
            for (int i = 0; i < bemenet2.Length; i++)
            {
                if (bemenet2.Substring(i,i+7).Equals(keresett))
                {
                    hanyszor++;
                }
            }
                                          
            // Innen már kusza és nem működik feladom...
            string[] szavak = bemenet2.Split(bemenet2[hanyszor], "       ");
            string ujszoveg = "";


            for (int i = 0; i < szavak.Length; i++)
            {1
                string[] betuk = szavak[i].Split(betuk[], i, "   ");
                for (int j = 0; j < betuk.Length; j++)
                {
                    for (int k = 0; k < db; k++)
                    {

                        if (betuk[j].Equals(morzejel[k]))
                        {
                            ujszoveg += betu[k];
                        }
                    }
                }
            }
        }


        public static string Szoveg2Morze(string bemenet)
        {
            int kodolthossz = bemenet.Length;
            string kikodolt = "";
            string kikod = "";
            for (int i = 0; i < kodolthossz; i++)
            {
                string bemenetBetuje = bemenet.Substring(i, 1); // optimalizáljunk kicsit :)
                bool found = false;
                for (int z = 0; z < db; z++)
                {
                    if (betu[z] == bemenetBetuje) //azt gondolom ha talál egy kódoltat az állományból akkor cseréli
                    {
                        kikod = kikod + " " + morzejel[z];
                        found = true;
                        break; // ebben a ciklusban nem kell tovább menni, jöhet a bemenet következő karaktere
                    }
                    else if (bemenetBetuje == " ") //itt azt szerettem volna hogy ha üres/szóköz van akkor oda szintén tegyen egy space-t
                    {
                        kikod = kikod + " ";
                        found = true; // ez is találatnak számít, de érdemesebb lenne felvenni a táblákba
                        break; // ebben a ciklusban nem kell tovább menni, jöhet a bemenet következő karaktere
                    }
                }

                //úgy ment végig a belső ciklus, hogy nem volt találat ?
                if (!found) //aztán eszembe jutott hogy mi van akkor ha olyan karaktert kellene forgatni ami nincs az alap állományban, helyére tegyen &-t (pl-Ű nincs)
                {
                    kikod = kikod + "&";
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
