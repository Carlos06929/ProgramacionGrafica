﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Grafica
{
    class Polygon
    {
        [JsonProperty] public Point center;
        [JsonProperty] public Dictionary<string, Point> ListElement { get; set; }
        [JsonProperty] public Color color;
        public Transformation Transformations;


        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Polygon()
        {
            this.ListElement = new Dictionary<string, Point>();
            this.center = new Point();
            this.color = Color.Pink;
            Transformations = new Transformation(center);
        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Polygon(Point origin, Dictionary<string, Point> points, Color c)
        {
            this.ListElement = new Dictionary<string, Point>();
            this.center = new Point(origin);
            this.color = c;
            Transformations = new Transformation(center);
            foreach (var Points in points)
                addElement(Points.Key, new Point(Points.Value));
        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Polygon(Polygon Polygon)
        {
            this.center = new Point(Polygon.center);
            this.color = Polygon.color;
            this.ListElement = new Dictionary<string, Point>();
            Transformations = new Transformation(center);
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
            //Console.WriteLine(x.ToString());
            //x.adicionar(center);
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
            //GL.PushMatrix();
            //GL.Translate(this.center.x, this.center.y, this.center.z);

            /*GL.Begin(PrimitiveType.Polygon); //type de figura
            GL.Color4(color); //color de la Polygon
            foreach (var vertice in ListElement.Values) //dibujar los vertices
            {
                //GL.Vertex3((vertice.x), (vertice.y), (vertice.z));
                GL.Vertex3((this.center.x + vertice.x), (this.center.y + vertice.y), (this.center.z + vertice.z));


            }
            GL.End();
            //GL.PopMatrix();*/
            GL.Begin(PrimitiveType.Polygon);

            Transformations.SetTransformation();
            foreach (var vertex in ListElement)
            {
                Point vertexToRender = (vertex.Value) * Transformations.TransformationMatrix;
                GL.Vertex3(vertexToRender);
            }

            GL.End();
            GL.Flush();
        }

        public void setCenter(Point center)
        {
            foreach (var point in ListElement.Values)
            {
                point.x += this.center.x;
                point.y += this.center.y;
                point.z += this.center.z;
            }
        }

        //=========================================================
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            angleY = MathHelper.DegreesToRadians(angleY);
            angleZ = MathHelper.DegreesToRadians(angleZ);

            Transformations.Rotation *= Matrix4.CreateRotationX(angleX) * Matrix4.CreateRotationY(angleY) *
                        Matrix4.CreateRotationZ(angleZ);

        }

        public void Traslate(float x, float y, float z)
        {
            Transformations.Traslation *= Matrix4.CreateTranslation(x, y, z);
        }

        public void Traslate(Point position)
        {
            Traslate(position.x, position.y, position.z);
        }

        public void Scale(float x, float y, float z)
        {
            Transformations.Scaling *= Matrix4.CreateScale(x, y, z);
        }

        public void Scale(Point scale)
        {
            Transformations.Scaling *= Matrix4.CreateScale(scale);
        }

        public void SetCenter(Point newCenter)
        {
            this.center = newCenter;
            Transformations.Center = Matrix4.CreateTranslation(this.center);
        }


        public Matrix4 GetCenter()
        {
            return Transformations.Center;
        }

    }
}
