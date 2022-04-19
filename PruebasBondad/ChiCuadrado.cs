using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_VariablesAleatorias.Distribuciones;

namespace TP3_VariablesAleatorias.PruebasBondad
{
    public class ChiCuadrado : PruebaBondad
    {
        private double chiCalculado, chiTabulado;
        private double[] columnaChis, chisAcumulado;
        public ChiCuadrado(Distribucion distribucion) : base(distribucion)
        { 
            tabla = new Dictionary<double, double> { { 1, 003.8400 }, { 2, 005.9900 }, { 3, 007.8100 }, { 4, 009.4900 }, { 5, 011.1000 }, { 6, 012.6000 }, { 7, 014.1000 }, { 8, 015.5000 }, { 9, 016.9000 }, { 10, 018.3000 }, { 11, 019.7000 }, { 12, 021.0000 }, { 13, 022.4000 }, { 14, 023.7000 }, { 15, 025.0000 }, { 16, 026.3000 }, { 17, 027.6000 }, { 18, 029.8000 }, { 19, 030.1000 }, { 20, 031.4000 }, { 21, 032.7000 }, { 22, 033.9000 }, { 23, 035.2000 }, { 24, 036.4000 }, { 25, 037.7000 }, { 26, 038.9000 }, { 27, 040.1000 }, { 28, 041.3000 }, { 29, 042.6000 }, { 30, 043.8000 }, { 40, 055.8000 }, { 50, 067.5000 }, { 60, 079.1000 }, { 70, 090.5000 }, { 80, 101.9000 }, { 90, 113.1000 }, { 100, 124.3000 } }; 
        }

        /// <summary>
        /// Realiza la prueba de bondad de chi cuadrado y retorna una tupla con los valores obtenidos
        /// </summary>
        /// <returns>
        /// Tupla<
        /// ,  bool    True: si NO se rechaza la hipótesis de la distribución específica
        /// ,   double  Valor de chi Calculado
        /// ,   double  Valor de chi Tabulado
        /// ,   string  Cadena descriptiva del resultado
        /// >
        /// </returns>
        public override Tuple<bool, double, double, string> realizarPrueba()
        {
            agruparIntervalos();
            calcularColumnasChi();
            calcularChi();

            return Tuple.Create(noSeRechaza(), chiCalculado, chiTabulado, generarCadenaResultado());
        }

        private void agruparIntervalos()
        {
            /* Obtenemos los valores agrupados de la distribución (independientemente del tipo), 
             * solo las columnas de la tabla izquierda de excel que necesita la prueba de bondad
             */
            double[] intDesde = distribucion.getIntervalosDesde();
            double[] intHasta = distribucion.getIntervalosHasta();
            int[] fo = distribucion.getFrecuenciasObservadas();
            double[] fe = distribucion.getFrecuenciasEsperadas();

            /*Inicializamos nuevamente los intervalos propios de cada columna de 
             * la tabla chiCuadrado (la derecha en excel). 
             * La cantidad de filas inicialmente son las mismas que las de la distribución,
             * luego este número puede disminuir al agrupar
             */
            this.intervalosDesde = new double[intDesde.Length];
            this.intervalosHasta = new double[intDesde.Length];
            this.frecuenciasObservadas = new int[intDesde.Length];
            this.frecuenciasEsperadas = new double[intDesde.Length];

            int j = 0; // Fila actual de la tabla derecha
            int indiceInicioIntervalo = 0; // Indice (en la tabla izquierda) de la fila que indica el desde de la fila derecha actual
            for(int i = 0; i < intDesde.Length; i++)
            {   // Acumulamos las frecuencias
                this.frecuenciasEsperadas[j] += fe[i]; 
                this.frecuenciasObservadas[j] += fo[i]; 
                if(this.frecuenciasEsperadas[j] >= 5) {
                    // Si la frecuencia esperada alcanzó 5, completamos la fila:
                    // el hasta de la fila (con el hasta, de la fila derecha actual [i])
                    this.intervalosHasta[j] = intHasta[i];
                    // el desde de la fila (con el desde, de la fila en la que comenzamos a sumar
                    this.intervalosDesde[j] = intDesde[indiceInicioIntervalo]; 
                    j++; // nos movemos a la fila siguiente en la tabla derecha
                    indiceInicioIntervalo = i + 1; // actualizamos el índice a la fila siguiente (de la tabla derecha)
                }
            }
            // En caso de que las últimas filas no lleguen a 5 las acumulamos al intervalo anterior
            if (j < this.frecuenciasEsperadas.Length && this.frecuenciasEsperadas[j] < 5)
            {
                this.frecuenciasEsperadas[j - 1] += this.frecuenciasEsperadas[j];
                this.frecuenciasObservadas[j - 1] += this.frecuenciasObservadas[j];
                this.intervalosHasta[j - 1] = intHasta[intervalosHasta.Length - 1]; 
            }

            // Reajustamos el número de filas de la columna, luego de la agrupación
            Array.Resize<double>(ref this.intervalosDesde, j);
            Array.Resize<double>(ref this.intervalosHasta, j);
            Array.Resize<double>(ref this.frecuenciasEsperadas, j);
            Array.Resize<int>(ref this.frecuenciasObservadas, j);
        }

