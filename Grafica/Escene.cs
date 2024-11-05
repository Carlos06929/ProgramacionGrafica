using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Escene
    {
        [JsonProperty] string nombre { get; set; }
        [JsonProperty] public List<Action> acciones { get; set; }
        [JsonProperty] long tiempoDeDuracion;
        public Escene()
        {
            acciones = new List<Action>();
            tiempoDeDuracion = 0;
            nombre = "";
        }
        public Escene(string nombre, List<Action> lista)
        {
            this.nombre = nombre;
            acciones = lista;
            tiempoDeDuracion = 0;
            for (int i = 0; i < lista.Count; i++)
                tiempoDeDuracion += (lista.ElementAt(i).tiempoF - lista.ElementAt(i).tiempoI);
        }
        public void setAccion(Action x)
        {
            acciones.Add(x);
        }
        public Action getAccion(int i)
        {
            return acciones.ElementAt(i);
        }
        public int getCantidad()
        {
            return acciones.Count;
        }
    }
}
