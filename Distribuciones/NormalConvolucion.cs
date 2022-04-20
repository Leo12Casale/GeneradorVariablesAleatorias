using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class NormalConvolucion : Normal
    {
        public NormalConvolucion(double media, double desviacionEstandar, int intervalo) : base(media, desviacionEstandar, intervalo) { }

        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            tamañoMuestra = cantidadNumerosAGenerar;
            //serieGenerada = new double[] { 1.56, 2.21, 3.15, 4.61, 4.18, 5.20, 6.94, 7.71, 5.15, 6.76, 7.28, 4.23, 3.21, 2.75, 4.69, 5.86, 6.25, 4.27, 4.91, 4.78, 2.46, 3.97, 5.71, 6.19, 4.20, 3.48, 5.83, 6.36, 5.90, 5.43 };
            
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
            
            calcularIntervalosDesde();
            calcularIntervalosHasta();
            calcularFrecuenciasObservadas();
            calcularProbabilidadObservada();
            calcularProbabilidadEsperada();
            calcularFrecuenciasEsperadas();

            return serieGenerada;
        }   
    }
}
