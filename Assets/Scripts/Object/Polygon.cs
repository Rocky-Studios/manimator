using System;
using Godot;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    public partial class Polygon : MObject
    {
        Point[] Points = {};
        private Camera3D _camera;

        public Polygon(string name, Camera3D camera, bool visible = true, Color? strokeColor = null, Color? fillColor = null, Point[] points = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, visible, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            Points = points ?? throw new Exception("Polygon must have points");
            if (Points.Length < 3) throw new Exception("Polygon must have at least 3 points");
            _camera = camera;
             _camera.AddChild(this);
        }
        
        public static Vector2[] PointsToVector2Array(Point[] points, Camera3D projectingCamera)
        {
            Vector2[] vector2Array = new Vector2[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                vector2Array[i] = projectingCamera.UnprojectPosition(points[i].Position.Value);
            }
            return vector2Array;
        }

        public override void _Draw()
        {
            Vector2[] points = PointsToVector2Array(Points, _camera);
            GD.Print(points.Length);
            DrawColoredPolygon(points, FillColor.Value);
            if (StrokeColor.Value.A == 0) return;
            for (int i = 0; i < Points.Length; i++) {
                Point thisPoint = Points[i];
                Point nextPoint = Points[(i + 1) % Points.Length];
                DrawCircle(_camera.UnprojectPosition(thisPoint.Position.Value), 5f, StrokeColor.Value);
                DrawLine( _camera.UnprojectPosition(thisPoint.Position.Value), _camera.UnprojectPosition(nextPoint.Position.Value), StrokeColor.Value, 10f, true);                
            }
        }

        public override void OnUpdate(Camera3D cam)
        {
            if(_camera == null) _camera = cam;
        }
    }
/*
    public partial class RegularPolygon : Polygon
    {
        public RegularPolygon(string name, Color? strokeColor = null, Color? fillColor = null, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
        }
    }*/
}
