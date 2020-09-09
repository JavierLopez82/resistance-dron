using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resistance_dron
{
    public class Dron
    {
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


            }

            return numberConnons;
        }
    }
}
