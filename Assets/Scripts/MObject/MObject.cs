using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;
using Vector3 = Godot.Vector3;

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
        [Range(0, 1)]
        public float Opacity;
        /// <summary>
        /// The 2D screen position of the object
        /// </summary>
        public Vector3 Position = Vector3.Zero;
        /// <summary>
        /// The 2D screen rotation of the object
        /// </summary>
        public Vector3 Rotation = Vector3.Zero;
        /// <summary>
        /// The 2D screen scale of the object
        /// </summary>
        public Vector3 Scale = Vector3.One;

        public Material Material;

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
        protected MObject(string name, Color strokeColor, Color? fillColor = null, int zIndex = 0, float opacity = 1, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
        {
            Name = name;

            StrokeColor = strokeColor;

            if (fillColor != null) FillColor = (Color) fillColor;
            else FillColor = Color.Transparent;

            this.zIndex = zIndex;
            Opacity = opacity;

            if(position == null) Position = Vector3.Zero;
            else Position = (Vector3) position;

            if(rotation == null) Rotation = Vector3.Zero;
            else Rotation = (Vector3) rotation;

            if (scale == null) Scale = Vector3.One;
            else Scale = (Vector3)scale;

            Material = new StandardMaterial3D();
        }

        public virtual void OnUpdate()
        {
            
        }
    }
}
