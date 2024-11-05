using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grafica
{
    class DriverAnimation
    {

        Libretto libreto;
        Thread hilo;
        bool sw;

        public DriverAnimation()
        {
            this.libreto = new Libretto(this.getEscena());
            hilo = new Thread(new ThreadStart(play));

            sw = true;
        }
        public void iniciarAnimacion()
        {
            hilo.Start();
        }

        public void play()
        {
            int dur = 9999;
            int tiempoInicial = Environment.TickCount & Int32.MaxValue;
            //int tiempo = Environment.TickCount & Int32.MaxValue;
            //int tiempoFinal = tiempo + dur;
            int tiempoActual = 0;
            //int i = 0;
            Escene escena = this.libreto.escenas.ElementAt(0);
            Action accion; //= this.libreto.escenas.ElementAt(0).acciones.ElementAt(0);


            do
            {
                for (int i = 0; i < escena.getCantidad(); i++)
                {
                    Console.WriteLine(tiempoActual);

                    tiempoActual = (Environment.TickCount & Int32.MaxValue) - tiempoInicial;
                    accion = escena.getAccion(i);
                    if (tiempoActual >= accion.tiempoI && tiempoActual <= accion.tiempoF)
                    {
                        reproducirAccion(accion, tiempoActual);
                    }
                }


            } while (tiempoActual <= dur);
        }


        public void reproducirAccion(Action a, int tiempoActual)
        {

            if (a.accion[0] == 1) //escalar
            {
                escalar(a, a.parametros, tiempoActual);
            }
            if (a.accion[1] == 1)//rotar
            {
                rotar(a, a.parametros, tiempoActual);
            }
            if (a.accion[2] == 1)//trasladar
            {
                trasladar(a, a.parametros, tiempoActual);
            }
        }



        public void trasladar(Action a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / a.cuantas;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    Game.escenario1.Traslate(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).Traslate(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).getElement(a.nombreObjeto[1]).Traslate(par[0], par[1], par[2]);
                }
            }
   
        }

        public void rotar(Action a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / a.cuantas;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    Game.escenario1.Rotate(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).Rotate(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).getElement(a.nombreObjeto[1]).Rotate(par[0], par[1], par[2]);
                }
            }
        }

        public void escalar(Action a, List<float> par, int tiempoActual)
        {
            float tiempo = a.tiempoF - a.tiempoI;
            float cada = tiempo / a.cuantas;
            //Console.WriteLine(cada);
            //if (tiempoActual % cada == 0 && tiempoActual >= a.tiempoSiguiente)
            if (tiempoActual >= a.tiempoSiguiente)
            {
                a.tiempoSiguiente += (long)cada;
                //Console.WriteLine(tiempoActual);
                if (a.tipoObjeto == 0)
                {
                    //Game.escenario1.Escalar(par[0], par[1], par[2]);
                    Game.escenario1.Scale(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 1)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).Scale(par[0], par[1], par[2]);
                }
                else if (a.tipoObjeto == 2)
                {
                    Game.escenario1.getElement(a.nombreObjeto[0]).getElement(a.nombreObjeto[1]).Scale(par[0], par[1], par[2]);
                }
            }
        }

        public List<Escene> getEscena()
        {

            //Accion p = new Accion(new List<string>() { "" }, new List<byte>() { 0, 1, 0}, new List<float>() { 0, -1, 0 }, 0, 500, 1, 12) ;

            Escene e = new Escene("animacion1", new List<Action>()
            {

                 new Action(new List<string>() { "cuerpo_detallado","" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 1.9f, 0, 0 }, 0, 10000, 1, 1000),
                //new Action(new List<string>() { "objeto2" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 1.9f, 0, 0 }, 0, 10000, 1, 1000),
                new Action(new List<string>() { "cuerpo_detallado" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1f, 0 }, 0, 3000, 1, 300),
                new Action(new List<string>() { "cuerpo_detallado" }, new List<byte>() { 0, 1, 0 }, new List<float>() { 0, 1f, 0 }, 3000, 5000, 1, 100),
                new Action(new List<string>() { "" }, new List<byte>() { 0, 0, 1 }, new List<float>() { 0, 1f, 0 }, 5000, 7000, 0, 100),
                //new Action(new List<string>() { "" }, new List<byte>() { 0, 0, 1 }, new List<float>() { 0, -1f, 0 }, 5000, 7000, 0, 100),
                new Action(new List<string>() { "" }, new List<byte>() { 0, 0, 1 }, new List<float>() { 0, -1f, 0 }, 7000, 10000, 0, 100),

             });
            List<Escene> lista = new List<Escene>() { e };
            return lista;
        }
    }
}
