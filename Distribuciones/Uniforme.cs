using System;
using System.Collections.Generic;
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
        public Uniforme(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        //Getters y Setters
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }

        //Métodos de la clase
        public override double[] generarSerie(int cantidadNumerosAGenerar)
        {
            TamañoMuestra = cantidadNumerosAGenerar;
            CantidadIntervalos = 5;// (int)(Math.Sqrt(TamañoMuestra));
            this.serieGenerada = new double[]{ 0.15, 0.22, 0.41, 0.65, 0.84, 0.81, 0.62, 0.45, 0.32, 0.07, 0.11, 0.29, 0.58, 0.73, 0.93, 0.97, 0.79, 0.55, 0.35, 0.09, 0.99, 0.51, 0.35, 0.02, 0.19, 0.24, 0.98, 0.10, 0.31, 0.17};
            //Calcule arrays po pe, fe, fo
            /*new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                this.serieGenerada[i] = this.A + numerosRND[i] * (this.B - this.A);
            }*/
            return serieGenerada;
        }

        public override int getCantDatosEmpiricos()
        {
            return 0;
        }


        public override double[] getProbabilidadEsperada()
        {
            probabilidadesEsperadas = new double[cantidadIntervalos];
            
            for (int i = 0; i < probabilidadesEsperadas.Length; i++)
            {
                probabilidadesEsperadas[i] = (B - A) / cantidadIntervalos;
            }
            return probabilidadesEsperadas;
        }
    }
}