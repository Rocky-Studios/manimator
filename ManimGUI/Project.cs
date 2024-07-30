using System.Xml.Linq;

namespace ManimGUI
{
    public class Project
    {
        public string Name;
        public string Path;
        public string LastOpenedVersion;

        public Project(string name, string path)
        {
            Name = name;
            Path = path;
            LastOpenedVersion = ManimGUI.VERSION;
        }

        public Project(XElement xElement)
        {
            Name = xElement.Attribute("Name").Value;
            if (xElement.Attribute("Path") != null) Path = xElement.Attribute("Path").Value;
            if (xElement.Attribute("Version") != null) LastOpenedVersion = xElement.Attribute("Version").Value;
        }
    }
}