using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resistance_dron
{
    public class Dron
    {
        /// <summary>
        /// Se obtiene el número máximo de cañones que deberá cargar un dron dependiendo 
        /// del mapa de cumbres representado por el array pasado por parámetro
        /// </summary>
        /// <param name="A">Array que representa el mapa del terreno que contiene las cumbres</param>
        /// <returns>El número de máximo de cañones que se podrán colocar</returns>
        public int maxNumberLaserCannons(int[] A)
        {
            int numberConnons = 0;
            int length = A.Length;
            List<int> indexTops = new List<int>();

            if (A != null && length > 0)
            {
                //Se obtienen las cumbres
                for (int i = 1; i < (length - 1); i++)
                {
                    if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    {
                        indexTops.Add(i);
                    }
                }

                //Si se encuentra alguna cumbre
                if (indexTops.Count > 0)
                {
                    numberConnons = indexTops.Count;

                    while (!validateLoad(indexTops, numberConnons) && (numberConnons > 0))
                        numberConnons--;
                }
            }

            return numberConnons;
        }

        /// <summary>
        /// Valida si en las cumbres dadas se pueden colocar el número de cañones pasado
        /// </summary>
        /// <param name="indexTops">Mapa de las cumbres que contiene el terreno</param>
        /// <param name="numberConnons">Número de cañones que se quiere colocar</param>
        /// <returns>True si se pueden colocar los cañones pasados, false en caso contrario</returns>
        private bool validateLoad(List<int> indexTops, int numberConnons)
        {
            List<List<int>> listCombinations = new List<List<int>>();
            List<bool> existConnon = new List<bool>(indexTops.Count);

            int numberConnonsActual = numberConnons;

            if (indexTops.Count >= numberConnons)
            {
                //Obtener las combinaciones
                listCombinations = getAllCombinations(indexTops, numberConnons);

                foreach (var listC in listCombinations)
                {
                    //Validar cada combinacion
                    if (validateCombination(listC, numberConnons))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene todas las combinaciones de las cumbres dadas según el número de cañones
        /// </summary>
        /// <param name="indexTops">Lista de cumbres disponibles</param>
        /// <param name="numberConnons">Número de cañones a colocar</param>
        /// <returns>Todas las combinaciones de las cumbres por el número de cañones</returns>
        private List<List<int>> getAllCombinations(List<int> indexTops, int numberConnons)
        {
            List<List<int>> combinations = new List<List<int>>();

            //int[] elem = indexTops.ToArray();
            //int size = elem.Length;
            int size = indexTops.Count;

            if (numberConnons <= size)
            {
                int[] numbers = new int[numberConnons];
                //List<int> numbers = new List<int>(numberConnons);
                for (int i = 0; i < numberConnons; i++)
                {
                    numbers[i] = i;
                }

                do
                {
                    //combinations.Add(numbers.Select(n => elem[n]).ToList());
                    combinations.Add(numbers.Select(n => indexTops[n]).ToList());
                }
                while (nextCombination(numbers, size, numberConnons));
            }

            return combinations;
        }

        /// <summary>
        /// Valida si en la combinación de cumbres dada se pueden colocar el número de cañones pasado
        /// </summary>
        /// <param name="listC">Combinación de las cumbres iniciales</param>
        /// <param name="numberConnons">Número de cañones a comprobar</param>
        /// <returns>True si la combinación de cumbres es válida para el número de cañones pasado, false en caso contrario</returns>
        private bool validateCombination(List<int> listC, int numberConnons)
        {
            int cActualValue = -numberConnons;

            if (listC.Count <= 0)
                return false;

            foreach (var elm in listC)
            {
                if (elm < (cActualValue + numberConnons))
                    return false;
                else
                    cActualValue = elm;
            }

            return true;
        }

        private bool nextCombination(int[] num, int n, int k)
        //private bool nextCombination(List<int> num, int n, int k)
        {
            bool finished = false;
            bool changed = false;

            if (k > 0)
            {
                for (int i = (k - 1); (!finished && !changed); i--)
                {
                    if (num[i] < (n - 1) - (k - 1) + i)
                    {
                        num[i]++;
                        if (i < (k - 1))
                        {
                            for (int j = (i + 1); j < k; j++)
                            {
                                num[j] = num[j - 1] + 1;
                            }
                        }
                        changed = true;
                    }
                    finished = (i == 0);
                }
            }

            return changed;
        }
    }
}
