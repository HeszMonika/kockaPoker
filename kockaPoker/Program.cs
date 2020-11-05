using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockaPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Dobas d = new Dobas();//Ha számokat adok meg és a d.EgyDobas-t kokommentelem, ezeket az adatoat nézi.

            d.EgyDobas();//Ha kikommentelem, a fenső tömb adatait nézi.
            d.Kiiras();


            Console.ReadKey();
        }
    }
}
