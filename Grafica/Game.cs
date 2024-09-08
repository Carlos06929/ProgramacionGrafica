using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    class Game : GameWindow
    {
        static float scale = 50.0f;
        EventosTeclado ev;
        static double angle = 0;
        Stage escenario1;
        public Game(int width, int height)
             : base(width, height)
        {
            ev = new EventosTeclado();
            escenario1= buildStage();

        }

        protected override void OnLoad(EventArgs e)
        {
            Color backgroundColor = Color.Green;
            GL.ClearColor(backgroundColor);
            GL.Enable(EnableCap.DepthTest);
            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }
            ev.CambioDeEscala(input, ref scale);

            base.OnKeyDown(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            //KeyboardState inputKey = Keyboard.GetState();
            /*
             * Codigo para aplicacion de 2d
             * angle += 1.0;
            if (angle > 360)
            {
                angle -= 360;
            }*/
            angle += 1.0;
            if (angle > 360)
            {
                angle -= 360;
            }
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //escenario1.setCenter(new Point(5.0f, 0.0f, -20.0f));
            //GL.PushMatrix();
            //GL.Rotate(angle, 0.2f, 0.0f, 0.0f);
            // Dibujar ejes de coordenadas
            GL.PushMatrix();
            //GL.Rotate(20, 1.0, 0.0, 0);

            GL.Begin(PrimitiveType.Lines);
            // Eje X (rojo)
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(10, 0, 0);
            GL.Vertex3(-10, 0, 0);
            // Eje Y (verde)
            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(0, 10, 0);
            GL.Vertex3(0, -10, 0);
            // Eje Z (azul)
            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 5);
            GL.End();
            GL.Rotate(angle, 0.1, 0.0, 0.0);

            escenario1.Draw();
            //this.escenario1.Draw();
            //GL.PopMatrix();


            //Letra letra = new Letra(Color.White, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0);
            //letra.Rotar(angle, 0.0, 0.0, 1.0);
            //letra.Dibujar();

            //Letra letra1 = new Letra(Color.Black, -5.0, 0.0, -20.0, 0.5, 0.5, 0.5);
            //letra1.Rotar(angle, 0.0, 1.0, 0.0);
            //letra1.Dibujar();
            GL.PopMatrix();
      

            /*Codigo para aplicacion de 2d
             * 
             * GL.Rotate(angle, 0.0, 0.0, 1.0);
            GL.Begin(PrimitiveType.Quads);
            //Tomando referencia los numeros de un Dado, tomo los sgtes lados:
            GL.Color3(Color.Red);
            GL.Vertex2(-20.00,20.00);

            GL.Color3(Color.Aqua);
            GL.Vertex2(-20.00, -20.00);

            GL.Color3(Color.Bisque);
            GL.Vertex2(20.00, -20.00);

            GL.Color3(Color.Azure);
            GL.Vertex2(20.00, 20.00);*/

            //Lado #1(Frente)


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }



        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f),
                Width / (float)Height,
                0.1f,  // Near plane
                100.0f // Far plane
            );
            GL.LoadMatrix(ref perspectiveMatrix);

            // Configurar la matriz de vista para mover la cámara hacia atrás
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Vector3 eye = new Vector3(0, 0, 20);  // Posición de la cámara
            Vector3 target = Vector3.Zero;  // Punto al que mira la cámara
            Vector3 up = Vector3.UnitY;  // Vector "arriba"
            Matrix4 viewMatrix = Matrix4.LookAt(eye, target, up);
            GL.LoadMatrix(ref viewMatrix);

            base.OnResize(e);
        }

        public Stage buildStage()
        {

            Dictionary<string, Polygon> parte1 = new Dictionary<string, Polygon>();
            Dictionary<string, Part> objeto1 = new Dictionary<string, Part>();
            Stage escenario1 = new Stage();

            //Stage stage = new Stage();
            //Object objeto = new Object();
            //Part part = new Part();
            //Polygon polygon = new Polygon();

            Dictionary<string, Point> frente = new Dictionary<string, Point>
            {

                { "punto3", new Point(-1.0f, 0.0f, 1.0f) },
                { "punto4", new Point(-1.0f, -3.0f, 1.0f) },
                { "punto5", new Point(1.0f, -3.0f, 1.0f) },
                { "punto6", new Point(1.0f, 0.0f, 1.0f) },
                { "punto7", new Point(4.0f, 0.0f, 1.0f) },
                { "punto8", new Point( 4.0f, 2.0f, 1.0f) },
                { "punto1", new Point(-4.0f, 2.0f, 1.0f) },
                { "punto2", new Point(-4.0f, 0.0f, 1.0f) },
                { "punto9", new Point(-1.0f, 0.0f, 1.0f) },
            };

            Dictionary<string, Point> posterior = new Dictionary<string, Point>
            {
                { "punto3", new Point(-1.0f, 0.0f, -1.0f) },
                { "punto4", new Point(-1.0f, -3.0f, -1.0f) },
                { "punto5", new Point(1.0f, -3.0f, -1.0f) },
                { "punto6", new Point(1.0f, 0.0f, -1.0f) },
                { "punto7", new Point(4.0f, 0.0f, -1.0f) },
                { "punto8", new Point( 4.0f, 2.0f, -1.0f) },
                { "punto1", new Point(-4.0f, 2.0f, -1.0f) },
                { "punto2", new Point(-4.0f, 0.0f, -1.0f) },
                { "punto9", new Point(-1.0f, 0.0f, -1.0f) },
            };

            Dictionary<string, Point> lateral1 = new Dictionary<string, Point>
            {

                { "punto3", new Point(-1.0f, 0.0f, 1.0f) },
                { "punto4", new Point(-1.0f, -3.0f, 1.0f) },

                { "punto5", new Point(1.0f, -3.0f, 1.0f) },
                { "punto6", new Point(1.0f, 0.0f, 1.0f) },
                { "punto7", new Point(4.0f, 0.0f, 1.0f) },
                { "punto8", new Point( 4.0f, 2.0f, 1.0f) },
                { "punto1", new Point(-4.0f, 2.0f, 1.0f) },
                { "punto2", new Point(-4.0f, 0.0f, 1.0f) },

                { "punto11", new Point(-1.0f, 0.0f, -1.0f) },
                { "punto12", new Point(-1.0f, -3.0f, -1.0f) },
                { "punto13", new Point(1.0f, -3.0f, -1.0f) },
                { "punto14", new Point(1.0f, 0.0f, -1.0f) },
                { "punto15", new Point(4.0f, 0.0f, -1.0f) },
                { "punto16", new Point( 4.0f, 2.0f, -1.0f) },
                { "punto17", new Point(-4.0f, 2.0f, -1.0f) },
                { "punto18", new Point(-4.0f, 0.0f, -1.0f) },
                { "punto9", new Point(-1.0f, 0.0f, -1.0f) },
                { "punto10", new Point(-1.0f, 0.0f, 1.0f) },
            };

            Dictionary<string, Point> arriba = new Dictionary<string, Point>
            {
                { "punto1", new Point(-4.0f, 2.0f, 1.0f) },
                { "punto8", new Point( 4.0f, 2.0f, 1.0f) },
                { "punto16", new Point( 4.0f, 2.0f, -1.0f) },
                { "punto9", new Point(-4.0f, 2.0f, -1.0f) },
            };

            Dictionary<string, Point> abajo = new Dictionary<string, Point>
            {
                { "punto2", new Point(-4.0f, 0.0f, 1.0f) },
                { "punto7", new Point(4.0f, 0.0f, 1.0f) },
                { "punto15", new Point(4.0f, 0.0f, -1.0f) },
                { "punto10", new Point(-4.0f, 0.0f, -1.0f) },
            };

            Dictionary<string, Point> abajo_inferior = new Dictionary<string, Point>
            {
                { "punto4", new Point(-1.0f, -3.0f, 1.0f) },
                { "punto5", new Point(1.0f, -3.0f, 1.0f) },
                { "punto13", new Point(1.0f, -3.0f, -1.0f) },
                { "punto12", new Point(-1.0f, -3.0f, -1.0f) },
            };

            Dictionary<string, Point> iz_arriba = new Dictionary<string, Point>
            {
                { "punto1", new Point(-4.0f, 2.0f, 1.0f) },
                { "punto2", new Point(-4.0f, 0.0f, 1.0f) },
                { "punto10", new Point(-4.0f, 0.0f, -1.0f) },
                { "punto9", new Point(-4.0f, 2.0f, -1.0f) },
            };

            Dictionary<string, Point> iz_abajo = new Dictionary<string, Point>
            {
                { "punto3", new Point(-1.0f, 0.0f, 1.0f) },
                { "punto4", new Point(-1.0f, -3.0f, 1.0f) },
                { "punto12", new Point(-1.0f, -3.0f, -1.0f) },
                { "punto11", new Point(-1.0f, 0.0f, -1.0f) },
            };

            Dictionary<string, Point> de_arriba = new Dictionary<string, Point>
            {
                { "punto7", new Point(4.0f, 0.0f, 1.0f) },
                { "punto8", new Point( 4.0f, 2.0f, 1.0f) },
                { "punto16", new Point( 4.0f, 2.0f, -1.0f) },
                { "punto15", new Point(4.0f, 0.0f, -1.0f) },
            };

            Dictionary<string, Point> de_abajo = new Dictionary<string, Point>
            {
                { "punto5", new Point(1.0f, -3.0f, 1.0f) },
                { "punto6", new Point(1.0f, 0.0f, 1.0f) },
                { "punto14", new Point(1.0f, 0.0f, -1.0f) },
                { "punto13", new Point(1.0f, -3.0f, -1.0f) },
            };
            /*Dictionary<string,Point> vertices1 = new Dictionary<string,Point>();
            vertices1.Add("punto1",new Point(-4.0f, -1.0f, 1.0f));
            vertices1.Add("punto2",new Point(4.0f, -1.0f, 1.0f));
            vertices1.Add("punto3",new Point(4.0f, 1.0f, 1.0f));
            vertices1.Add("punto4", new Point(-4.0f, 1.0f, 1.0f));

            Dictionary<string, Point> vertices2 =new Dictionary<string, Point>();
            vertices2.Add("punto1", new Point(-4.0f, -1.0f, -1.0f));1
            vertices2.Add("punto2", new Point(-4.0f, -1.0f, 1.0f));
            vertices2.Add("punto3", new Point(-4.0f, 1.0f, 1.0f));
            vertices2.Add("punto4", new Point(-4.0f, 1.0f, -1.0f));

            Dictionary<string, Point> vertices3 = new Dictionary<string, Point>();
            vertices3.Add("punto1", new Point(-4.0f, -1.0f, -1.0f));
            vertices3.Add("punto2", new Point(4.0f, -1.0f, -1.0f));
            vertices3.Add("punto3", new Point(4.0f, -1.0f, 1.0f));
            vertices3.Add("punto4", new Point(-4.0f, -1.0f, 1.0f));


            Dictionary<string, Point> vertices4 = new Dictionary<string, Point>();
            vertices4.Add("punto1", new Point(-4.0f, 1.0f, -1.0f));
            vertices4.Add("punto2", new Point(-4.0f, 1.0f, 1.0f));
            vertices4.Add("punto3", new Point(4.0f, 1.0f, 1.0f));
            vertices4.Add("punto4", new Point(4.0f, 1.0f, -1.0f));

            Dictionary<string, Point> vertices5 = new Dictionary<string, Point>();
            vertices5.Add("punto1", new Point(4.0f, 1.0f, -1.0f));
            vertices5.Add("punto2", new Point(4.0f, 1.0f, 1.0f));
            vertices5.Add("punto3", new Point(4.0f, -1.0f, 1.0f));
            vertices5.Add("punto4", new Point(4.0f, -1.0f, -1.0f));

            Dictionary<string, Point> vertices6 = new Dictionary<string, Point>();
            vertices6.Add("punto1", new Point(-4.0f, -1.0f, -1.0f));
            vertices6.Add("punto2", new Point(4.0f, -1.0f, -1.0f));
            vertices6.Add("punto3", new Point(4.0f, 1.0f, -1.0f));
            vertices6.Add("punto4", new Point(-4.0f, 1.0f, -1.0f));*/
            Point centro_poligono = new Point(0.0f, 0.0f, 0.0f);
            parte1.Add("poligono1", new Polygon(centro_poligono, frente, Color.BlueViolet));
            parte1.Add("poligono2", new Polygon(centro_poligono, posterior, Color.BlueViolet));
            parte1.Add("poligono3", new Polygon(centro_poligono, arriba, Color.Black));
            parte1.Add("poligono4", new Polygon(centro_poligono, abajo, Color.Black));
            parte1.Add("poligono5", new Polygon(centro_poligono, iz_arriba, Color.Black));
            parte1.Add("poligono6", new Polygon(centro_poligono, iz_abajo, Color.Black));
            parte1.Add("poligono7", new Polygon(centro_poligono, de_arriba, Color.Black));
            parte1.Add("poligono8", new Polygon(centro_poligono, de_abajo, Color.Black));
            parte1.Add("poligono9", new Polygon(centro_poligono, abajo_inferior, Color.Black));
            
            objeto1.Add("parte1", new Part(new Point(), parte1, Color.BlueViolet));

            escenario1.addElement("objeto1", new Object(new Point(), objeto1, Color.BlueViolet));





            //parte1.Add("poligono2", new Polygon(new Point(5.0f, 0.0f, -20.0f), vertices2, Color.BlueViolet));
            //parte1.Add("poligono3",new Polygon(new Point(5.0f, 0.0f, -20.0f), vertices3, Color.BlueViolet));
            //parte1.Add("poligono4",new Polygon(new Point(5.0f, 0.0f, -20.0f), vertices4, Color.BlueViolet));
            //parte1.Add("poligono5",new Polygon(new Point(5.0f, 0.0f, -20.0f), vertices5, Color.BlueViolet));
            //parte1.Add("poligono6",new Polygon(new Point(5.0f, 0.0f, -20.0f), vertices6, Color.BlueViolet));



            return escenario1;
        }

    }
}
