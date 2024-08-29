using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Part : IClass
    {
        public Point center;
        public Dictionary<string, Polygon> ListElement;
        public Color color;


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Part()
        {
            this.ListElement = new Dictionary<string, Polygon>();
            this.center = new Point();
            this.color = Color.Pink;
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Part(Point origin, Dictionary<string, Polygon> points, Color c)
        {
            this.ListElement = points;
            this.center = new Point(origin);
            this.color = c;
        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Part(Part Part)
        {
            this.center = new Point(Part.center);
            this.color = Part.color;
            this.ListElement = new Dictionary<string, Polygon>();
            foreach (var Polygons in Part.ListElement)
                addElement(Polygons.Key, new Polygon(Polygons.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Polygon x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            ListElement.Add(name, x);
        }

        //Get elemento a lista--------------------------------------------------------------------------------------------------------------------
        public IClass getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void setCenter(Point center)
        {
            this.center.x = center.x;
            this.center.y = center.y;
            this.center.z = center.z;
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

    }
}
