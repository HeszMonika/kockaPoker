using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kockaPoker
{
    class Program
    {
        static void Ellenorzes()
        {
            StreamReader sr = new StreamReader("teszteles.txt");
            while (!sr.EndOfStream)
            {
                string[] a = sr.ReadLine().Split(',');
                List<int> sz = a.Select(x => int.Parse(x)).ToList();
                //Végigmegy az "a" tömbbön, egész értéket csinál az elemekból, majd beleteszi az "sz" változóba.

                Dobas d = new Dobas(sz[0], sz[1], sz[2], sz[3], sz[4]);
                d.Kiiras();
            }
            sr.Close();
        }


        static void Main(string[] args)
        {
            //Dobas d = new Dobas();//Ha számokat adok meg és a d.EgyDobas-t kokommentelem, ezeket az adatoat nézi.

            //d.EgyDobas();//Ha kikommentelem, a fenső tömb adatait nézi.
            //d.Kiiras();

            //Ellenorzes();

            Dobas gep = new Dobas();
            Dobas ember = new Dobas();

            gep.EgyDobas();
            ember.EgyDobas();

            gep.Kiiras();
            ember.Kiiras();

            Console.ReadKey();
        }
    }
}
