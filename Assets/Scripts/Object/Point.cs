using Godot;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    /// <summary>
    /// An infinitely small single point in space
    /// </summary>
    public partial class Point : MObject
    {
        /// <summary>
        /// Generates an infinitely small single point in space
        /// </summary>
        /// <param name="name">The behind-the-scenes name ID of the object</param>
        /// <param name="strokeColor">The color of any lines for this object</param>
        /// <param name="zIndex">The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones</param>
        /// <param name="position">The 2D screen position of the object</param>
        /// <param name="rotation">The 2D screen rotation of the object</param>
        /// <param name="scale">The 2D screen scale of the object</param>
        public Point(string name, Color? strokeColor = null, bool visible = true, int zIndex = 0, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, visible, strokeColor, strokeColor, zIndex, 1f, position, rotation, scale)
        {
        }

        public override void OnUpdate(Camera3D cam)
        {
            if (Outline == null)
            {
                Outline = new PointOutline(this, cam);
                cam.AddChild(Outline);
            }
            base.OnUpdate(cam);
        }
    }
}
