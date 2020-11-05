using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockaPoker
{
    class Dobas
    {
        int[] kockak = new int[5];

        private string eredmeny;

        public string Eredmeny { get
            {
                return eredmeny;
            }
        }//Ha nincs set-je, csak olvasható.

        public Dobas()
        {

        }

        public Dobas(int k1, int k2, int k3, int k4, int k5)
        {
            kockak[0] = k1;
            kockak[1] = k2;
            kockak[2] = k3;
            kockak[3] = k4;
            kockak[4] = k5;

            eredmeny = Erteke();
        }


        public void EgyDobas()
        {
            Random veletlen = new Random();
            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = veletlen.Next(1, 7);
            }

            eredmeny = Erteke();
        }


        public void Kiiras()
        {
            foreach (var k in kockak)
            {
                Console.Write($"{k} ");
            }
            Console.WriteLine($" -> {eredmeny}");
        }


        private string Erteke()
        {
            Dictionary<int, int> eredmeny = new Dictionary<int, int>();

            for (int i = 1; i <= 6; i++)
            {
                eredmeny.Add(i, 0);
            }

            foreach (var k in kockak)
            {
                eredmeny[k]++;
            }


            //A Dictionary-ből lekérdezzük az 1 Value-nál nagyobb elemeket.
            //Első eset ha egy elem marad (Value értéket nézzük):
            //  - 5 -> Nagypóker
            //  - 4 -> Póker
            //  - 3 -> Drill
            //  - 2 -> Pár
            //A Key érték mondja meg, hogy hányas.
            //Második esetben két elem marad:
            //  - Value: 3 és 2 -> Full
            //  - Value: 2 és 2 -> Két pár
            //Harmadik esetben nem marad egy sem:
            //  - Ha Key: 6 == 0 -> Kissor
            //  - Ha Key: 1 == 0 -> Nagysor
            //Minden más esetben -> Szemét

            var result = (from e in eredmeny
                         orderby e.Value descending
                         where e.Value > 1
                         select new { Szam = e.Key, Db = e.Value }).ToList();

            Console.WriteLine();
            int darab = result.Count;
            if (darab == 1)
            {
                string[] egyes = new string[] { "", "", "Pár", "Drill", "Póker", "Nagypóker" };
                return $"{result[0].Szam} {egyes[result[0].Db]}";

                //Másik megoldás:
                //switch (result[0].Db)
                //{
                //    case 5:
                //        return $"{result[0].Szam} Nagypóker";

                //    case 4:
                //        return $"{result[0].Szam} Póker";

                //    case 3:
                //        return $"{result[0].Szam} Drill";

                //    case 2:
                //        return $"{result[0].Szam} Pár";
                //}
            }
            else if (darab == 2)
            {
                if (result[0].Db == 3 && result[1].Db == 2)
                {
                    return $"{result[0].Szam}-{result[1].Szam} Full";
                }
                else
                {
                    if (result[0].Szam > result[1].Szam)
                    {
                        return $"{result[0].Szam}-{result[1].Szam} Pár";
                    }
                    else
                    {
                        return $"{result[1].Szam}-{result[0].Szam} Pár";
                    }
                }
            }
            else
            {
                if (eredmeny[6] == 0)
                {
                    return "Kissor";
                }
                else if (eredmeny[1] == 0)
                {
                    return "Nagysor";
                }
                else
                {
                    return "Szemét";
                }
            }

            return "Vége";


            //Saját megoldás:
            if (eredmeny.ContainsValue(2))
            {
                return "Pár";
            }
            else if (eredmeny.ContainsValue(2) && eredmeny.ContainsValue(2))
            {
                return "2-2 egyforma";
            }
            else if (eredmeny.ContainsValue(3))
            {
                return "Drill";
            }
            else if(eredmeny.ContainsValue(2) && eredmeny.ContainsValue(3))
            {
                return "Full";
            }
            else if(eredmeny.ContainsValue(4))
            {
                return "Póker";
            }
            else if(eredmeny.ContainsValue(5))
            {
                return "Nagypóker";
            }
            else
            {
                return "Szemét";
            }
        }
    }
}
