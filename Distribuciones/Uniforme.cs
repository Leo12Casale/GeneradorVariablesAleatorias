using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Uniforme : Distribucion
    {
        //Atributos
        private double a;
        private double b;
      

        //Constructor
        public Uniforme(double a, double b, int intervalo)
        {
            if(a < b)
            {
                this.A = a;
                this.B = b;
            } else
            {
                this.A = b;
                this.B = a;
            }
            this.cantidadIntervalos = intervalo;
        } 

        //Getters y Setters
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }

        //Métodos de la clase
        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            TamañoMuestra = cantidadNumerosAGenerar; 
            //this.serieGenerada = new double[]{ 0.15, 0.22, 0.41, 0.65, 0.84, 0.81, 0.62, 0.45, 0.32, 0.07, 0.11, 0.29, 0.58, 0.73, 0.93, 0.97, 0.79, 0.55, 0.35, 0.09, 0.99, 0.51, 0.35, 0.02, 0.19, 0.24, 0.98, 0.10, 0.31, 0.17};
            //Calcule arrays po pe, fe, fo
            this.serieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            int cantDigitos = (int) Math.Floor(Math.Log10(B) + 1);

            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                //this.serieGenerada[i] = Math.Truncate(cantDigitos * (this.A + numerosRND[i] * (this.B - this.A))) / cantDigitos;
                this.serieGenerada[i] = this.A + numerosRND[i] * (this.B - this.A);
            }

            calcularIntervalosDesde();
            calcularIntervalosHasta();
            calcularFrecuenciasObservadas();
            calcularProbabilidadObservada();
            calcularProbabilidadEsperada();
            calcularFrecuenciasEsperadas();

            return serieGenerada;
        }

        public override void calcularIntervalosDesde()
        {
            intervalosDesde = new double[cantidadIntervalos];
            double acumulador = A;
            double tamañoIntervalo = (B - A) / (double)cantidadIntervalos;
            for (int i = 0; i < intervalosDesde.Length; i++)
            {
                intervalosDesde[i] = acumulador;
                acumulador += tamañoIntervalo;
            }
        }
        public override void calcularIntervalosHasta()
        {
            intervalosHasta = new double[cantidadIntervalos];
            double tamañoIntervalo = (B - A) / (double)cantidadIntervalos;
            double acumulador = A + tamañoIntervalo;
            for (int i = 0; i < intervalosHasta.Length; i++)
            {
                intervalosHasta[i] = acumulador;
                acumulador += tamañoIntervalo;
            }
        }
        public override void calcularFrecuenciasObservadas()
        {
            frecuenciasObservadas = new int[cantidadIntervalos];
            
              for (int i = 0; i < serieGenerada.Length; i++)
                {
                   int contadorIntervalos = 0;

                if (serieGenerada[i] > intervalosHasta[cantidadIntervalos - 1])
                {
                    frecuenciasObservadas[cantidadIntervalos - 1] += 1;
                    continue;
                }

                while (serieGenerada[i] >= intervalosHasta[contadorIntervalos])
                   {
                       contadorIntervalos++;
                   }
                    frecuenciasObservadas[contadorIntervalos] += 1;
              }
            

            /*double tamañoIntervalo = (B * 1.000001 - A) / (double)cantidadIntervalos;
            for (int i = 0; i < serieGenerada.Length; i++)
            {
                int indice = (int)Math.Floor(serieGenerada[i] / tamañoIntervalo);
                frecuenciasObservadas[indice] += 1;
            }*/
        }

        public override void calcularFrecuenciasEsperadas()
        {
            frecuenciasEsperadas = new double[cantidadIntervalos];
           
            for (int i = 0; i < cantidadIntervalos; i++)
            {
               
                frecuenciasEsperadas[i] = probabilidadesEsperadas[i] * tamañoMuestra;
            }
        }
        public override int getCantDatosEmpiricos()
        {
            return 0;
        }

        public override void calcularProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[cantidadIntervalos];
            
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                probabilidadesEsperadas[i] = (1) / (double) (cantidadIntervalos);
            }
        }

        // Métodos tabla
        public override string[] getColumnas()
        {
            return new string[] { "Desde", "Hasta", "FO", "FE" };
        }

        public (string, string, string, string) obtenerFila(int indice)
        {
            return (intervalosDesde[indice].ToString(), intervalosHasta[indice].ToString(), frecuenciasObservadas[indice].ToString(), frecuenciasEsperadas[indice].ToString());
        }

        public override DataTable generarTabla()
        {
            DataTable tabla = new DataTable();
            // cabecera 
            string[] columnasTXT = this.getColumnas();
            for (int i = 0; i < columnasTXT.Length; i++)
                tabla.Columns.Add(columnasTXT[i]);

            // filas
            for (int i = 0; i < this.cantidadIntervalos; i++)
            {
                var (desde, hasta, fo, fe) = this.obtenerFila(i);
                tabla.Rows.Add(desde, hasta, fo, fe);
            }

            return tabla;
        }
    }
}