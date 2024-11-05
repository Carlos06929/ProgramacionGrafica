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
    class Part 
    {
        [JsonProperty] public Point center;
        [JsonProperty] public Dictionary<string, Polygon> ListElement;
        [JsonProperty] public Color color;
        [JsonProperty] public string Transformations_json { get; set; }
        public Transformation Transformations { get; set; }

        //Constructor por defecto-----------------------------------------------------------------------------------------------------------------
        public Part()
        {
            this.ListElement = new Dictionary<string, Polygon>();
            this.center = new Point();
            this.color = Color.Pink;
            Transformations = new Transformation(center);

        }

        //Constructor con parametros-----------------------------------------------------------------------------------------------------------------
        public Part(Point origin, Dictionary<string, Polygon> poligonos, Color c)
        {
            this.ListElement = new Dictionary<string, Polygon>();
            this.center = new Point(origin);
            this.color = c;
            Transformations = new Transformation(center);

            foreach (var poligono in poligonos)
                addElement(poligono.Key, new Polygon(poligono.Value));

        }

        //Constructor copia -----------------------------------------------------------------------------------------------------------------
        public Part(Part Part)
        {
            this.center = new Point(Part.center);
            this.color = Part.color;
            this.ListElement = new Dictionary<string, Polygon>();
            Transformations = new Transformation(center);

            foreach (var poligono in Part.ListElement)
                addElement(poligono.Key, new Polygon(poligono.Value));
        }

        //Set elemento a lista--------------------------------------------------------------------------------------------------------------------
        public void addElement(string name, Polygon x)
        {
            if (ListElement.ContainsKey(name))
            {
                ListElement.Remove(name);
            }
            //x.center.adicionar(this.center);
            ListElement.Add(name, x);
        }

        public void SetCenter(Point center)
        {
            foreach (var poligono in ListElement)
            {
                Point formerCenter = Point.Vector4ToVertex(poligono.Value.GetCenter().Row3);
                poligono.Value.SetCenter(center + formerCenter);
            }
        }

        //Get elemento a lista--------------------------------------------------------------------------------------------------------------------
        public Polygon getElement(string name)
        {
            return (ListElement.ContainsKey(name)) ? ListElement[name] : null;
        }


        public void Draw()
        {
            foreach (var poligono in this.ListElement)
            {
                poligono.Value.Draw();

            }

        }

        public void setElement()
        {
            throw new NotImplementedException();
        }

        public static void SerializeJsonFile(string path, Part obj)
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

        public static Part DeserializeJsonFile(string json)
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
            return JsonConvert.DeserializeObject<Part>(textJson, settings);
        }

        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var poligono in ListElement)
            {
                poligono.Value.Rotate(angleX, angleY, angleZ);
            }
        }

        public void Traslate(float x, float y, float z)
        {
            foreach (var poligono in ListElement)
                poligono.Value.Traslate(x, y, z);
        }

        public void Traslate(Point position)
        {
            foreach (var poligono in ListElement)
                poligono.Value.Traslate(position);
        }





        public void Scale(float x, float y, float z)
        {
            foreach (var poligono in ListElement)
                poligono.Value.Scale(x, y, z);
        }

        public void Scale(Point position)
        {
            bool isLoaded = false;
            foreach (var poligono in ListElement)
            {
                poligono.Value.Scale(position);
                Transformations.SetScaleTransformation();
                if (!isLoaded)
                {
                    Transformations.Scaling = poligono.Value.Transformations.Scaling;
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
