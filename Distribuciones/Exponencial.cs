using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Exponencial : Distribucion
    {
        private double media;

        public Exponencial(double media)
        {      
            this.media = media;
        }

        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            serieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                this.serieGenerada[i] = (-this.media) * Math.Log(1-numerosRND[i]);
            }
            return serieGenerada;
        }

        public override int getCantDatosEmpiricos()
        {
            return 1;
        }

        public override double[] getProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[cantidadIntervalos];
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                probabilidadesEsperadas[i] = (1 - Math.Pow(Math.E,((-1/media) * intervalosHasta[i]))) - (1 - Math.Pow(Math.E, ((-1 / media) * intervalosDesde[i])));
            }
            return probabilidadesEsperadas;
        }
    }
}
