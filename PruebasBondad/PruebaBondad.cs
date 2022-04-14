using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public abstract class PruebaBondad {
        protected Distribucion distribucion;
        protected Dictionary<double, double> tabla;
        protected double[] intervalosDesde, intervalosHasta, frecuenciasObservadas, frecuenciasEsperadas;

        public PruebaBondad(Distribucion distribucion)
        { 
            this.distribucion = distribucion;
        }
        public abstract Tuple<bool, double, double, string> realizarPrueba(); 
        protected abstract bool noSeRechaza();
        protected string generarCadenaResultado()
        {
            string resultado = "SE RECHAZA LA HIPÓTESIS";
            if (noSeRechaza())
            {
                return "NO " + resultado;
            }
            return resultado;
        }

        public abstract bool esChiCuadrado();
    }

}
