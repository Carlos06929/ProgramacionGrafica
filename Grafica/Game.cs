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
    class Game:GameWindow
    {
        static float scale = 50.0f;
        EventosTeclado ev;
        static double angle = 0;

        public Game(int width, int height)
             : base(width, height)
        {
            ev = new EventosTeclado();
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
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();
            GL.Rotate(angle, 0.0, 0.0, 0.5);

            Letra letra = new Letra(Color.White, 5.0, 0.0, -20.0, 1.0, 1.0, 1.0);
            letra.Rotar(angle, 0.0, 0.0,1.0);
            letra.Dibujar();

            Letra letra1 = new Letra(Color.Black, -5.0, 0.0, -20.0, 0.5, 0.5, 0.5);
            letra1.Rotar(angle, 0.0, 1.0, 0.0);
            letra1.Dibujar();
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
            //GL.Frustum(-5.00, 5.0, -5.0, 5.0, 1.0, 100.0);
            Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Width / Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(-5.00,5.0,-5.0,5.0,1.0,100.0); //Codigo para aplicacion de 2d
            GL.MatrixMode(MatrixMode.Modelview);
            base.OnResize(e);
        }

    }
}
