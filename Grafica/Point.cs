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

    }
}
