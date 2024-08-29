using ManimGUI;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Manim
{
    public class Project
    {
        public string Name;
        public string Path;
        public string LastOpenedVersion;
        public ProjectSettings Settings;
        public List<Scene> Scenes;
        public Project(string name, string path, ProjectSettings settings)
        {
            Name = name;
            Path = path;
            LastOpenedVersion = ManimGUI.ManimGUI.VERSION;
            Scenes = new();
            Settings = settings;
        }
    }

    public struct ProjectSettings
    {
        public int Width;
        public int Height;
        public int Framerate;
    }
}