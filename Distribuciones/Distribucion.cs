using System;
using System.Collections.Generic;
using System.Data;
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
        public  virtual void calcularIntervalosDesde()
        {
            intervalosDesde = new double[cantidadIntervalos];
            double acumulador = serieGenerada.Min();
            double tamañoIntervalo = (serieGenerada.Max()  - serieGenerada.Min()) / (double)cantidadIntervalos;
            for (int i = 0; i < intervalosDesde.Length; i++)
            {
                intervalosDesde[i] = acumulador;
                acumulador += tamañoIntervalo;
            } 
        }

        public double[] getIntervalosDesde()
        {
            return intervalosDesde;
        }

        public virtual void calcularIntervalosHasta()
        {
            intervalosHasta = new double[cantidadIntervalos];
            double tamañoIntervalo = (serieGenerada.Max() - serieGenerada.Min()) / (double)cantidadIntervalos;
            double acumulador = serieGenerada.Min() +  tamañoIntervalo;
            for (int i = 0; i < intervalosHasta.Length; i++)
            {
                intervalosHasta[i] = acumulador;
                acumulador += tamañoIntervalo;
            } 
        }

        public double[] getIntervalosHasta()
        {
            return intervalosHasta;
        }

        // Especializado para cada distribución con el uso de la probabilidad que corresponda
        public virtual void calcularFrecuenciasEsperadas()
        {
            frecuenciasEsperadas = new double[cantidadIntervalos];
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                frecuenciasEsperadas[i] = probabilidadesEsperadas[i] * tamañoMuestra;
            }
        }

        public virtual double[] getFrecuenciasEsperadas()
        {
            return frecuenciasEsperadas; 
        }

        // Necesitamos esta columan para el k-s, es distinto en cada distribución
        public virtual double[] getProbabilidadEsperada()
        {
            return probabilidadesEsperadas;
        }
        public abstract void calcularProbabilidadEsperada();

        public virtual void calcularFrecuenciasObservadas()
        {
            frecuenciasObservadas = new int[cantidadIntervalos];
            //double tamañoIntervalo = (serieGenerada.Max()*1.0001 - serieGenerada.Min()) / (double)cantidadIntervalos;
            for (int i = 0; i < serieGenerada.Length; i++)
            {
                int contadorIntervalos = 0;
                if (serieGenerada[i] > intervalosHasta[cantidadIntervalos - 1]) {
                    frecuenciasObservadas[cantidadIntervalos - 1] += 1;
                    continue;
                }

                while (serieGenerada[i] > intervalosHasta[contadorIntervalos])
                {
                    contadorIntervalos++;
                }
                frecuenciasObservadas[contadorIntervalos] += 1;
                }
                //int indice = (int)Math.Floor(serieGenerada[i] / tamañoIntervalo);
                //frecuenciasObservadas[indice] += 1;
            }
        

        public virtual int[] getFrecuenciasObservadas()
        {
            return frecuenciasObservadas;
        }

        public void calcularProbabilidadObservada()
        {
            probabilidadesObservadas = new double[cantidadIntervalos]; 
            for (int i = 0; i < cantidadIntervalos ; i++)
            {
                probabilidadesObservadas[i] = frecuenciasObservadas[i] / tamañoMuestra;
            }
        }

        public double[] getProbabilidadObservada()
        {
            return probabilidadesObservadas;
        }

        // Getter de la variable con la cantidad de datos empíricos de cada distribución
        public abstract int getCantDatosEmpiricos();

        public abstract string[] getColumnas();
        public abstract DataTable generarTabla();
    }
}
