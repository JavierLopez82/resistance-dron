using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using resistance_dron;

namespace resistance_mision_dron
{
    class Program
    {
        static void Main(string[] args)
        {
            Dron dronResistencia = new Dron();
            int numberConnons = 0;
            int[] A = { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };

            numberConnons = dronResistencia.maxNumberLaserCannons(A);

            Console.WriteLine("Número máximo de cañones: " + numberConnons.ToString());
            Console.ReadLine();
        }
    }
}
