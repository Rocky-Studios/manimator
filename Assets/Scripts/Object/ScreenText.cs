using Godot;
using Color = Godot.Color;
using Vector3 = Godot.Vector3;

namespace Manimator.MObject;

public partial class ScreenText : Outline
{
    public Color Color;
    public Label TextInfo;
    public new Vector3 Position;
    public int FontSize;
    private Camera3D _camera;

    public ScreenText(Label textInfo, Color color, int fontSize, Vector3 position, Camera3D camera)
    {
        TextInfo = textInfo;
        Color = color;
        FontSize = fontSize;
        Position = position;
        _camera = camera;
    }

    public ScreenText()
    {
    }

    public override void _Draw()
    {
        Font defaultFont = ThemeDB.FallbackFont;
        Vector2 projectedPosition = _camera.UnprojectPosition(Position);
        DrawString(defaultFont, projectedPosition, TextInfo.Text, TextInfo.HorizontalAlignment, TextInfo.Size.X, FontSize);
    }
}