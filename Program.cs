using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1. feladat
            StreamReader Olvas = new StreamReader("szeptember.csv", Encoding.Default);
            List<Tanulo> szeptember = new List<Tanulo>();
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                szeptember.Add(new Tanulo(Olvas.ReadLine()));
            }
            Olvas.Close();
            #endregion

            #region 2. feladat
            int OsszMulOra = 0;
            for (int i = 0; i < szeptember.Count; i++)
            {
                OsszMulOra += szeptember[i].MulOrak;
            }
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"\tÖsszes mulasztott orak szama: {OsszMulOra} ora.");
            #endregion

            #region 3. feladat
            Console.WriteLine("3. feladat:");
            Console.Write("\tKerem adjon meg egy napot: ");
            int BekertNap = int.Parse(Console.ReadLine());
            Console.Write("\tTanulo neve: ");
            string BekertTanulo = Console.ReadLine();
            #endregion

            #region 4. feladat
            Console.WriteLine("4. feladat:");
            bool HianyzottE = false;
            for (int i = 0; i < szeptember.Count; i++)
            {
                if (BekertTanulo == szeptember[i].Nev)
                {
                    HianyzottE = true;
                }
            }
            if (HianyzottE == true)
            {
                Console.WriteLine("\tA tanulo hianyzott szeptemberben");
            }
            else
            {
                Console.WriteLine("\tA tanulo nem hianyzott szeptemberben");
            }
            #endregion

            #region 5. feladat
            Console.WriteLine($"5. feladat: Hianyzok 2017.09.{BekertNap}-n:");
            bool VoltEhianyzo = false;
            for (int i = 0; i < szeptember.Count; i++)
            {
                if (BekertNap == szeptember[i].ElsoNap)
                {
                    VoltEhianyzo = true;
                    Console.WriteLine($"\t{szeptember[i].Nev} ({szeptember[i].Osztaly})");
                }
            }
            if (VoltEhianyzo == false)
            {
                Console.WriteLine("\tNem volt hianyzo!");
            }
            #endregion

            #region 6. feladat
            List<string> OsztalyLista = new List<string>();
            for (int i = 0; i < szeptember.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < OsztalyLista.Count; j++)
                {
                    if (szeptember[i].Osztaly == OsztalyLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    OsztalyLista.Add(szeptember[i].Osztaly);
                }
            }
            int[] OsztalyListaSeged = new int[OsztalyLista.Count];
            for (int i = 0; i < szeptember.Count; i++)
            {
                for (int j = 0; j < OsztalyLista.Count; j++)
                {
                    if (szeptember[i].Osztaly == OsztalyLista[j])
                    {
                        OsztalyListaSeged[j] += szeptember[i].MulOrak;
                    }
                }
            }
            StreamWriter Iro = new StreamWriter("osszesites.csv", false, Encoding.Default);
            for (int i = 0; i < OsztalyListaSeged.Length; i++)
            {
                Iro.WriteLine($"{OsztalyLista[i]};{OsztalyListaSeged[i]}");
            }
            Iro.Close();
            Console.WriteLine("6. feladat: osszesites.csv");
            #endregion
            Console.ReadKey();
        }
    }
    class Tanulo
    {
        public string Nev;
        public string Osztaly;
        public int ElsoNap;
        public int UtolsoNap;
        public int MulOrak;

        public Tanulo(string AdatSor)
        {
            string[] AdatSorElemek = AdatSor.Split(';');
            this.Nev = AdatSorElemek[0];
            this.Osztaly = AdatSorElemek[1];
            this.ElsoNap = int.Parse(AdatSorElemek[2]);
            this.UtolsoNap = int.Parse(AdatSorElemek[3]);
            this.MulOrak = int.Parse(AdatSorElemek[4]);
        }
    }
}
