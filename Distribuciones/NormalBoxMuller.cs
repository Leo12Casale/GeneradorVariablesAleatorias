using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class NormalBoxMuller : Normal
    {
        public NormalBoxMuller(double media, double desviacionEstandar, int intervalo) : base(media, desviacionEstandar, intervalo) { }
        
        
        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            tamañoMuestra = cantidadNumerosAGenerar;
            //serieGenerada = new double[] { 1.56, 2.21, 3.15, 4.61, 4.18, 5.20, 6.94, 7.71, 5.15, 6.76, 7.28, 4.23, 3.21, 2.75, 4.69, 5.86, 6.25, 4.27, 4.91, 4.78, 2.46, 3.97, 5.71, 6.19, 4.20, 3.48, 5.83, 6.36, 5.90, 5.43 };
            
            //Variable para controlar que la cantidad de RND sean pares
            int cantidadRND = cantidadNumerosAGenerar;
            this.serieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            //Cheuquea cantidad de numeros sea par, para usar randoms de a pares.
            if (cantidadNumerosAGenerar % 2 != 0){ cantidadRND += 1;}
            double[] numerosRND = generarRNDs(cantidadRND);
            //Generamos los números aleatorios uniformes
            int j;
            for (int i = 0; i < cantidadNumerosAGenerar; i += 2)
            {
                j = i + 1;
                serieGenerada[i] = (Math.Sqrt(-2 * Math.Log(numerosRND[i])) * Math.Cos(2 * Math.PI * numerosRND[j])) * this.desviacionEstandar + this.media;
                //Chequeo de que la cantidad generada de numeros aleatorios no supere la cantidad solicitada
                if (j > cantidadNumerosAGenerar) { break; }
                serieGenerada[j] = (Math.Sqrt(-2 * Math.Log(numerosRND[i])) * Math.Sin(2 * Math.PI * numerosRND[j])) * this.desviacionEstandar + this.media;
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
