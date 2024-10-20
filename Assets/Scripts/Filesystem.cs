using Manim;
using System.Xml.Linq;

namespace Manimator;

public static class Filesystem
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

    public static XDocument CreateRecentsFile()
    {
        XDocument doc = new XDocument(
            new XElement("Projects")
        );
        return doc;
    }
}
