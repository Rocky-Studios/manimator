using BetterNumberSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector3 = Godot.Vector3;

namespace ManimGUI.MObject
{
    public interface ILineBase
    {
        /// <summary>
        /// Get the length of the line
        /// </summary>
        /// <returns>The length in metres</returns>
        public Number GetLength();
    }

    /// <summary>
    /// A line between PointA and PointB that extends infinitely in both directions
    /// </summary>
    public class Line: MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Line(string name, System.Drawing.Color strokeColor, Point a, Point b, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        public Number GetLength()
        {
            return new Number(double.PositiveInfinity, unit: UnitManager.Unit["Metre"]);
        }
    }

    /// <summary>
    /// A line segment between PointA and PointB
    /// </summary>
    public class Segment : MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Segment(string name, System.Drawing.Color strokeColor, Point a, Point b, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        public Number GetLength()
        {
            return new Number(A.Position.DistanceTo(B.Position), unit: UnitManager.Unit["Metre"]);
        }
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely beyond PointB
    /// </summary>
    public class Ray : MObject, ILineBase
    {
        public Point A;
        public Point B;

        public Ray(string name, System.Drawing.Color strokeColor, Point a, Point b, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;
            B = b;
        }

        public Number GetLength()
        {
            return new Number(double.PositiveInfinity, unit: UnitManager.Unit["Metre"]);
        }
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely in the direction of an Angle
    /// </summary>
    public class RayAngle : MObject, ILineBase
    {
        public Point A;
        public Number Angle = new Number(0, UnitManager.Unit["Radian"]);

        public RayAngle(string name, System.Drawing.Color strokeColor, Point a, Number angle, System.Drawing.Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null) : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            A = a;

            if (angle.MeasurementType != MeasurementType.Angle) throw new ArgumentException("The angle number must be an angle duh");
            else Angle = angle;
        }

        public Number GetLength()
        {
            return new Number(double.PositiveInfinity, unit: UnitManager.Unit["Metre"]);
        }
    }
}
