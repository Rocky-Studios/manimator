using Godot;
using Color = Godot.Color;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject;

public partial class TextObject : MObject
{
    public string Text;
    public int FontSize;
    private Camera3D _camera;

    public TextObject(string name, string text, Color color, int fontSize, Camera3D camera, bool visible = true, int zIndex = 0, float opacity = 1f, Vector3? position = null, Vector3? rotation = null, Vector3? scale = null)
        : base(name, visible, color, null, zIndex, opacity, position, rotation, scale)
    {
        Text = text;
        FontSize = fontSize;
        Position.Value = position ?? new Vector3(0,0,0);
        _camera = camera;
        
        _camera.AddChild(this);
    }

    public override void _Draw()
    {
        Font defaultFont = ThemeDB.FallbackFont;
        Vector2 projectedPosition = _camera.UnprojectPosition(Position.Value);
        DrawString(defaultFont, projectedPosition, Text, fontSize: FontSize, modulate: StrokeColor.Value);
    }
}