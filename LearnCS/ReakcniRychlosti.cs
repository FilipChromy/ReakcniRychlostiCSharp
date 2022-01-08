using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace LearnCS
{
    class ReakcniRychlosti
    {

        public String VygenerujVyraz()
        {
            string[] operatory = new string[] { "+", "-", "*", "/" };
            int nahodnyPrvekA = new Random().Next(-10, 11);
            int nahodnyPrvekB = new Random().Next(-10, 11);
            return $"{nahodnyPrvekA} {operatory[new Random().Next(0, 4)]} {nahodnyPrvekB}";
        }

        public double VyhodnotNahodnyVyraz(string vyraz)
        {
            int prvekA = Convert.ToInt32(vyraz.Split(" ")[0]);
            int prvekB = Convert.ToInt32(vyraz.Split(" ")[2]);
            char oper = Convert.ToChar(vyraz.Split(" ")[1]);
            double vysledek = 0;
            switch(oper)
            {
                case '+':
                    vysledek = MatematickeOperace.soucet(prvekA, prvekB);
                    break;
                case '-':
                    vysledek = MatematickeOperace.odecet(prvekA, prvekB);
                    break;
                case '*':
                    vysledek = MatematickeOperace.nasobeni(prvekA, prvekB);
                    break;
                case '/':
                    vysledek = MatematickeOperace.deleni(prvekA, prvekB);
                    break;
            }
            return vysledek;
        } 

        public double VstupUzivatele(string vygenerovanyVyraz)
        {
            Console.Write($"Vypocitej: {vygenerovanyVyraz} = ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public bool PorovnejVysledky(double vysledekPocitace, double vysledekUzivatele)
        {
            if (vysledekPocitace == vysledekUzivatele)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void VytvorTest(int pocetPrikladu)
        {
            int pocetSpravnychVysledku = 0;
            ArrayList reakcniCasy = new ArrayList();
            for (int i = 0; i < pocetPrikladu; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                string nahodnyVyraz = VygenerujVyraz();
                double vstupOdUzivatele = VstupUzivatele(nahodnyVyraz);
                double spravnyVysledek = VyhodnotNahodnyVyraz(nahodnyVyraz);
                if (PorovnejVysledky(vstupOdUzivatele, spravnyVysledek))
                {
                    pocetSpravnychVysledku++;
                }
                watch.Stop();
                reakcniCasy.Add(watch.Elapsed.Seconds);
            }
            var reakce = 0;
            foreach (var reakcniCas in reakcniCasy)
            {
                reakce += Convert.ToInt32(reakcniCas);
            }
            Console.WriteLine($"Z {pocetPrikladu} příkladů bylo správně {pocetSpravnychVysledku}");
            Console.WriteLine($"Prumerna reakcni doba: {reakce / reakcniCasy.Count}s");
        }
    }
}
