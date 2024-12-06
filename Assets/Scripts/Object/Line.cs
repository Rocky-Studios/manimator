using BetterNumberSystem;
using System;
using Godot;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    public interface ILineBase
    {
        /// <summary>
        /// Get the length of the line
        /// </summary>
        /// <returns>The length in metres</returns>
        public Term GetLength();
    }

    /// <summary>
    /// A line between PointA and PointB that extends infinitely in both directions
    /// </summary>
    public partial class Line: MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Line(string name, Point a, Point b, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        public Term GetLength()
        {
            return new Term(new Number(double.PositiveInfinity), "Metre");
        }

        public override void OnUpdate(Camera3D cam)
        {
            if (Outline == null)
            {
                Outline = new LineOutline(this, cam);
                cam.AddChild(Outline);
            }
            base.OnUpdate(cam);
        }
    }

    /// <summary>
    /// A line segment between PointA and PointB
    /// </summary>
    public partial class Segment : MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Segment(string name, Point a, Point b, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        public Term GetLength()
        {
            return new Term(new Number(A.Position.Value.DistanceTo(B.Position.Value)), "Metre");
        }
        
        public override void OnUpdate(Camera3D cam)
        {
            if (Outline == null)
            {
                Outline = new LineOutline(this, cam);
                cam.AddChild(Outline);
            }
            base.OnUpdate(cam);
        }
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely beyond PointB
    /// </summary>
    public partial  class Ray : MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Ray(string name, Point a, Point b, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        
        public Term GetLength()
        {
            return new Term(new Number(double.PositiveInfinity), "Metre");
        }
        
        public override void OnUpdate(Camera3D cam)
        {
            if (Outline == null)
            {
                Outline = new LineOutline(this, cam);
                cam.AddChild(Outline);
            }
            base.OnUpdate(cam);
        }
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely in the direction of an Angle
    /// </summary>
    public partial class RayAngle : MObject, ILineBase
    {
        public Point A;
        public ObjectProperty<Term> Angle = new("Angle", new(new Number(0), "rad"));

        public RayAngle(string name, Point a, Color? strokeColor = null, Term? angle = null, Color? fillColor = null, int zIndex = 1, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;

            if (angle != null) Angle.Value = angle;
            if (Angle.Value.Quantity != Quantity.Angle) throw new ArgumentException("The angle number must be an angle duh");
            Angle.Value = angle;
        }

        
        public Term GetLength()
        {
            return new Term(new Number(double.PositiveInfinity), "Metre");
        }
        
        public override void OnUpdate(Camera3D cam)
        {
            if (Outline == null)
            {
                Outline = new LineOutline(this, cam);
                cam.AddChild(Outline);
            }
            base.OnUpdate(cam);
        }
    }
}
