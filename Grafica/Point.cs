using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Point
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        //contructor con parametros---------------------------------------------------------
        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //constructor por defecto------------------------------------------------------------
        public Point(): this(0, 0, 0) { }

        //Contructor copia-------------------------------------------------------------------
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.z = p.z;
        }

        public void Set(Point newVertex)
        {
            this.x = newVertex.x;
            this.y = newVertex.y;
            this.z = newVertex.z;
        }

        public Point Get()
        {
            return this;
        }

        public void adicionar(Point p)
        {
            this.x += p.x;
            this.y += p.y;
            this.z += p.z;
        }
        public void adicionar(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }

        public void sustraer(Point p)
        {
            this.x -= p.x;
            this.y -= p.y;
            this.z -= p.z;
        }
        public void sustraer(float x, float y, float z)
        {
            this.x -= x;
            this.y -= y;
            this.z -= z;
        }

        // Sobrecarga del operador +
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        // Sobrecarga del operador -
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        //Punto a Vector3-----------------------------------------------------------------------------------------------------------------
        public Vector3 ToVector3()
        {
            return new Vector3(this.x, this.y, this.z);
        }



        //Set mismo valor-----------------------------------------------------------------------------------------------------------------
        public void setPunto(float valor)
        {
            this.x = this.y = this.z = valor;
        }

        public override string ToString() => $"({x}|{y}|{z})";


        public static Point operator *(Point a, Matrix4 b)
        {
            return new Point(
                a.x * b.M11 + a.y * b.M21 + a.z * b.M31 + 1f * b.M41,
                a.x * b.M12 + a.y * b.M22 + a.z * b.M32 + 1f * b.M42,
                a.x * b.M13 + a.y * b.M23 + a.z * b.M33 + 1f * b.M43
            );
        }

        // Operador de división
        public static Point operator /(Point a, float b)
        {
            return new Point(a.x / b, a.y / b, a.z / b);
        }

        // Operador de multiplicación
        public static Point operator *(Point a, float b)
        {
            return new Point(b * a.x, b * a.y, b * a.z);
        }

        // Valor estático
        public static readonly Point Origin = new Point();

        // Operador de igualdad
        public static bool operator ==(Point a, Point b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        // Operador de desigualdad
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }

        // Conversión implícita a Vector3
        public static implicit operator Vector3(Point convert)
        {
            return new Vector3(convert.x, convert.y, convert.z);
        }

        // Conversión de Vector4 a Point
        public static Point Vector4ToVertex(Vector4 vector4)
        {
            return new Point(vector4.X, vector4.Y, vector4.Z);
        }

        // Comparación de igualdad
        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                var v = (Point)obj;
                return this == v;
            }
            return false;
        }

        // Obtener hash code
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

    }
}
