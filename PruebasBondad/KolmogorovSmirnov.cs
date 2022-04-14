using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3_VariablesAleatorias.Distribuciones;


namespace TP3_VariablesAleatorias.PruebasBondad
{
    internal class KolmogorovSmirnov : PruebaBondad
    {

        private double[] pE, pO, acPO, acPE, absDiffAc, columnaMaximos;
        private int N;
        private double ksCalculado;
        private double ksTabulado;

        public KolmogorovSmirnov(Distribucion distribucion) : base(distribucion)
        {
            tabla = new Dictionary<double, double>
            { { 1, 0.97500 }, { 2, 0.84189 }, { 3, 0.70760 }, { 4, 0.62394 }, { 5, 0.56328 },{ 6, 0.51926 }, { 7, 0.48342 }, { 8, 0.45427 }, { 9, 0.43001 }, { 10, 0.40925 }, { 11, 0.39122 }, { 12, 0.37543 }, { 13, 0.36143 }, { 14, 0.34890 }, { 15, 0.33750 }, { 16, 0.32733 }, { 17, 0.31796 }, { 18, 0.30936 }, { 19, 0.30143 }, { 20, 0.29408 }, { 21, 0.28724 }, { 22, 0.28087 }, { 23, 0.27490 }, { 24, 0.26931 }, { 25, 0.26404 }, { 26, 0.25908 }, { 27, 0.25438 }, { 28, 0.24993 }, { 29, 0.24571 }, { 30, 0.24170 }, { 31, 0.23788 }, { 32, 0.23424 }, { 33, 0.23076 }, { 34, 0.22743 }, { 35, 0.22425 } };
        }

        public override Tuple<bool, double, double, string> realizarPrueba()
        {
            if (distribucion.esPoisson()) Tuple.Create(false, -1, -1, "NO se realiza KS para distribuciones POISSON");

            intervalosDesde = distribucion.getIntervalosDesde();
            intervalosHasta = distribucion.getIntervalosHasta();
            frecuenciasObservadas = distribucion.getFrecuenciasObservadas();
            frecuenciasEsperadas = distribucion.getFrecuenciasEsperadas();
            pE = distribucion.getProbabilidadEsperada();

            calcularColumnasRestantes();
            calcularKs();

            return Tuple.Create(noSeRechaza(), ksCalculado, ksTabulado, generarCadenaResultado());
        }

        protected override bool noSeRechaza()
        {
            return ksCalculado < ksTabulado;
        }

        private void calcularKs()
        {
            ksCalculado = columnaMaximos[columnaMaximos.Length - 1];
            ksTabulado = 1.36 / Math.Sqrt(N);
            if(N <= 35)
            {
                ksTabulado = tabla[N];
            }
        }
        
        public override bool esChiCuadrado() { return false; }

        public Tuple<string, string, double, double, double, double, double, Tuple<double, double, double>> obtenerFila(int indiceFila)
        {
            return null;
        }

        private void calcularColumnasRestantes()
        {
            N = distribucion.getNMuestras();

            pO[0] = frecuenciasObservadas[0] / N;
            acPE[0] = pE[0];
            acPO[0] = pO[0];
            absDiffAc[0] = acPO[0] - acPE[0];
            columnaMaximos[0] = absDiffAc[0];
            for (int i = 1; i < frecuenciasObservadas.Length; i++)
            {
                pO[i] = frecuenciasObservadas[i] / N;
                acPE[i] = pE[i] + acPE[i - 1];
                acPO[i] = pO[i] + acPO[i - 1];
                absDiffAc[i] = acPO[i] - acPE[i];
                columnaMaximos[i] = Math.Max(columnaMaximos[i - 1], absDiffAc[i]);

            }
        } 
    }
}
