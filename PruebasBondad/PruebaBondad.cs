using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_VariablesAleatorias.Distribuciones
{
    public abstract class PruebaBondad {
        protected Distribucion distribucion;

        public PruebaBondad(Distribucion distribucion)
        { 
            this.distribucion = distribucion;
        }
    }
}
