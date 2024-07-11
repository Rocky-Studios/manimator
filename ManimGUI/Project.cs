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
    }
}