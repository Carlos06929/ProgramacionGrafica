using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Grafica
{
    class Polygon:IClass
    {
        public Point center;
        public Dictionary<string, Point> ListElement;
        public Color color;


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Polygon()
        {
            this.ListElement = new Dictionary<string, Point>();
            this.center = new Point();
            this.color = Color.Pink;
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Polygon(Point origin, Dictionary<string, Point> points, Color c)
        {
            this.ListElement = points;
            this.center = new Point(origin);
            this.color = c;
        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Polygon(Polygon Polygon)
        {
            this.center = new Point(Polygon.center);
            this.color = Polygon.color;
            this.ListElement = new Dictionary<string, Point>();
            foreach (var Points in Polygon.ListElement)
                addElement(Points.Key, new Point(Points.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Point x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            ListElement.Add(name, x);
        }

        //Get elemento a lista--------------------------------------------------------------------------------------------------------------------
        public Point getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }

        //--------------------------------------------------------------------------------------------------------------------
        public void Draw()
        {
            GL.PushMatrix();
            GL.Begin(PrimitiveType.Polygon); //type de figura
            GL.Color4(color); //color de la Polygon
            foreach (var vertice in ListElement.Values) //dibujar los vertices
                GL.Vertex3((this.center.x + vertice.x), (this.center.y + vertice.y), (this.center.z + vertice.z));
            GL.End();
            GL.PopMatrix();
        }

        public void setCenter(Point center)
        {
            this.center.x = center.x;
            this.center.y = center.y;
            this.center.z = center.z;
        }

        public IClass getElement()
        {
            throw new NotImplementedException();
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }
    }
}
