using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ManimGUI.MObject
{
    /// <summary>
    /// An infinitely small single point in space
    /// </summary>
    public class Point : MObject
    {
        /// <summary>
        /// Generates an infinitely small single point in space
        /// </summary>
        /// <param name="name">The behind-the-scenes name ID of the object</param>
        /// <param name="strokeColor">The color of any lines for this object</param>
        /// <param name="fillColor">The color of any filled region for this object</param>
        /// <param name="zIndex">The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones</param>
        /// <param name="position">The 2D screen position of the object</param>
        /// <param name="rotation">The 2D screen rotation of the object</param>
        /// <param name="scale">The 2D screen scale of the object</param>
        public Point(string name, Color strokeColor, Color? fillColor = null, int zIndex = 0, Vector2? position = null, Vector2? rotation = null, Vector2? scale = null) : base(name, strokeColor, fillColor, zIndex, position, rotation, scale)
        {

        }
    }
}
