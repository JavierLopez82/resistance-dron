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
    }
}
