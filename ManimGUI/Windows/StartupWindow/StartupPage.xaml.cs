using System.Xml.Linq;

namespace ManimGUI.Windows.StartupWindow
{
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            InitializeComponent();


            List<Project> projects = new List<Project>();

            string recentProjectsPath = Path.Combine(ManimGUI.GetApplicationDataPath(), "RecentProjects.xml");
            if (File.Exists(recentProjectsPath))
            {
                XDocument document = XDocument.Load(recentProjectsPath);

                XElement Xprojects = document.Element("Projects");
                foreach (XElement p in Xprojects.Elements())
                {
                    Grid projectE = new Grid();
                    string[] locationArray = p.Attribute("Path").Value.Split('\\');
                    projectE.Add(new Label()
                    {
                        Text = p.Attribute("Name").Value + " (" + locationArray[locationArray.Length-2] + ")",
                        VerticalOptions= LayoutOptions.Center,
                        FontSize = 24
                    });
                    projectE.Add(new Button()
                    {
                        Text = "Open",
                        HorizontalOptions = LayoutOptions.End,
                        Command = new Command(() =>
                        {
                            ManimGUI.OpenProject(new Project(p));
                        })
                    });
                    RecentProjectList.Add(projectE);
                }

                document.Save(recentProjectsPath);
            }
            
        }

        private async void OnNewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }
        private void OnOpenProject_Clicked(object sender, EventArgs e)
        {
            
        }

    }

}
