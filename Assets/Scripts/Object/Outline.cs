using System;
using Godot;
using ManimGUI;
using Color = Godot.Color;

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
        Vector2 pointPos = _camera.UnprojectPosition(Point.Position.Value);
        Color stroke = Point.StrokeColor.Value;
        stroke.A *= Point.Opacity.Value;
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
            if (Math.Abs(l.A.Position.Value.X - l.B.Position.Value.X) < 0.0001) // Vertical line
            {
                pointA = _camera.UnprojectPosition(new Vector3(l.A.Position.Value.X, -10000, l.A.Position.Value.Z));
                pointB = _camera.UnprojectPosition(new Vector3(l.A.Position.Value.X, 10000, l.A.Position.Value.Z));
            }
            else
            {
                float slope = (l.B.Position.Value.Y - l.A.Position.Value.Y) / (l.B.Position.Value.X - l.A.Position.Value.X);
                float intercept = l.A.Position.Value.Y - slope * l.A.Position.Value.X;
                pointA = _camera.UnprojectPosition(new Vector3(-10000, slope * -10000 + intercept, l.A.Position.Value.Z));
                pointB = _camera.UnprojectPosition(new Vector3(10000, slope * 10000 + intercept, l.A.Position.Value.Z));
            }
            Color stroke = l.StrokeColor.Value;
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is Segment s) {
            Vector2 pointA = _camera.UnprojectPosition(s.A.Position.Value);
            Vector2 pointB = _camera.UnprojectPosition(s.B.Position.Value);
            Color stroke = s.StrokeColor.Value;
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is Ray r) {
            throw new NotImplementedException();
            Vector2 pointA = _camera.UnprojectPosition(r.A.Position.Value);
            Vector2 pointB;
            if (Math.Abs(r.A.Position.Value.X - r.B.Position.Value.X) < 0.0001) // Vertical line
            {
                pointB = _camera.UnprojectPosition(new Vector3(r.B.Position.Value.X, 10000, r.B.Position.Value.Z));
            }
            else
            {
                float slope = (r.B.Position.Value.Y - r.A.Position.Value.Y) / (r.B.Position.Value.X - r.A.Position.Value.X);
                float intercept = r.A.Position.Value.Y - slope * r.A.Position.Value.X;
                pointB = _camera.UnprojectPosition(new Vector3(10000, slope * 10000 + intercept, r.B.Position.Value.Z));
            }
            Color stroke = r.StrokeColor.Value;
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
        else if (Line is RayAngle ra) {
            throw new NotImplementedException();
            Vector2 pointA = _camera.UnprojectPosition(ra.A.Position.Value);
            Vector2 pointB = _camera.UnprojectPosition(new Vector3(ra.A.Position.Value.X + 10000 * (float)Math.Cos(ra.Angle.Value.Convert("rad")), ra.A.Position.Value.Y + 10000 * (float)Math.Sin(ra.Angle.Value.Convert("rad")), ra.A.Position.Value.Z));
            Color stroke = ra.StrokeColor.Value;
            DrawLine(pointA, pointB, stroke, 10f, true);
        }
    }
}