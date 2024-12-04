using Godot;

namespace Manimator.MObject;

public abstract partial class Outline : Node2D, IScreenObject
{
    public float Width = 10.0f;
    public Color Color = Color.FromHsv(0, 0, 1);
}

public partial class PointOutline : Outline
{
    public Vector2 PointPos;
    public void _draw()
    {
        DrawCircle(PointPos, Width, Color);
    }
}

public partial class LineOutline : Outline
{
    public Vector2 PointA;
    public Vector2 PointB;
    public void _draw()
    {
        DrawCircle(PointA, Width, Color);
        DrawCircle(PointB, Width, Color);
        DrawLine(PointA, PointB, Color, Width, true);
    }
}