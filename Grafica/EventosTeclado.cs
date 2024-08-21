using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class EventosTeclado
    {
        public EventosTeclado()
        { }

        public void CambioDeEscala(KeyboardState e, ref float scale)
        {
            if (e.IsKeyDown(Key.KeypadAdd) && scale > 0)
            {
                scale--;
            }
            if (e.IsKeyDown(Key.KeypadMinus) && scale < 300)
            {
                scale++;
            }
        }
    }
}
