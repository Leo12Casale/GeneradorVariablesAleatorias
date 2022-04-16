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
            CantidadIntervalos = (int)(Math.Sqrt(TamañoMuestra));
            this.serieGenerada = new double[cantidadNumerosAGenerar];
            //Creamos los números RNDs
            double[] numerosRND = generarRNDs(cantidadNumerosAGenerar);
            //Generamos los números aleatorios uniformes
            for (int i = 0; i < cantidadNumerosAGenerar; i++)
            {
                this.serieGenerada[i] = this.A + numerosRND[i] * (this.B - this.A);
            }
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