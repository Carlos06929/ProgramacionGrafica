using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Stage : IClass
    {
        public Point center;
        public Dictionary<string, Object> ListElement;
        public Color color;
        public Transformation Transformations { get; set; }

        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Stage()
        {
            this.ListElement = new Dictionary<string, Object>();
            this.center = new Point();
            this.color = Color.Pink;
            Transformations = new Transformation(center);

        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Stage(Point center, Dictionary<string, Object> objects, Color c)
        {
            this.ListElement = new Dictionary<string, Object>();
            this.center = new Point(center);
            this.color = c;
            Transformations = new Transformation(center);

            foreach (var objeto in objects)
                addElement(objeto.Key, new Object(objeto.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Stage(Stage stage)
        {
            this.center = new Point(stage.center);
            this.color = stage.color;
            this.ListElement = new Dictionary<string, Object>();
            Transformations = new Transformation(center);

            foreach (var objeto in stage.ListElement)
                addElement(objeto.Key, new Object(objeto.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Object x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            x.center.adicionar(this.center);
            ListElement.Add(name, x);
        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }


        public void Draw()
        {
            foreach (var objeto in this.ListElement) {
                objeto.Value.Draw();
            }

        }

        public Object getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }

        public void SetCenter(Point center)
        {
            foreach (var objeto in ListElement)
            {
                Point formerCenter = Point.Vector4ToVertex(objeto.Value.GetCenter().Row3);
                objeto.Value.SetCenter(center + formerCenter);
            }
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var objeto in ListElement)
            {
                objeto.Value.Rotate(angleX, angleY, angleZ);
            }
        }



        public void Traslate(float x, float y, float z)
        {
            foreach (var objeto in ListElement)
                objeto.Value.Traslate(x, y, z);
        }

        public void Traslate(Point position)
        {
            foreach (var objeto in ListElement)
                objeto.Value.Traslate(position);
        }


        public void Scale(float x, float y, float z)
        {
            foreach (var objeto in ListElement)
                objeto.Value.Scale(x, y, z);
        }

        public void Scale(Point position)
        {
            foreach (var objeto in ListElement)
                objeto.Value.Scale(position);
        }



        IClass IClass.getElement(string name)
        {
            throw new NotImplementedException();
        }


    }
}
