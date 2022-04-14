using System;
using System.Collections.Generic;
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
            this.Media = media;
            this.DesviacionEstandar = desviacionEstandar;
        }

        public double Media { get => media; set => media = value; }
        public double DesviacionEstandar { get => desviacionEstandar; set => desviacionEstandar = value; }


        //Devuelve dos por que se utiliza la media y la desviacion estandar para el calculo de la frecuencia
        //esperada
        public override int getCantDatosEmpiricos(){
            return 2;
        }
    }
}
