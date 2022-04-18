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
        
        public Normal(double media, double desviacionEstandar){
            this.media = media;
            this.desviacionEstandar = desviacionEstandar;
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
            double marcaClase = 0;
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                marcaClase = (intervalosHasta[i] - intervalosDesde[i]) / 2;
                probabilidadesEsperadas[i] = (Math.Pow(Math.E, (-0.5*Math.Pow((marcaClase-media)/desviacionEstandar, 2)))) / (desviacionEstandar * Math.Sqrt(2*Math.PI));
            } 
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
