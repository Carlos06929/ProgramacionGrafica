using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Letra
    {
        private double angle, rx, ry, rz;
        private double x, y, z, anchoX, altoY, largoZ;
        Color color;

        public Letra(Color color, double traslationX = 0.0f, double traslationY = 0.0f, double traslationZ = 0.0f, double ancho = 0.0f, double alto = 0.0f, double profundidad = 0.0f)
        {
            this.x = traslationX; this.y = traslationY; this.z = traslationZ;
            this.anchoX = ancho; this.altoY = alto; this.largoZ = profundidad;
            this.angle = 0; rx = 0; ry = 0; rz = 0;
            this.color = color;
        }

        public void Rotar(double angulo, double x, double y, double z)
        {
            angle = angulo; rx = x; ry = y; rz = z;
        }
        public void Escalar(double ancho, double alto, double largo)
        {
            this.anchoX = ancho; this.altoY = alto; this.largoZ = largo;
        }
        public void Trasladar(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        public void Dibujar()
        {
            Color color = this.color;
            GL.PushMatrix();
            GL.Translate(this.x, this.y, this.z);
            GL.Rotate(angle, rx, ry, rz);
            GL.Scale(this.anchoX, this.altoY, this.largoZ);
            letraT();
            GL.PopMatrix();
        }

        public void letraT()
        {
            GL.Begin(PrimitiveType.Quads);
            //GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-4.0, -1.0, 1.0);
            GL.Vertex3(4.0, -1.0f, 1.0);
            GL.Vertex3(4.0, 1.0, 1.0);
            GL.Vertex3(-4.0, 1.0, 1.0);

            //Lado #2 (Izquierda)
            GL.Color3(Color.DarkGray);
            //GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(-4.0, -1.0, -1.0);
            GL.Vertex3(-4.0, -1.0, 1.0);
            GL.Vertex3(-4.0, 1.0, 1.0);
            GL.Vertex3(-4.0, 1.0, -1.0);

            //Lado #3 (Inferior)
            GL.Color3(Color.Azure);
            //GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(-4.0f, -1.0f, -1.0f);
            GL.Vertex3(4.0f, -1.0f, -1.0f);
            GL.Vertex3(4.0f, -1.0f, 1.0f);
            GL.Vertex3(-4.0f, -1.0f, 1.0f);

            //Lado #4 (Superior)
            GL.Color3(Color.CadetBlue);
            //GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(-4.0f, 1.0f, -1.0f);
            GL.Vertex3(-4.0f, 1.0f, 1.0f);
            GL.Vertex3(4.0f, 1.0f, 1.0f);
            GL.Vertex3(4.0f, 1.0f, -1.0f);

            //Lado #5 (Derecha)
            GL.Color3(Color.Brown);
            //GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3(4.0f, 1.0f, -1.0f);
            GL.Vertex3(4.0f, 1.0f, 1.0f);
            GL.Vertex3(4.0f, -1.0f, 1.0f);
            GL.Vertex3(4.0f, -1.0f, -1.0f);

            //Lado #6 (Atras)
            GL.Color3(Color.Black);
            //GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(-4.0f, -1.0f, -1.0f);
            GL.Vertex3(4.0f, -1.0f, -1.0f);
            GL.Vertex3(4.0f, 1.0f, -1.0f);
            GL.Vertex3(-4.0f, 1.0f, -1.0f);
            GL.End();


            GL.Begin(PrimitiveType.Quads);
            //GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-2.0, -5.0, 1.0);
            GL.Vertex3(2.0, -5.0f, 1.0);
            GL.Vertex3(2.0, -1.0, 1.0);
            GL.Vertex3(-2.0, -1.0, 1.0);

            //Lado #2 (Izquierda)
            GL.Color3(Color.DarkGray);
            //GL.Normal3(-1.0, 0.0, 0.0);
            GL.Vertex3(-2.0, -5.0, -1.0);
            GL.Vertex3(-2.0, -5.0, 1.0);
            GL.Vertex3(-2.0, -1.0, 1.0);
            GL.Vertex3(-2.0, -1.0, -1.0);

            //Lado #3 (Inferior)
            GL.Color3(Color.Azure);
            //GL.Normal3(0.0, -1.0, 0.0);
            GL.Vertex3(-2.0f, -5.0f, -1.0f);
            GL.Vertex3(2.0f, -5.0f, -1.0f);
            GL.Vertex3(2.0f, -5.0f, 1.0f);
            GL.Vertex3(-2.0f, -5.0f, 1.0f);

            //Lado #4 (Superior)
            GL.Color3(Color.CadetBlue);
            //GL.Normal3(0.0, 1.0, 0.0);
            GL.Vertex3(-2.0f, -1.0f, -1.0f);
            GL.Vertex3(-2.0f, -1.0f, 1.0f);
            GL.Vertex3(2.0f, -1.0f, 1.0f);
            GL.Vertex3(2.0f, -1.0f, -1.0f);

            //Lado #5 (Derecha)
            GL.Color3(Color.Brown);
            //GL.Normal3(1.0, 0.0, 0.0);
            GL.Vertex3(2.0f, -1.0f, -1.0f);
            GL.Vertex3(2.0f, -1.0f, 1.0f);
            GL.Vertex3(2.0f, -5.0f, 1.0f);
            GL.Vertex3(2.0f, -5.0f, -1.0f);

            //Lado #6 (Atras)
            GL.Color3(Color.Black);
            //GL.Normal3(0.0, 0.0, -1.0);
            GL.Vertex3(-2.0f, -5.0f, -1.0f);
            GL.Vertex3(2.0f, -5.0f, -1.0f);
            GL.Vertex3(2.0f, -1.0f, -1.0f);
            GL.Vertex3(-2.0f, -1.0f, -1.0f);
            GL.End();
        }
    }
}
