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

        public Dobas(int k1, int k2, int k3, int k4, int k5)
        {
            kockak[0] = k1;
            kockak[1] = k2;
            kockak[2] = k3;
            kockak[3] = k4;
            kockak[4] = k5;
        }


        public void EgyDobas()
        {
            Random veletlen = new Random();
            for (int i = 0; i < kockak.Length; i++)
            {
                kockak[i] = veletlen.Next(1, 7);
            }
        }


        public void Kiiras()
        {
            foreach (var k in kockak)
            {
                Console.Write($"{k} ");
            }
        }


        public string Erteke()
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
