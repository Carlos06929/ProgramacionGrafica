using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafica
{
    [JsonObject(MemberSerialization.OptIn)]
    class Object 
    {
        [JsonProperty] public Point center;
        [JsonProperty] public Dictionary<string, Part> ListElement;
        [JsonProperty] public Color color;

        [JsonProperty] public Transformation Transformations { get; set; }



        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Object()
        {
            this.ListElement = new Dictionary<string, Part>();
            this.center = new Point();
            this.color = Color.Pink;
            this.Transformations = new Transformation(center);

        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Object(Point center, Dictionary<string, Part> parts, Color c)
        {
            this.ListElement = new Dictionary<string, Part>();
            this.center = new Point(center);
            this.color = c;
            Transformations = new Transformation(center);

            foreach (var part in parts)
                addElement(part.Key, new Part(part.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Object(Object objeto)
        {
            this.center = new Point(objeto.center);
            this.color = objeto.color;
            this.ListElement = new Dictionary<string, Part>();
            Transformations = new Transformation(center);

            foreach (var part in objeto.ListElement)
                addElement(part.Key, new Part(part.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Part x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            //x.center.adicionar(this.center);
            ListElement.Add(name, x);
        }

        public void deleteElement()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            foreach (var part in this.ListElement)
            {
                part.Value.Draw();

            }
        }

        public Part getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }

        public void SetCenter(Point center)
        {
            foreach (var parte in ListElement)
            {
                Point formerCenter = Point.Vector4ToVertex(parte.Value.GetCenter().Row3);
                parte.Value.SetCenter(center + formerCenter);
            }
        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

        public static void SerializeJsonFile(string path, Object obj)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
            {
                new Matrix4Converter(),
            },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                Formatting = Formatting.Indented
            };

            string textJson = JsonConvert.SerializeObject(obj, settings);
            File.WriteAllText(path, textJson);
        }

        public static Object DeserializeJsonFile(string json)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
            {
                new Matrix4Converter(),
            },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            };

            string textJson = File.ReadAllText(json);
            return JsonConvert.DeserializeObject<Object>(textJson, settings);
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var parte in ListElement)
            {
                parte.Value.Rotate(angleX, angleY, angleZ);
            }
        }

        public void Rotate(float angleX, float angleY, float angleZ, Point pivot)
        {
            foreach (var parte in ListElement)
            {
                parte.Value.Rotate(angleX, angleY, angleZ, pivot);
            }
        }


        public void Traslate(float x, float y, float z)
        {
            foreach (var parte in ListElement)
                parte.Value.Traslate(x, y, z);
        }

        public void Traslate(Point position)
        {
            foreach (var parte in ListElement)
                parte.Value.Traslate(position);
        }





        public void SetTransformations()
        {
            foreach (var parte in ListElement)
            {
                parte.Value.Transformations.TransformationMatrix = Transformations.TransformationMatrix;
            }
        }
        public void Scale(float x, float y, float z)
        {
            foreach (var parte in ListElement)
                parte.Value.Scale(x, y, z);
        }

        public void Scale(Point position)
        {
            bool isLoaded = false;
            foreach (var parte in ListElement)
            {
                parte.Value.Scale(position);
                Transformations.SetScaleTransformation();
                if (!isLoaded)
                {
                    Transformations.Scaling = parte.Value.Transformations.Scaling;
                    isLoaded = true;
                }
            }
        }




        public Matrix4 GetCenter()
        {
            return Transformations.Center;
        }


    }
}
