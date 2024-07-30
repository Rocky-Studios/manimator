using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace ManimGUI.Manim.MObject
{
    /// <summary>
    /// Basically anything shown on screen
    /// </summary>
    public abstract class MObject
    {
        public string Name = "";
        public Color StrokeColor = Color.White;
        public Color FillColor = Color.Transparent;
        public int zIndex = 0;
        public Vector2 Position = Vector2.Zero;
        public Vector2 Rotation = Vector2.Zero;
        public Vector2 Scale = Vector2.One;

        protected MObject(string name, Color strokeColor, Color? fillColor = Color.Transparent, int zIndex = 0, Vector2 position = Vector2.Zero, Vector2 rotation = Vector2.Zero, Vector2 scale = Vector2.One)
        {
            Name = name;
            StrokeColor = strokeColor;
            FillColor = fillColor ?? throw new ArgumentNullException(nameof(fillColor));
            this.zIndex = zIndex;
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}
