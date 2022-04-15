using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class NormalConvolucion : Normal
    {
        public NormalConvolucion(double media, double desviacionEstandar) : base(media, desviacionEstandar) { }

        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            //Variable que acumula los 12 randoms para generar un numero aleatorio
            double sumatoriaRND;
            //Variable que chequea que se utilicen 12 randoms por numero aleatorio
            int contadorRND = 0;
            //Variable que chequea que se recorran todos los randoms generados, y no siempre los mismos 12
            int iteradorRNDTotales = 0;
            this.serieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            //Cada variable aleatoria consume 12 numerodçs RND.
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar * 12);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                sumatoriaRND = 0;
                contadorRND = 0;
                while (iteradorRNDTotales < numerosRND.Length && contadorRND < 12)          
                {
                    sumatoriaRND += numerosRND[iteradorRNDTotales];
                    contadorRND += 1;
                    iteradorRNDTotales += 1;
                }
                serieGenerada[i] = (sumatoriaRND - 6) * this.desviacionEstandar + this.media;
            }
            return serieGenerada;
        }   
    }
}
