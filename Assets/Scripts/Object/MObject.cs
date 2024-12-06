using System.Linq;
using Godot;
using Color = Godot.Color;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    /// <summary>
    /// Basically anything shown on screen
    /// </summary>
    public abstract partial class MObject : Node2D, IScreenObject
    {
        /// <summary>
        /// The behind-the-scenes name ID of the object
        /// </summary>
        public string Name;
        /// <summary>
        /// The color of any lines for this object
        /// </summary>
        public ObjectProperty<Color> StrokeColor = new("Stroke Color", Color.Color8(0,255,255));
        /// <summary>
        /// The color of any filled region for this object
        /// </summary>
        public ObjectProperty<Color> FillColor = new("Fill Color", Color.Color8(255,255,255));
        /// <summary>
        /// The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones
        /// </summary>
        public ObjectProperty<int> ZIndex = new ("Z Index", 0);
        
        public ObjectProperty<float> Opacity = new("Opacity", 1f);
        
        public ObjectProperty<bool> Visible = new("Visible", true);
        /// <summary>
        /// The position of the object
        /// </summary>
        public ObjectProperty<Vector3> Position = new ("Position", Vector3.Zero);
        /// <summary>
        /// The rotation of the object
        /// </summary>
        public ObjectProperty<Vector3> Rotation = new ("Rotation", Vector3.Zero);
        /// <summary>
        /// The scale of the object
        /// </summary>
        public ObjectProperty<Vector3> Scale = new("Scale", Vector3.One);

        public ObjectProperty<Material> Material = new ("Material", new StandardMaterial3D());
        
        public Outline Outline;

        /// <summary>
        /// Generates a MObject
        /// </summary>
        /// <param name="name">The behind-the-scenes name ID of the object</param>
        /// <param name="strokeColor">The color of any lines for this object</param>
        /// <param name="fillColor">The color of any filled region for this object</param>
        /// <param name="opacity">How transparent the object is</param>
        /// <param name="zIndex">The order of the object on the screen. Objects with higher zIndeces will appear on top of others with lower ones</param>
        /// <param name="position">The 2D screen position of the object</param>
        /// <param name="rotation">The 2D screen rotation of the object</param>
        /// <param name="scale">The 2D screen scale of the object</param>
        protected MObject(string name, bool visible, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
        {
            Name = name;
            
            Visible.Value = visible;
            
            if (strokeColor != null) StrokeColor.Value = strokeColor.Value;

            if (fillColor != null) FillColor.Value = fillColor.Value;

            ZIndex.Value = zIndex;
            
            Opacity.Value = opacity;
            
            if (position != null) Position.Value = position.Value;

            if (rotation != null) Rotation.Value = rotation.Value;

            if (scale != null) Scale.Value = scale.Value;
        }

        public virtual void OnUpdate(Camera3D cam)
        {
            if(Outline is not null)
            {
                Outline.QueueRedraw();
            }
        }
    }
}
