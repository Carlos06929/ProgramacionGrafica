using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Grafica
{

    public class Matrix4Converter : JsonConverter<Matrix4>
    {
        public override Matrix4 ReadJson(JsonReader reader, Type objectType, Matrix4 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                float[] values = new float[16];
                int index = 0;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        reader.Read();
                        if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
                        {
                            values[index++] = Convert.ToSingle(reader.Value);
                        }
                    }
                    else if (reader.TokenType == JsonToken.EndObject)
                    {
                        break;
                    }
                }

                return new Matrix4(
                    values[0], values[1], values[2], values[3],
                    values[4], values[5], values[6], values[7],
                    values[8], values[9], values[10], values[11],
                    values[12], values[13], values[14], values[15]
                );
            }
            return Matrix4.Identity;
        }

        public override void WriteJson(JsonWriter writer, Matrix4 value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            // Row 0
            writer.WritePropertyName("M11"); writer.WriteValue(value.M11);
            writer.WritePropertyName("M12"); writer.WriteValue(value.M12);
            writer.WritePropertyName("M13"); writer.WriteValue(value.M13);
            writer.WritePropertyName("M14"); writer.WriteValue(value.M14);

            // Row 1
            writer.WritePropertyName("M21"); writer.WriteValue(value.M21);
            writer.WritePropertyName("M22"); writer.WriteValue(value.M22);
            writer.WritePropertyName("M23"); writer.WriteValue(value.M23);
            writer.WritePropertyName("M24"); writer.WriteValue(value.M24);

            // Row 2
            writer.WritePropertyName("M31"); writer.WriteValue(value.M31);
            writer.WritePropertyName("M32"); writer.WriteValue(value.M32);
            writer.WritePropertyName("M33"); writer.WriteValue(value.M33);
            writer.WritePropertyName("M34"); writer.WriteValue(value.M34);

            // Row 3
            writer.WritePropertyName("M41"); writer.WriteValue(value.M41);
            writer.WritePropertyName("M42"); writer.WriteValue(value.M42);
            writer.WritePropertyName("M43"); writer.WriteValue(value.M43);
            writer.WritePropertyName("M44"); writer.WriteValue(value.M44);

            writer.WriteEndObject();
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Transformation
    {
        [JsonProperty]
        public Matrix4 Rotation { get; set; }

        [JsonProperty]
        public Matrix4 Scaling { get; set; }

        [JsonProperty]
        public Matrix4 Traslation { get; set; }

        [JsonProperty]
        public Matrix4 Center { get; set; }

        [JsonProperty]
        public Matrix4 TransformationMatrix { get; set; }

        public Transformation()
        {
            Rotation = Matrix4.Identity;
            Scaling = Matrix4.Identity;
            Traslation = Matrix4.Identity;
            Center = Matrix4.CreateTranslation(Point.Origin);
            TransformationMatrix = Matrix4.Identity;
        }

        public Transformation(Point center)
        {
            Rotation = Matrix4.Identity;
            Scaling = Matrix4.Identity;
            Traslation = Matrix4.Identity;
            Center = Matrix4.CreateTranslation(center);
            TransformationMatrix = Matrix4.Identity;
        }

        public void SetTransformation(bool self)
        {
            TransformationMatrix = !self ? Center * Traslation * Rotation * Scaling
                        : Rotation * Scaling * Center * Traslation;
        }

        public void SetTransformation()
        {
            this.SetTransformation(true);
        }

        public void SetScaleTransformation()
        {
            TransformationMatrix = Traslation * Rotation * Scaling;
        }
    }

    public class SerializationConfig
    {
        public static JsonSerializerSettings GetSettings()
        {
            return new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
            {
                new Matrix4Converter()
            },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                Formatting = Formatting.Indented
            };
        }
    }
}
