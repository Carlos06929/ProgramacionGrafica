using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Libretto
    {
        public List<Escene> escenas { get; set; }

        public Libretto()
        {
            escenas = new List<Escene>();
        }

        public Libretto(List<Escene> escenas)
        {
            this.escenas = escenas;
        }

        public Escene GetEscena(int i)
        {
            return escenas.ElementAt(i);
        }


        public void SetEscena(Escene e)
        {
            escenas.Add(e);
        }
    }
}
