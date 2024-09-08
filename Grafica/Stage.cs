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


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Stage()
        {
            this.ListElement = new Dictionary<string, Object>();
            this.center = new Point();
            this.color = Color.Pink;
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Stage(Point center, Dictionary<string, Object> objects, Color c)
        {
            this.ListElement = new Dictionary<string, Object>();
            this.center = new Point(center);
            this.color = c;
            foreach (var objeto in objects)
                addElement(objeto.Key, new Object(objeto.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Stage(Stage stage)
        {
            this.center = new Point(stage.center);
            this.color = stage.color;
            this.ListElement = new Dictionary<string, Object>();
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

        public IClass getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
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
