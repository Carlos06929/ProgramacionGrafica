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
    class Part : IClass
    {
        [JsonProperty] public Point center;
        [JsonProperty] public Dictionary<string, Polygon> ListElement;
        [JsonProperty] public Color color;


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Part()
        {
            this.ListElement = new Dictionary<string, Polygon>();
            this.center = new Point();
            this.color = Color.Pink;
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Part(Point origin, Dictionary<string, Polygon> poligonos, Color c)
        {
            this.ListElement = new Dictionary<string, Polygon>();
            this.center = new Point(origin);
            this.color = c;
            foreach (var poligono in poligonos)
                addElement(poligono.Key, new Polygon(poligono.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Part(Part Part)
        {
            this.center = new Point(Part.center);
            this.color = Part.color;
            this.ListElement = new Dictionary<string, Polygon>();
            foreach (var poligono in Part.ListElement)
                addElement(poligono.Key, new Polygon(poligono.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Polygon x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            //x.center.adicionar(this.center);
            ListElement.Add(name, x);
        }

        public void setCenter(Point center)
        {
            this.center = center;
            foreach (var polygon in ListElement.Values)
            {
                //polygon.setCenter(center);
                polygon.center.x += this.center.x;
                polygon.center.y += this.center.y;
                polygon.center.z += this.center.z;
            }
        }

        //Get elemento a lista--------------------------------------------------------------------------------------------------------------------
        public IClass getElement(string name)
        {
            //return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
            throw new NotImplementedException();

        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            foreach (var poligono in this.ListElement)
            {
                poligono.Value.Draw();
            }
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

  

    }
}
