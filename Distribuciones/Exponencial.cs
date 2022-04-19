using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public class Exponencial : Distribucion
    {
        private double media;

        public Exponencial(double media, int intervalo)
        {      
            this.media = media;
            cantidadIntervalos = intervalo;
        }

        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            serieGenerada = new double[cantidadNumerosAGenerar];
            tamañoMuestra = cantidadNumerosAGenerar;
            
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                this.serieGenerada[i] = (-this.media) * Math.Log(1-numerosRND[i]);
            }

            calcularIntervalosDesde();
            calcularIntervalosHasta();
            calcularFrecuenciasObservadas();
            calcularProbabilidadObservada();
            calcularProbabilidadEsperada();
            calcularFrecuenciasEsperadas();

            return serieGenerada;
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
                var (desde, hasta, fo, pe, fe) = this.obtenerFila(i);
                tabla.Rows.Add(desde, hasta, fo, pe, fe);
            }

            return tabla;
        }

        public override int getCantDatosEmpiricos()
        {
            return 1;
        }

        public override void calcularProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[cantidadIntervalos];
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                probabilidadesEsperadas[i] = (1 - Math.Pow(Math.E, ((-1 / media) * intervalosHasta[i]))) - (1 - Math.Pow(Math.E, ((-1 / media) * intervalosDesde[i])));
            }
        }

        public override string[] getColumnas()
        {
            return new string[] { "Desde", "Hasta", "FO", "PE", "FE" };
        }

        public (string, string, string, string, string) obtenerFila(int indice)
        {
            return (intervalosDesde[indice].ToString(), intervalosHasta[indice].ToString(), frecuenciasObservadas[indice].ToString(), probabilidadesEsperadas[indice].ToString(), frecuenciasEsperadas[indice].ToString());
        }     

    }
}
