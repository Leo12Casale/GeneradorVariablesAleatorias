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

            
        }

        
        public override double[] generarSerie(int cantidadNumerosAGenerar) {
            tamañoMuestra = cantidadNumerosAGenerar;
            serieGenerada = new double[] { 14, 7, 13, 16, 16, 13, 14, 17, 15, 16, 13, 15, 10, 15, 16, 14, 12, 17, 14, 12, 13, 20, 8, 17, 19, 11, 12, 17, 9, 18, 20, 10, 18, 15, 13, 16, 24, 18, 16, 18, 12, 14, 20, 15, 10, 13, 21, 23, 15, 18 };
            /*serieGenerada = new double[cantidadNumerosAGenerar];
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
                serieGenerada[i] = x;
            }*/

            var temp = Array.ConvertAll(serieGenerada, item => (int)item);
            valoresMuestra = temp.Distinct().ToArray();
            Array.Sort(valoresMuestra); 
            calcularIntervalosDesde();
            calcularIntervalosHasta();
            calcularFrecuenciasObservadas();
            calcularProbabilidadEsperada();
            calcularFrecuenciasEsperadas();

            return serieGenerada;
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
            frecuenciasEsperadas = new double[valoresMuestra.Length];
            for (int i = 0; i < valoresMuestra.Length; i++)
            {
                frecuenciasEsperadas[i] = Math.Ceiling(probabilidadesEsperadas[i] * tamañoMuestra);
            } 
        }

        public override void calcularFrecuenciasObservadas()
        {
            frecuenciasObservadas = new int[valoresMuestra.Max() - valoresMuestra.Min()];
            for (int i = 0; i < serieGenerada.Length; i++)
            {
                int contadorIntervalos = 0;

                while (serieGenerada[i] != valoresMuestra[contadorIntervalos])
                {
                    contadorIntervalos++;
                }
                frecuenciasObservadas[contadorIntervalos] += 1;
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
            return (valoresMuestra[indice].ToString(), frecuenciasObservadas[indice].ToString(), probabilidadesEsperadas[indice].ToString() , frecuenciasEsperadas[indice].ToString());
        }

        public override string[] getColumnas()
        {
            return new string[] { "Valor", "FO", "PE", "FE" };
        }

        public override DataTable generarTabla()
        {
            DataTable tabla = new DataTable();
            // cabecera 
            string[] columnasTXT = this.getColumnas();
            for (int i = 0; i < columnasTXT.Length; i++)
                tabla.Columns.Add(columnasTXT[i]);

            // filas
            for (int i = 0; i < this.valoresMuestra.Length; i++)
            {
                var (valor, fo, pe, fe) = this.obtenerFila(i);
                tabla.Rows.Add(valor, fo, pe, fe);
            }

            return tabla;
        }
    }
}
