namespace Manimator.MObject;

public class ObjectProperty<T>
{
    public string Name;
    public T Value;
    public readonly bool Animateable;
    
    public ObjectProperty(string name, T defaultValue, bool animateable = true)
    {
        Name = name;
        Value = defaultValue;
        Animateable = animateable;
    }
    
}