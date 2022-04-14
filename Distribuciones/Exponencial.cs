using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Exponencial : Distribucion
    {
        private double lambda;

        public Exponencial(double lambda)
        {
            //todo chequear
            if (lambda == 0) return;
            this.lambda = lambda;
        }

        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            this.SerieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                this.SerieGenerada[i] = (-1/this.lambda) * Math.Log(1-numerosRND[i]);
            }
            return SerieGenerada;
        }

        public override int getCantDatosEmpiricos()
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

        public override double[] getIntervalosDesde()
        {
            throw new NotImplementedException();
        }

        public override double[] getIntervalosHasta()
        {
            throw new NotImplementedException();
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
