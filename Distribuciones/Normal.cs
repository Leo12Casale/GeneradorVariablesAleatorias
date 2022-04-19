using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public abstract class Normal : Distribucion
    {
        protected double media;
        protected double desviacionEstandar;
        double[] marcaClase;

        public Normal(double media, double desviacionEstandar, int intervalo){
            this.media = media;
            this.desviacionEstandar = desviacionEstandar;
            cantidadIntervalos = intervalo;
        }

        public double Media { get => media; set => media = value; }
        public double DesviacionEstandar { get => desviacionEstandar; set => desviacionEstandar = value; }


        //Devuelve dos por que se utiliza la media y la desviacion estandar para el calculo de la frecuencia
        //esperada
        public override int getCantDatosEmpiricos(){
            return 2;
        }

        public override void calcularProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[cantidadIntervalos];
            marcaClase = new double[cantidadIntervalos];
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                marcaClase[i] = (intervalosHasta[i] + intervalosDesde[i]) / 2;
                probabilidadesEsperadas[i] = (Math.Pow(Math.E, (-0.5*Math.Pow((marcaClase[i]-media)/desviacionEstandar, 2)))) / (desviacionEstandar * Math.Sqrt(2*Math.PI));
            } 
        }
        public (string, string, string, string, string, string) obtenerFila(int indice)
        {
            return (intervalosDesde[indice].ToString(), intervalosHasta[indice].ToString(), marcaClase[indice].ToString(), frecuenciasObservadas[indice].ToString(), probabilidadesEsperadas[indice].ToString(), frecuenciasEsperadas[indice].ToString());
        }

        public override string[] getColumnas()
        {
            return new String[] { "Desde", "Hasta", "MC", "FO", "PE", "FE" };
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
                var (desde, hasta,mc, fo, pe, fe) = this.obtenerFila(i);
                tabla.Rows.Add(desde, hasta,mc, fo, pe, fe);
            }

            return tabla;
        }
    }
}
