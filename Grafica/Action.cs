using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Action
    {
        [JsonProperty] public List<string> nombreObjeto;
        [JsonProperty] public byte tipoObjeto;  //escenario = 0, objeto = 1, cara = 2
        [JsonProperty] public long tiempoI;
        [JsonProperty] public long tiempoF;
        [JsonProperty] public long tiempoSiguiente;
        [JsonProperty] public List<byte> accion;  //escalara = 1, rotar = 1, trasladar = 1
        [JsonProperty] public List<float> parametros;
        [JsonProperty] public long cuantas;

        public Action() : this(null, null, null, 0, 0, 0, 0) { }

        public Action(List<string> objeto, List<byte> accion, List<float> parametros, long tiempoI, long tiempoF, byte tipoObjeto, long cuantas)
        {
            this.nombreObjeto = objeto;
            this.accion = accion;
            this.parametros = parametros;
            this.tiempoI = this.tiempoSiguiente = tiempoI;
            this.tiempoF = tiempoF;
            this.tipoObjeto = tipoObjeto;
            this.cuantas = cuantas;
        }

    }
}
