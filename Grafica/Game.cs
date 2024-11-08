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
        static float scale = 1.0f;
        EventosTeclado ev;
        static double angle = 0;
        public static Stage escenario1;
        DriverAnimation da;
        public Game(int width, int height)
             : base(width, height)
        {
            ev = new EventosTeclado();
            escenario1= buildStage();
            //parte1 = buildPart();

        }

        protected override void OnLoad(EventArgs e)
        {
            Color backgroundColor = Color.Green;
            GL.ClearColor(backgroundColor);
            GL.Enable(EnableCap.DepthTest);
            //parte1.getElement("poligono1").Traslate(5.0f, 0.0f, 0.0f);
            //parte1.getElement("poligono2").Traslate(-5.0f, 0.0f, 0.0f);
            //parte1.getElement("poligono2").Rotate(0.0f, 30f, 0.0f);
            //parte1.Rotate(30f,180f,0.0f);
            //------------------------------
            //escenario1 = new Stage();
            //Object objeto1 = (Object)escenario1.getElement("objeto1");
            //Object.SerializeJsonFile("letra.json", objeto1);
            //escenario1.addElement("objeto1", Object.DeserializeJsonFile("letra.json"));
            //escenario1.addElement("objeto2", Object.DeserializeJsonFile("letra.json"));
            //escenario1.getElement("objeto1").Traslate(-5,0,0.0f);
            //escenario1.getElement("objeto2").Traslate(5, 5, 0.0f);
            //escenario1.getElement("objeto3").Traslate(8,-5, 0.0f);
            //escenario1.getElement("objeto2").Rotate(45, 0, 0.0f);

            //escenario1.getElement("objeto2").Rotate(0,0, 0.0f);
            //escenario1.getElement("objeto2").Scale(3, 1, 1f);
            //escenario1.getElement("objeto2").getElement("parte1").Scale(0.5f, 0.5f, 0.5f);
            //escenario1.getElement("objeto2").getElement("parte1").Rotate(0, 0, 0);

            //escenario1.SetCenter (new Point(5.0f, 5.0f, 0.0f));
            //escenario1.Traslate(0.0f,0.0f,0.0f);
            //escenario1.Scale(0.5f, 0.5f, 0.5f);
            //escenario1.Rotate(0f, 0.0f, 0.0f);
            //escenario1.getElement("letra_t").getElement("parte_inferior").Traslate(7f, 10f, 0.0f);
            //escenario1.getElement("cuerpo_detallado").Rotate(0, -180f, 0);
            escenario1.Rotate(0, -90f, 0);

            da = new DriverAnimation();
            //da.iniciarAnimacion();

            //escenario1.getElement("objeto2").setCenter( new Point(-5, 0, -20));
            //parte1.getElement
            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Exit();
            }


            if (input.IsKeyDown(Key.Q) && scale > 0)
            {
                scale-=0.1f;
                escenario1.getElement("objeto2").getElement("parte1").Scale(scale, scale, scale);                                                                                                                             

            }
            if (input.IsKeyDown(Key.W) && scale < 10)
            {
                scale += 0.1f;
                escenario1.getElement("objeto2").getElement("parte1").Scale(scale,scale,scale);
            }


            if (input.IsKeyDown(Key.A))
            {
                escenario1.getElement("objeto2").getElement("parte1").Rotate(1, 0, 0);
            }
            if (input.IsKeyDown(Key.S))
            {
                escenario1.getElement("objeto2").getElement("parte1").Rotate(0, 1, 0);
            }
            if (input.IsKeyDown(Key.D))
            {
                escenario1.getElement("objeto2").getElement("parte1").Rotate(0, 0, 1);
            }
            if (input.IsKeyDown(Key.Z))
            {
                escenario1.getElement("objeto2").getElement("parte1").Traslate(1, 0, 0);
            }
            if (input.IsKeyDown(Key.X))
            {
                escenario1.getElement("objeto2").getElement("parte1").Traslate(0, 1, 0);
            }
            if (input.IsKeyDown(Key.C))
            {
                escenario1.getElement("objeto2").getElement("parte1").Traslate(0, 0, -1);
            }
            if (input.IsKeyDown(Key.V))
            {
                escenario1.getElement("objeto2").getElement("parte1").Traslate(-1, 0, 0);
            }


            //ev.CambioDeEscala(input, ref scale);

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
            angle += 0.1;
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
            {
                GL.Begin(PrimitiveType.Lines);
                // Eje X (rojo)
                GL.Color3(1.0f, 0.0f, 0.0f);
                GL.Vertex3(10, 0, 0);
                GL.Vertex3(-10, 0, 0);
                // Eje Y (verde)
                GL.Color3(0.0f, 1.0f, 0.0f);
                GL.Vertex3(0, 10, 0);
                GL.Vertex3(0, -10, 0);

                GL.Color3(0.0f, 1.0f, 1.0f);
                GL.Vertex3(-7.5, 10, 0);
                GL.Vertex3(-7.5, -10, 0);

                // Eje Z (azul)
                GL.Color3(0.0f, 0.0f, 1.0f);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 5);
                GL.End();
            }
            //GL.Rotate(angle, 0.1, 0.0, 0.0);
            //escenario1.Rotate(0, 1, 0);
            //escenario1.getElement("letra_t").Traslate(0.1f, 0f, 0.0f);
            //escenario1.getElement("cuerpo_detallado").Traslate(0f, 0f, -0.05f);
            escenario1.getElement("cuerpo_detallado").Rotate(0.1f, 0, 0, new Point(0,0,0));

            //escenario1.getElement("letra_t").getElement("parte_inferior").Rotate(0.5f, 0.0f, 0.0f,  new Point(0,7f,0));
            escenario1.Draw();

            GL.PopMatrix();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }



        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspectiveMatrix = Matrix4. CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45.0f),
                Width / (float)Height,
                0.1f,  // Near plane
                100.0f // Far plane
            );
            GL.LoadMatrix(ref perspectiveMatrix);

            // Configurar la matriz de vista para mover la cámara hacia atrás
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Vector3 eye = new Vector3(0, 0, 95);  // Posición de la cámara
            Vector3 target = Vector3.Zero;  // Punto al que mira la cámara
            Vector3 up = Vector3.UnitY;  // Vector "arriba"
            Matrix4 viewMatrix = Matrix4.LookAt(eye, target, up);
            GL.LoadMatrix(ref viewMatrix);

            base.OnResize(e);
        }

        public Stage buildStage()
        {

            Dictionary<string, Part> cuerpoDetallado = new Dictionary<string, Part>();
            Dictionary<string, Part> letra_t = new Dictionary<string, Part>();
            Dictionary<string, Part> esfera = new Dictionary<string, Part>();
            Stage escenario1 = new Stage();

            //INICIO ARMADO DE LETRA T
            Part p1 = buildCube(new Point(0f,0,0f), Color.Blue, 5,10,5);
            Part p2 = buildCube(new Point(0,7.5f,0f), Color.Black, 15,5,5);
            letra_t.Add("parte_inferior", p1);
            letra_t.Add("parte_superior", p2);
            //FIN ARMADO LETRA T

           // escenario1.addElement("letra_t", new Object(new Point(), letra_t, Color.BlueViolet));

            //INICIO ARMADO PARA ARMAR UN CUERPO
            float posX = 20f; // Posición base en X

            // Cabeza y cuello
            Part cabeza = buildCube(new Point(posX, 3f, 0f), Color.Tan, 1.2f, 1.2f, 1.2f);
            Part cuello = buildCube(new Point(posX, 2.2f, 0f), Color.Tan, 0.6f, 0.6f, 0.6f);

            // Tronco
            Part tronco = buildCube(new Point(posX, 0.5f, 0f), Color.WhiteSmoke, 1f, 3f, 1f);

            // Brazo izquierdo
            Part hombroIzq = buildCube(new Point(posX - 0.8f, 1.5f, 0f), Color.WhiteSmoke, 0.6f, 0.6f, 0.6f);
            Part brazoSupIzq = buildCube(new Point(posX - 0.8f, 1.0f, 0f), Color.WhiteSmoke, 0.5f, 1f, 0.5f);
            Part codoIzq = buildCube(new Point(posX - 0.8f, 0.4f, 0f), Color.WhiteSmoke, 0.4f, 0.4f, 0.4f);
            Part antebrazoIzq = buildCube(new Point(posX - 0.8f, -0.1f, 0f), Color.WhiteSmoke, 0.4f, 1f, 0.4f);
            Part muñecaIzq = buildCube(new Point(posX - 0.8f, -0.7f, 0f), Color.WhiteSmoke, 0.3f, 0.3f, 0.3f);
            Part manoIzq = buildCube(new Point(posX - 0.8f, -1f, 0f), Color.Tan, 0.4f, 0.4f, 0.4f);

            // Brazo derecho
            Part hombroDer = buildCube(new Point(posX + 0.8f, 1.5f, 0f), Color.WhiteSmoke, 0.6f, 0.6f, 0.6f);
            Part brazoSupDer = buildCube(new Point(posX + 0.8f, 1.0f, 0f), Color.WhiteSmoke, 0.5f, 1f, 0.5f);
            Part codoDer = buildCube(new Point(posX + 0.8f, 0.4f, 0f), Color.WhiteSmoke, 0.4f, 0.4f, 0.4f);
            Part antebrazoDer = buildCube(new Point(posX + 0.8f, -0.1f, 0f), Color.WhiteSmoke, 0.4f, 1f, 0.4f);
            Part muñecaDer = buildCube(new Point(posX + 0.8f, -0.7f, 0f), Color.WhiteSmoke, 0.3f, 0.3f, 0.3f);
            Part manoDer = buildCube(new Point(posX + 0.8f, -1f, 0f), Color.Tan, 0.4f, 0.4f, 0.4f);

            // Pierna izquierda
            Part caderaIzq = buildCube(new Point(posX - 0.4f, -0.8f, 0f), Color.WhiteSmoke, 0.6f, 0.6f, 0.6f);
            Part musloIzq = buildCube(new Point(posX - 0.4f, -1.5f, 0f), Color.WhiteSmoke, 0.5f, 1.4f, 0.5f);
            Part rodillaIzq = buildCube(new Point(posX - 0.4f, -2.3f, 0f), Color.WhiteSmoke, 0.4f, 0.4f, 0.4f);
            Part piernaInfIzq = buildCube(new Point(posX - 0.4f, -3f, 0f), Color.WhiteSmoke, 0.4f, 1.4f, 0.4f);
            Part tobilloIzq = buildCube(new Point(posX - 0.4f, -3.8f, 0f), Color.WhiteSmoke, 0.3f, 0.3f, 0.3f);
            Part pieIzq = buildCube(new Point(posX - 0.4f, -4.1f, 0.1f), Color.WhiteSmoke, 0.5f, 0.3f, 0.7f);

            // Pierna derecha
            Part caderaDer = buildCube(new Point(posX + 0.4f, -0.8f, 0f), Color.WhiteSmoke, 0.6f, 0.6f, 0.6f);
            Part musloDer = buildCube(new Point(posX + 0.4f, -1.5f, 0f), Color.WhiteSmoke, 0.5f, 1.4f, 0.5f);
            Part rodillaDer = buildCube(new Point(posX + 0.4f, -2.3f, 0f), Color.WhiteSmoke, 0.4f, 0.4f, 0.4f);
            Part piernaInfDer = buildCube(new Point(posX + 0.4f, -3f, 0f), Color.WhiteSmoke, 0.4f, 1.4f, 0.4f);
            Part tobilloDer = buildCube(new Point(posX + 0.4f, -3.8f, 0f), Color.WhiteSmoke, 0.3f, 0.3f, 0.3f);
            Part pieDer = buildCube(new Point(posX + 0.4f, -4.1f, 0.1f), Color.WhiteSmoke, 0.5f, 0.3f, 0.7f);

            // Agregamos todas las partes al diccionario
            cuerpoDetallado.Add("cabeza", cabeza);
            cuerpoDetallado.Add("cuello", cuello);
            cuerpoDetallado.Add("tronco", tronco);

            // Brazo izquierdo
            cuerpoDetallado.Add("hombro_izquierdo", hombroIzq);
            cuerpoDetallado.Add("brazo_superior_izquierdo", brazoSupIzq);
            cuerpoDetallado.Add("codo_izquierdo", codoIzq);
            cuerpoDetallado.Add("antebrazo_izquierdo", antebrazoIzq);
            cuerpoDetallado.Add("muñeca_izquierda", muñecaIzq);
            cuerpoDetallado.Add("mano_izquierda", manoIzq);

            // Brazo derecho
            cuerpoDetallado.Add("hombro_derecho", hombroDer);
            cuerpoDetallado.Add("brazo_superior_derecho", brazoSupDer);
            cuerpoDetallado.Add("codo_derecho", codoDer);
            cuerpoDetallado.Add("antebrazo_derecho", antebrazoDer);
            cuerpoDetallado.Add("muñeca_derecha", muñecaDer);
            cuerpoDetallado.Add("mano_derecha", manoDer);

            // Pierna izquierda
            cuerpoDetallado.Add("cadera_izquierda", caderaIzq);
            cuerpoDetallado.Add("muslo_izquierdo", musloIzq);
            cuerpoDetallado.Add("rodilla_izquierda", rodillaIzq);
            cuerpoDetallado.Add("pierna_inferior_izquierda", piernaInfIzq);
            cuerpoDetallado.Add("tobillo_izquierdo", tobilloIzq);
            cuerpoDetallado.Add("pie_izquierdo", pieIzq);

            // Pierna derecha
            cuerpoDetallado.Add("cadera_derecha", caderaDer);
            cuerpoDetallado.Add("muslo_derecho", musloDer);
            cuerpoDetallado.Add("rodilla_derecha", rodillaDer);
            cuerpoDetallado.Add("pierna_inferior_derecha", piernaInfDer);
            cuerpoDetallado.Add("tobillo_derecho", tobilloDer);
            cuerpoDetallado.Add("pie_derecho", pieDer);

            escenario1.addElement("cuerpo_detallado", new Object(new Point(), cuerpoDetallado, Color.BlueViolet));

            Part esfera_part = buildSphere(new Point(-5, 10.1f, 0), Color.Red, 1.0f, 8);
            esfera.Add("esfera", esfera_part);
            escenario1.addElement("esfera", new Object(new Point(), esfera, Color.Red));


            return escenario1;
        }

        public Part buildPart()
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
            return new Part(new Point(), parte1, Color.BlueViolet);
        }


        public Part  buildCube(Point center, Color color, float x, float y, float z)
        {
            Dictionary<string, Polygon> listPolygon = new Dictionary<string, Polygon>();

            // Cara inferior
            Dictionary<string, Point> bottomFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x - x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p2", new Point(center.x + x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p3", new Point(center.x + x / 2, center.y - y / 2, center.z + z / 2) },
                    { "p4", new Point(center.x - x / 2, center.y - y / 2, center.z + z / 2) }
                };
            listPolygon.Add("bottomFace", new Polygon(new Point(), bottomFace, color));

            // Cara superior
            Dictionary<string, Point> topFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x - x / 2, center.y + y / 2, center.z - z / 2) },
                    { "p2", new Point(center.x + x / 2, center.y + y / 2, center.z - z / 2) },
                    { "p3", new Point(center.x + x / 2, center.y + y / 2, center.z + z / 2) },
                    { "p4", new Point(center.x - x / 2, center.y + y / 2, center.z + z / 2) }
                };
            listPolygon.Add("topFace", new Polygon(new Point(), topFace, color));

            // Cara frontal
            Dictionary<string, Point> frontFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x - x / 2, center.y - y / 2, center.z + z / 2) },
                    { "p2", new Point(center.x + x / 2, center.y - y / 2, center.z + z / 2) },
                    { "p3", new Point(center.x + x / 2, center.y + y / 2, center.z + z / 2) },
                    { "p4", new Point(center.x - x / 2, center.y + y / 2, center.z + z / 2) }
                };
            listPolygon.Add("frontFace", new Polygon(new Point(), frontFace, color));

            // Cara trasera
            Dictionary<string, Point> backFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x - x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p2", new Point(center.x + x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p3", new Point(center.x + x / 2, center.y + y / 2, center.z - z / 2) },
                    { "p4", new Point(center.x - x / 2, center.y + y / 2, center.z - z / 2) }
                };
            listPolygon.Add("backFace", new Polygon(new Point(), backFace, color));

            // Cara izquierda
            Dictionary<string, Point> leftFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x - x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p2", new Point(center.x - x / 2, center.y - y / 2, center.z + z / 2) },
                    { "p3", new Point(center.x - x / 2, center.y + y / 2, center.z + z / 2) },
                    { "p4", new Point(center.x - x / 2, center.y + y / 2, center.z - z / 2) }
                };
            listPolygon.Add("leftFace", new Polygon(new Point(), leftFace, color));

            // Cara derecha
            Dictionary<string, Point> rightFace = new Dictionary<string, Point>
                {
                    { "p1", new Point(center.x + x / 2, center.y - y / 2, center.z - z / 2) },
                    { "p2", new Point(center.x + x / 2, center.y - y / 2, center.z + z / 2) },
                    { "p3", new Point(center.x + x / 2, center.y + y / 2, center.z + z / 2) },
                    { "p4", new Point(center.x + x / 2, center.y + y / 2, center.z - z / 2) }
                };
            listPolygon.Add("rightFace", new Polygon(new Point(), rightFace, color));


            return new Part(center, listPolygon, color);
        }

        public Part buildSphere(Point center, Color color, float radius, int segments = 15)
        {
            Dictionary<string, Polygon> listPolygon = new Dictionary<string, Polygon>();
            float pi = (float)Math.PI;

            // Iteramos sobre los segmentos verticales (latitud)
            for (int lat = 0; lat < segments; lat++)
            {
                float phi1 = pi * ((float)lat / segments - 0.5f);
                float phi2 = pi * ((float)(lat + 1) / segments - 0.5f);

                // Iteramos sobre los segmentos horizontales (longitud)
                for (int lon = 0; lon < segments; lon++)
                {
                    float theta1 = 2f * pi * (float)lon / segments;
                    float theta2 = 2f * pi * (float)(lon + 1) / segments;

                    // Calculamos los 4 puntos de cada segmento
                    Dictionary<string, Point> points = new Dictionary<string, Point>
            {
                {
                    "p1",
                    new Point(
                        center.x + radius * (float)(Math.Cos(phi1) * Math.Cos(theta1)),
                        center.y + radius * (float)Math.Sin(phi1),
                        center.z + radius * (float)(Math.Cos(phi1) * Math.Sin(theta1))
                    )
                },
                {
                    "p2",
                    new Point(
                        center.x + radius * (float)(Math.Cos(phi1) * Math.Cos(theta2)),
                        center.y + radius * (float)Math.Sin(phi1),
                        center.z + radius * (float)(Math.Cos(phi1) * Math.Sin(theta2))
                    )
                },
                {
                    "p3",
                    new Point(
                        center.x + radius * (float)(Math.Cos(phi2) * Math.Cos(theta2)),
                        center.y + radius * (float)Math.Sin(phi2),
                        center.z + radius * (float)(Math.Cos(phi2) * Math.Sin(theta2))
                    )
                },
                {
                    "p4",
                    new Point(
                        center.x + radius * (float)(Math.Cos(phi2) * Math.Cos(theta1)),
                        center.y + radius * (float)Math.Sin(phi2),
                        center.z + radius * (float)(Math.Cos(phi2) * Math.Sin(theta1))
                    )
                }
            };

                    // Añadimos el polígono al diccionario
                    string polygonName = $"segment_{lat}_{lon}";
                    listPolygon.Add(polygonName, new Polygon(new Point(), points, color));
                }
            }

            return new Part(center, listPolygon, color);
        }
    }
}
