using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace BTracking.Infrastructure.Converter.Json
{
    public class GeometryConverter : JsonConverter<Geometry>
    {

        public override Geometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString())) return null;
            var wktReader = new WKTReader();
            var result = wktReader.Read(reader.GetString());
            return result;
        }

        public override void Write(Utf8JsonWriter writer, Geometry value, JsonSerializerOptions options)
        {
            if (value != null)
                writer.WriteStringValue((value).AsText());
            else writer.WriteStringValue("");
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Geometry).IsAssignableFrom(typeToConvert);
        }
    }

    public class PointConverter : JsonConverter<Point>
    {

        public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString())) return null;
            var wktReader = new WKTReader();
            var result = wktReader.Read(reader.GetString());
            return (Point)result;
        }

        public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
        {
            if (value != null)
                writer.WriteStringValue((value).AsText());
            else writer.WriteStringValue("");
        }

        public override bool CanConvert(Type typeToConvert)
        {

            return typeof(Point).IsAssignableFrom(typeToConvert);

        }
    }

    public class PolygonConverter : JsonConverter<Polygon>
    {

        public override Polygon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString())) return null;
            var wktReader = new WKTReader();
            var result = wktReader.Read(reader.GetString());
            return (Polygon)result;
        }

        public override void Write(Utf8JsonWriter writer, Polygon value, JsonSerializerOptions options)
        {
            if (value != null)
                writer.WriteStringValue((value).AsText());
            else writer.WriteStringValue("");
        }

        public override bool CanConvert(Type typeToConvert)
        {

            return typeof(Polygon).IsAssignableFrom(typeToConvert);

        }
    }

    public class LineStringConverter : JsonConverter<LineString>
    {

        public override LineString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrEmpty(reader.GetString())) return null;
            var wktReader = new WKTReader();
            var result = wktReader.Read(reader.GetString());
            return (LineString)result;
        }

        public override void Write(Utf8JsonWriter writer, LineString value, JsonSerializerOptions options)
        {
            if (value != null)
                writer.WriteStringValue((value).AsText());
            else writer.WriteStringValue("");
        }

        public override bool CanConvert(Type typeToConvert)
        {

            return typeof(Polygon).IsAssignableFrom(typeToConvert);

        }
    }

}
