using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector3 = Godot.Vector3;

namespace ManimGUI.MObject
{
    public class Polygon : MObject
    {
        Point[] Points = {};
        Segment[] Lines = {};

        public Polygon(string name, System.Drawing.Color strokeColor, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
        }
    }

    public class RegularPolygon : Polygon
    {
        public RegularPolygon(string name, System.Drawing.Color strokeColor, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
        }
    }
}
