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
        protected double[] intervalosDesde, intervalosHasta, frecuenciasEsperadas;
        protected int[] frecuenciasObservadas;


        public PruebaBondad(Distribucion distribucion)
        { 
            this.distribucion = distribucion;
        }
        public abstract Tuple<bool, double, double, string> realizarPrueba();


        /// <summary>
        /// Logica de interpretación de los resultados de la prueba de bondad
        /// </summary>
        /// <returns>true si NO se rechaza la hipotesis</returns>
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

        /// <summary>
        /// Metodo para saber el tipo de prueba de bondad instanciada. Util para la hora de invocar al método
        /// obtenerFila(int) porque el tipo de retorno de cada prueba de bondad es distinto (depende del número 
        /// de columnas) y por lo tanto no puede usarse polimorfismo (o nosotros no sabemos cómo)
        /// </summary>
        /// <returns></returns>
        public abstract bool esChiCuadrado();
    }

}
