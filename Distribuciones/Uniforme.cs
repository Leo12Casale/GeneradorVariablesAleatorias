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
        private double[] serieGenerada;

        //Constructor
        public Uniforme(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        //Getters y Setters
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double[] SerieGenerada { get => serieGenerada; set => serieGenerada = value; }

        //Métodos de la clase
        public double[] generarSerie(int cantidadNumerosAGenerar)
        {
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
    }
}