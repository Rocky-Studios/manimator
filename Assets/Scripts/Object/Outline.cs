using System;
using Godot;
using ManimGUI;

namespace Manimator.MObject;

public abstract partial class Outline : Node2D, IScreenObject
{
    
}

public partial class PointOutline : Outline
{
    public Point Point;
    private Camera3D _camera;

    public PointOutline(Point point, Camera3D camera)
    {
        Point = point;
        _camera = camera;
    }

    public void _draw()
    {
        Vector2 pointPos = _camera.UnprojectPosition(Point.Position);
        Color stroke = Converter.ColorToGodot(Point.StrokeColor);
        DrawCircle(pointPos, 10f, stroke);
    }
}

public partial class LineOutline : Outline
{
    public ILineBase Line;
    private Camera3D _camera;
    public LineOutline(ILineBase line, Camera3D camera)
    {
        Line = line;
        _camera = camera;
    }

    public void _draw()
    {
        if (Line is Line l) {
            throw new NotImplementedException();
            Vector2 pointA, pointB;
            if (Math.Abs(l.A.Position.X - l.B.Position.X) < 0.0001) // Vertical line
            {
                pointA = _camera.UnprojectPosition(new Vector3(l.A.Position.X, -10000, l.A.Position.Z));
                pointB = _camera.UnprojectPosition(new Vector3(l.A.Position.X, 10000, l.A.Position.Z));
            }
            else
            {
                float slope = (l.B.Position.Y - l.A.Position.Y) / (l.B.Position.X - l.A.Position.X);
                float intercept = l.A.Position.Y - slope * l.A.Position.X;
                pointA = _camera.UnprojectPosition(new Vector3(-10000, slope * -10000 + intercept, l.A.Position.Z));
                pointB = _camera.UnprojectPosition(new Vector3(10000, slope * 10000 + intercept, l.A.Position.Z));
            }
            Color stroke = Converter.ColorToGodot(l.StrokeColor);
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is Segment s) {
            Vector2 pointA = _camera.UnprojectPosition(s.A.Position);
            Vector2 pointB = _camera.UnprojectPosition(s.B.Position);
            Color stroke = Converter.ColorToGodot(s.StrokeColor);
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is Ray r) {
            throw new NotImplementedException();
            Vector2 pointA = _camera.UnprojectPosition(r.A.Position);
            Vector2 pointB;
            if (Math.Abs(r.A.Position.X - r.B.Position.X) < 0.0001) // Vertical line
            {
                pointB = _camera.UnprojectPosition(new Vector3(r.B.Position.X, 10000, r.B.Position.Z));
            }
            else
            {
                float slope = (r.B.Position.Y - r.A.Position.Y) / (r.B.Position.X - r.A.Position.X);
                float intercept = r.A.Position.Y - slope * r.A.Position.X;
                pointB = _camera.UnprojectPosition(new Vector3(10000, slope * 10000 + intercept, r.B.Position.Z));
            }
            Color stroke = Converter.ColorToGodot(r.StrokeColor);
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is RayAngle ra) {
            throw new NotImplementedException();
            Vector2 pointA = _camera.UnprojectPosition(ra.A.Position);
            Vector2 pointB = _camera.UnprojectPosition(new Vector3(ra.A.Position.X + 10000 * (float)Math.Cos(ra.Angle.Convert("rad")), ra.A.Position.Y + 10000 * (float)Math.Sin(ra.Angle.Convert("rad")), ra.A.Position.Z));
            Color stroke = Converter.ColorToGodot(ra.StrokeColor);
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
    }
}