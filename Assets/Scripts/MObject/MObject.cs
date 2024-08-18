using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace ManimGUI.MObject
{
    /// <summary>
    /// Basically anything shown on screen
    /// </summary>
    public abstract class MObject
    {
        /// <summary>
        /// The behind-the-scenes name ID of the object
        /// </summary>
        public string Name = "";
        /// <summary>
        /// The color of any lines for this object
        /// </summary>
        public Color StrokeColor = Color.White;
        /// <summary>
        /// The color of any filled region for this object
        /// </summary>
        public Color FillColor = Color.Transparent;
        /// <summary>
        /// The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones
        /// </summary>
        public int zIndex = 0;
        /// <summary>
        /// The 2D screen position of the object
        /// </summary>
        public Vector2 Position = Vector2.Zero;
        /// <summary>
        /// The 2D screen rotation of the object
        /// </summary>
        public Vector2 Rotation = Vector2.Zero;
        /// <summary>
        /// The 2D screen scale of the object
        /// </summary>
        public Vector2 Scale = Vector2.One;

        /// <summary>
        /// Generates a MObject
        /// </summary>
        /// <param name="name">The behind-the-scenes name ID of the object</param>
        /// <param name="strokeColor">The color of any lines for this object</param>
        /// <param name="fillColor">The color of any filled region for this object</param>
        /// <param name="zIndex">The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones</param>
        /// <param name="position">The 2D screen position of the object</param>
        /// <param name="rotation">The 2D screen rotation of the object</param>
        /// <param name="scale">The 2D screen scale of the object</param>
        protected MObject(string name, Color strokeColor, Color? fillColor = null, int zIndex = 0, Vector2? position = null, Vector2? rotation = null, Vector2? scale = null)
        {
            Name = name;

            StrokeColor = strokeColor;

            if (fillColor != null) FillColor = (Color) fillColor;
            else FillColor = Color.Transparent;

            this.zIndex = zIndex;

            if(position == null) Position = Vector2.Zero;
            else Position = (Vector2) position;

            if(rotation == null) Rotation = Vector2.Zero;
            else Rotation = (Vector2) rotation;

            if (scale == null) Scale = Vector2.Zero;
            else Scale = (Vector2)scale;
        }
    }
}
