﻿using System.Xml.Linq;
using System.Diagnostics;
using ManimGUI.Windows.EditorWindow;

namespace ManimGUI
{
    public static class ManimGUI
    {
        public static readonly string VERSION = "0.0.2";
        public static string GetApplicationDataPath()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appDir = Path.Combine(appDataDir, "ManimGUI");
            // On Windows, appDir might be something like `C:\Users\John\AppData\Roaming\ManimGUI`
            // On macOS, appDir might be something like `/Users/John/Library/Application Support/ManimGUI`
            
            try {
                Directory.CreateDirectory(appDir);
            } catch { }
            
            return appDir;
            
        }
        public static void AddProjectToRecents(Project newProject)
        {
            List<Project> projects = new List<Project>();

            string recentProjectsPath = Path.Combine(GetApplicationDataPath(), "RecentProjects.xml");
            if(!File.Exists(recentProjectsPath))
            {
                // Create the file
                XDocument recentsFile = Filesystem.CreateRecentsFile();
                recentsFile.Save(recentProjectsPath);
            }
            XDocument document = XDocument.Load(recentProjectsPath);

            XElement Xprojects = document.Element("Projects");
            foreach (XElement p in Xprojects.Elements())
            {
                if (p.Attribute("Name").Value == newProject.Name)
                    return;
            }

            XElement newProjectElement = new XElement("Project");
            newProjectElement.SetAttributeValue("Name", newProject.Name);
            newProjectElement.SetAttributeValue("Path", newProject.Path);

            Xprojects.Add(newProjectElement);
            document.Save(recentProjectsPath);
        }
        public static async Task Init(Project project)
        {
            string projectPath = project.Path;

            XDocument doc = Filesystem.CreateProjectFile(project);
            Directory.CreateDirectory(projectPath);
            doc.Save(projectPath + "\\Project.mgui");

            AddProjectToRecents(project);      
        }
        public static void OpenProject(Project project)
        {
            NavigationPage editorNav = new NavigationPage(new EditorPage());
            Application.Current.MainPage = editorNav;
        }
    }
}