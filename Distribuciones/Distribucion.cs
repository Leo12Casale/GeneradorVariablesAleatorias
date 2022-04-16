using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public abstract class Distribucion
    {
        //Atributos

        protected double[] serieGenerada;

        protected int tamañoMuestra = 0;

        protected int cantidadIntervalos = 0;

        protected int[] frecuenciasObservadas;

        protected double[] probabilidadesObservadas;

        protected double[] frecuenciasEsperadas;

        protected double[] probabilidadesEsperadas;

        protected double[] intervalosDesde;

        protected double[] intervalosHasta;


        //Metodos

        protected double[] SerieGenerada { get => serieGenerada; }

        protected int CantidadIntervalos { get => cantidadIntervalos; set => cantidadIntervalos = value; }
        public int TamañoMuestra { get => tamañoMuestra; set => tamañoMuestra = value; }

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

         //La necesitamos si o si, porque la tabla es diferente (una columna [x;y;...] en lugar de Desde y Hasta)
        public virtual bool esPoisson(){
            return false;
        }

        //Metodo de marcado
        public abstract double[] generarSerie(int cantidadNumerosAGenerar);

        //Poisson no tiene desde y hasta, pero que el desde y el hasta retornen el mismo numero. Ej: => [7;7]
        public  virtual double[] getIntervalosDesde()
        {
            double[] intervalosDesde = new double[cantidadIntervalos];
            double acumulador = 0;
            double tamañoIntervalo = 1 / (double)cantidadIntervalos;
            for (int i = 0; i < intervalosDesde.Length; i++)
            {
                intervalosDesde[i] = acumulador;
                acumulador += tamañoIntervalo;
            }
            return intervalosDesde;
        }
        public virtual double[] getIntervalosHasta()
        {
            double[] intervalosHasta = new double[cantidadIntervalos];
            double acumulador = tamañoMuestra;
            double tamañoIntervalo = 1 / (double)cantidadIntervalos;
            for (int i = 0; i < intervalosHasta.Length; i++)
            {
                intervalosHasta[i] = acumulador;
                acumulador += tamañoIntervalo;
            }
            return intervalosHasta;
        }

        // Especializado para cada distribución con el uso de la probabilidad que corresponda
        public virtual double[] getFrecuenciasEsperadas()
        {
            frecuenciasEsperadas = new double[cantidadIntervalos];
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                frecuenciasEsperadas[i] = probabilidadesEsperadas[i] * tamañoMuestra;
            }
            return frecuenciasEsperadas;
        }

        // Necesitamos esta columan para el k-s, es distinto en cada distribución
        public abstract double[] getProbabilidadEsperada();

        public virtual int[] getFrecuenciasObservadas()
        {
            frecuenciasObservadas = new int[cantidadIntervalos];
            double tamañoIntervalo = 1 / (double)cantidadIntervalos;
            for (int i = 0; i < serieGenerada.Length; i++)
            {

                frecuenciasObservadas[(int)Math.Floor(serieGenerada[i] / tamañoIntervalo)] += 1;
            }
            return frecuenciasObservadas;
        }

        public double[] getProbabilidadObservada()
        {
            probabilidadesObservadas = new double[cantidadIntervalos]; 
            for (int i = 0; i < cantidadIntervalos ; i++)
            {
                probabilidadesObservadas[i] = frecuenciasObservadas[i] / tamañoMuestra;
            }
            return probabilidadesObservadas;
        }

        // Getter de la variable con la cantidad de datos empíricos de cada distribución
        public abstract int getCantDatosEmpiricos();

        


    }
}
