using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proto
{
    class Nodo
    {
        private int dato;
        private Nodo sig;

        public Nodo(int vdato)
        {
            this.dato = vdato;
        }

        public int Dato
        {
            get
            {
                return this.dato;
            }
            set
            {
                this.dato = value;
            }
        }

        public Nodo Sig
        {
            get
            {
                return this.sig;
            }
            set
            {
                this.sig = value;
            }
        }
    }
}