        private void calcularColumnasChi()
        {
            columnaChis = new double[frecuenciasEsperadas.Length];
            chisAcumulado = new double[frecuenciasEsperadas.Length];
            columnaChis[0] = Math.Pow(frecuenciasObservadas[0] - frecuenciasEsperadas[0], 2) / frecuenciasEsperadas[0];
            chisAcumulado[0] = columnaChis[0];

            for (int i = 1; i < this.intervalosHasta.Length; i++)
            {
                columnaChis[i] = Math.Pow(frecuenciasObservadas[i] - frecuenciasEsperadas[i], 2) / frecuenciasEsperadas[i];
                chisAcumulado[i] = columnaChis[i] + chisAcumulado[i-1];
            }
        }

        public override bool esChiCuadrado() { return true; }

        private void calcularChi()
        {
            chiCalculado = chisAcumulado[chisAcumulado.Length - 1]; // La última celda del acumulado tiene el total
            int gradosLibertad = chisAcumulado.Length - 1 - distribucion.getCantDatosEmpiricos();
            chiTabulado = tabla[gradosLibertad];
        }

        protected override bool noSeRechaza()
        {
            return chiCalculado < chiTabulado;
        }

        // Gráfico
        public override string[] getColumnas()
        {
            return new string[] { "Intervalo", "FO", "FE", "C", "C(Ac)"};
        }

        /// <summary>
        /// Devuelve una Tupla con todos los valores de una fila que necesita la tabla
        /// </summary>
        /// <param name="indiceFila">índice de la fila a obtener</param>
        /// <returns>
        /// (string: cadena del intervalo => [0 - 200) o 7; 8; 9; 10 (Poisson)
        /// , double: frecuencia observada de la fila
        /// , double: frecuencia esperada de la fila
        /// , double: chi de la fila
        /// , double: chi acumulado
        /// )
        /// </returns>
        public (string, double, double, double, double) obtenerFila(int indiceFila)
        {
            if (indiceFila < 0 || indiceFila > this.intervalosHasta.Length - 1) return ("-", -1.0, -1.0, -1.0, -1.0);
            string columnaIntervalos = intervalosDesde[indiceFila].ToString();
            if (distribucion.esPoisson())
            {
                for (double i = intervalosDesde[indiceFila] + 1; i <= intervalosHasta[indiceFila]; i++)
                    columnaIntervalos += "; " + i.ToString();
            }
            else
            {
                columnaIntervalos = "[" + columnaIntervalos + " - " + intervalosHasta[indiceFila] + ")";
            }

            return (columnaIntervalos, frecuenciasObservadas[indiceFila], frecuenciasEsperadas[indiceFila], columnaChis[indiceFila], chisAcumulado[indiceFila]);
        }

        public override DataTable generarTabla()
        {
            DataTable tabla = new DataTable();
            // cabecera 
            string[] columnasTXT = this.getColumnas();
            for (int i = 0; i < columnasTXT.Length; i++)
                tabla.Columns.Add(columnasTXT[i]);

            // filas
            for (int i = 0; i < this.intervalosDesde.Length; i++)
            {
                var (intervalo, fo, fe, c, cac) = this.obtenerFila(i);
                tabla.Rows.Add(intervalo, fo, fe, c, cac);
            }

            return tabla;
        } 

    }
}
