using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ManimGUI.MObject
{
    public class Polygon : MObject
    {
        Point[] Points = {};
        Segment[] Lines = {};

        public Polygon(string name, System.Drawing.Color strokeColor, System.Drawing.Color? fillColor = null, int zIndex = 0, Vector2? position = null, Vector2? rotation = null, Vector2? scale = null) : base(name, strokeColor, fillColor, zIndex, position, rotation, scale)
        {
        }
    }

    public class RegularPolygon : Polygon
    {
        public RegularPolygon(string name, System.Drawing.Color strokeColor, System.Drawing.Color? fillColor = null, int zIndex = 0, Vector2? position = null, Vector2? rotation = null, Vector2? scale = null) : base(name, strokeColor, fillColor, zIndex, position, rotation, scale)
        {
        }
    }
}
