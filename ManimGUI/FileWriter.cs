using System.Xml.Linq;

namespace ManimGUI
{
    public static class FileWriter
    {
        public static XDocument CreateProjectFile(Project project)
        {
            XDocument doc = new XDocument(
                new XElement("Project")
            );

            doc.Root.SetAttributeValue("Name", project.Name);
            doc.Root.SetAttributeValue("Version", project.LastOpenedVersion);
            return doc;
        }
    }
}