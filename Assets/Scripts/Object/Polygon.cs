using Godot;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    public class Polygon : MObject
    {
        Point[] Points = {};
        Segment[] Lines = {};

        public Polygon(string name, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
        }
    }

    public class RegularPolygon : Polygon
    {
        public RegularPolygon(string name, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
        }
    }
}
