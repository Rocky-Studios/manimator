﻿using Manimator.MObject;
using System.Collections.Generic;

namespace Manimator;

public class Scene
{
    public string Name = "Scene";
    public int Index;
    /// <summary>
    /// All of the objects in the scene. Note: adding objects here will not do anything visually, you need to create animations for that.
    /// </summary>
    public List<MObject.MObject> MObjects = new();
    /// <summary>
    /// A list of all the animations in the scene
    /// </summary>
    public List<IAnimation> Animations = new();

    public Scene(string name, int index)
    {
        Name = name;
        Index = index;
        MObjects = new();
        Animations = new();
    }
}