using System.Xml.Linq;

namespace ManimGUI
{
    public static class ManimGUI
    {
        public static readonly string VERSION = "0.0.2";
        public static void New(Project project)
        {
            string path = project.Path;
            XDocument doc = Filesystem.CreateProjectFile(project);
            Directory.CreateDirectory(path);
            doc.Save(path + "\\Project.mgui");
        }
    }
}