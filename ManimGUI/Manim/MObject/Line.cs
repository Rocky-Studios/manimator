using BetterNumberSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManimGUI.Manim.MObject
{
    public abstract class LineBase : MObject
    {

    }

    /// <summary>
    /// A line between PointA and PointB that extends infinitely in both directions
    /// </summary>
    public class Line: LineBase
    {
        public Point A;
        public Point B; 
    }

    /// <summary>
    /// A line segment between PointA and PointB
    /// </summary>
    public class Segment : LineBase
    {
        public Point A;
        public Point B;
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely beyond PointB
    /// </summary>
    public class Ray : LineBase
    {
        public Point A;
        public Point B;
    }

    /// <summary>
    /// A line that starts at PointA and goes to and infintely beyond PointB
    /// </summary>
    public class RayAngle : LineBase
    {
        public Point A;
        public Number Angle = new Number(0, MeasurementType.Angle, NumberUnit.GetNumberUnitBySuffix("rad"));
    }
}
