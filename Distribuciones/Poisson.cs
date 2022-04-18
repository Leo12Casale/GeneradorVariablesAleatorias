using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Poisson : Distribucion
    {
        private double media;


        private int[] valoresMuestra;

        public Poisson(double media)
        {
            this.media = media;

            //Creamos un vector temp y le asignamos el array serieGenerada casteado en int. 
            //No se puede cambiar del metodo, no se permite el override

            var temp = Array.ConvertAll(serieGenerada, item => (int)item);
            valoresMuestra =
            //Agrupo..
            temp.GroupBy(x => x)
            //En caso de que el grupo tenga sólo 1 elemento
            .Where(x => x.Count() == 1)
            //Selecciono su Key (el entero)
            .Select(x => x.Key)
            //Convierto a Array.
            .ToArray();
            valoresMuestra = temp;
        }

        
        public override double[] generarSerie(int cantidadNumerosAGenerar) {
            serieGenerada = new double[cantidadNumerosAGenerar];
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
        public override int getCantDatosEmpiricos()
        {
            return 1;
        }

        public override void calcularIntervalosDesde()
        {
            intervalosDesde = Array.ConvertAll(valoresMuestra, item => (double)item);
        }

        public override void calcularIntervalosHasta()
        {
            intervalosHasta = Array.ConvertAll(valoresMuestra, item => (double)item);
        }

        public override void calcularFrecuenciasEsperadas()
        { 
            double[] frecuenciasEsperadasPoisson = new double[valoresMuestra.Length];
            for (int i = 0; i < valoresMuestra.Length; i++)
            {
                frecuenciasEsperadasPoisson[i] = (int) Math.Ceiling(probabilidadesEsperadas[i] * tamañoMuestra);
            } 
        }

        public override void calcularFrecuenciasObservadas()
        {
            frecuenciasObservadas = new int[valoresMuestra.Length];
            for (int i = 0; i < serieGenerada.Length ; i++)
            {
                frecuenciasObservadas[(int)serieGenerada[i]] += 1; 
            } 
        }

        
        public override void calcularProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[valoresMuestra.Length];
            for (int i = 0; i < valoresMuestra.Length ; i++)
            {
                probabilidadesEsperadas[i] = (Math.Pow(media, valoresMuestra[i])*Math.Pow(Math.E, -media)) / (factorial(valoresMuestra[i]));
            } 
        }

        private int factorial(int input)
        {
            int result = 1;
            for (int i = input; i > 0; i--)
                result *= i;
            return result;
        }
        public (string, string, string, string) obtenerFila(int indice)
        {
            return ("", "", "", "");
        }

        public override string[] getColumnas()
        {
            throw new NotImplementedException();
        }

        public override DataTable generarTabla()
        {
            throw new NotImplementedException();
        }
    }
}
