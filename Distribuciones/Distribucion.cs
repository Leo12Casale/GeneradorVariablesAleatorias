using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public abstract class Distribucion
    {
        protected double[] generarRNDs(int cantidadRNDsNecesarios)
        {
            double[] RNDs = new double[cantidadRNDsNecesarios];

            Random randNum = new Random();
            for (int i = 0; i < RNDs.Length; i++)
            {
                RNDs[i] = randNum.NextDouble();
            }
            return RNDs;
        }
    }
}
