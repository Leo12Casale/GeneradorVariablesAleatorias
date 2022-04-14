using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Poisson : Distribucion
    {
        private double media;
        public override double[] generarSerie(int cantidadNumerosAGenerar) {
            this.SerieGenerada = new double[cantidadNumerosAGenerar];
            Random rndPoisson = new Random();

            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                //Numero aleatorio a incluir en la serie
                double x = -1;
                //Variables de generacion por cada numero aleatorio
                double p = 1;
                double a = Math.Pow(Math.E, -(this.media));
                double u;
                do
                {
                    u = rndPoisson.NextDouble();
                    p *= u;
                    x++;
                }
                while (p >= a);
                SerieGenerada[i] = x;
            }
            return SerieGenerada;
        }

        public override bool esPoisson(){
            return true;
        }

        public override double[] getIntervalosDesde()
        {
            throw new NotImplementedException();
        }

        public override double[] getIntervalosHasta()
        {
            throw new NotImplementedException();
        }

        public override double[] getFrecuenciasEsperadas()
        {
            throw new NotImplementedException();
        }

        public override double[] getFrecuenciasObservadas()
        {
            throw new NotImplementedException();
        }

        public override int getCantDatosEmpiricos()
        {
            return 1;
        }

        public override int getNMuestras()
        {
            throw new NotImplementedException();
        }

        public override double[] getProbabilidadEsperada()
        {
            throw new NotImplementedException();
        }
    }
}
