using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class NormalBoxMuller : Normal
    {
        public NormalBoxMuller(double media, double desviacionEstandar) : base(media, desviacionEstandar) { }
        
        
        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
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
            return serieGenerada;
        }
    }
}
