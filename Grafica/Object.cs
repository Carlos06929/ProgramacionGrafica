using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    [JsonObject(MemberSerialization.OptIn)]
    class Object : IClass
    {
        [JsonProperty] public Point center;
        [JsonProperty] public Dictionary<string, Part> ListElement;
        [JsonProperty] public Color color;


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Object()
        {
            this.ListElement = new Dictionary<string, Part>();
            this.center = new Point();
            this.color = Color.Pink;
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Object(Point center, Dictionary<string, Part> parts, Color c)
        {
            this.ListElement = new Dictionary<string, Part>();
            this.center = new Point(center);
            this.color = c;
            foreach (var part in parts)
                addElement(part.Key, new Part(part.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Object(Object objeto)
        {
            this.center = new Point(objeto.center);
            this.color = objeto.color;
            this.ListElement = new Dictionary<string, Part>();
            foreach (var part in objeto.ListElement)
                addElement(part.Key, new Part(part.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Part x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            //x.center.adicionar(this.center);
            ListElement.Add(name, x);
        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            foreach (var part in this.ListElement)
            {
                part.Value.Draw();

            }
        }

        public IClass getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }

        public void setCenter(Point center)
        {
            this.center = center;
            foreach (var part in ListElement.Values)
            {
                part.setCenter(center);
                //part.center.x += this.center.x;
                //part.center.y += this.center.y;
                //part.center.z += this.center.z;
            }
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

    }
}
