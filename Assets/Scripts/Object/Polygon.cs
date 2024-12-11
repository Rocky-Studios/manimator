using System;
using Godot;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject
{
    public partial class Polygon : MObject
    {
        public Point[] Points;
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
            if(!Visible.Value) return;
            Vector2[] points = PointsToVector2Array(Points, _camera);
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
    public partial class RegularPolygon : MObject
    {
        public Point[] Points;
        private Camera3D _camera;

        public RegularPolygon(string name, Camera3D camera, bool visible = true, Color? strokeColor = null, Color? fillColor = null, int points = 3, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
            : base(name, visible, strokeColor, fillColor, zIndex, opacity, position, rotation, scale)
        {
            if (points < 3) throw new Exception("Polygon must have at least 3 points");
            Points = new Point[points];
            for (int i = 0; i < points; i++)
            {
                float angle = (i * Mathf.Tau / points) + Mathf.DegToRad(180f/points);
                float x = Mathf.Cos(angle);
                float y = Mathf.Sin(angle);
                Points[i] = new Point(name + "_point_" + i, strokeColor, false, zIndex, position:  new Vector3(x, y, 0));
            }
            _camera = camera;
            _camera.AddChild(this);
        }

        public override void _Draw()
        {
            if(!Visible.Value) return;
            Vector2[] points = Polygon.PointsToVector2Array(Points, _camera);
            DrawColoredPolygon(points, FillColor.Value);
            if (StrokeColor.Value.A == 0) return;
            for (int i = 0; i < Points.Length; i++) {
                Point thisPoint = Points[i];
                Point nextPoint = Points[(i + 1) % Points.Length];
                DrawCircle(_camera.UnprojectPosition(thisPoint.Position.Value), 5f, StrokeColor.Value);
                DrawLine( _camera.UnprojectPosition(thisPoint.Position.Value), _camera.UnprojectPosition(nextPoint.Position.Value), StrokeColor.Value, 10f, true);                
            }
        }

        private Vector3 previousPosition = new(0,0,0);
        public override void OnUpdate(Camera3D cam)
        {
            if(Position.Value != previousPosition)
            {
                for (int i = 0; i < Points.Length; i++)
                {
                    float angle = (i * Mathf.Tau / Points.Length) + Mathf.DegToRad(180f/Points.Length);
                    float x = Mathf.Cos(angle);
                    float y = Mathf.Sin(angle);
                    Points[i].Position.Value = new Vector3(x, y , 0) + Position.Value;
                }
            }
            
            
            if(_camera == null) _camera = cam;            
            
            previousPosition = Position.Value;
        }
    }
}
