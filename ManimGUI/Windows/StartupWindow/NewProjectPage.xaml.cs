using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Core.Primitives;

namespace ManimGUI.Windows.StartupWindow
{
	public partial class NewProjectPage : ContentPage
	{
        string projectName = "";
        string projectLocation = "";
        public NewProjectPage()
		{
			InitializeComponent();
		}

        private async void ChooseProjectLocation_Clicked(object sender, EventArgs e)
        {
            var folderPickerResult = await FolderPicker.PickAsync("");
            if (folderPickerResult.IsSuccessful)
            {
                Folder pickedFolder = folderPickerResult.Folder;
                projectLocation = Path.Combine(pickedFolder.Path, projectName);
                (sender as Button).Text = "Choose (" + pickedFolder.Name + "/" + projectName + ")";
            }
            else
            {
                
            }

        }

        private void ProjectName_Changed(object sender, TextChangedEventArgs e)
        {
            projectName = e.NewTextValue;
        }

        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            if (projectName.Length == 0)
            {
                await DisplayAlert("Notice", "Please enter a project name", "OK");
                return;
            }
            if (projectLocation.Length == 0)
            {
                await DisplayAlert("Notice", "Please select a project location", "OK");
                return;
            }
            Project project = new(projectName, projectLocation);
            //ManimGUI.New(project);

            // Create a new window
            var newWindow = new Window();

            // Set its content (you can use any MAUI view here)
            var contentPage = new StartupPage();
            contentPage.Content = new Label { Text = "Hello from the new window!" };

            // Set the MainPage of the new window
            newWindow.Page = contentPage;

            Application.Current.OpenWindow(newWindow);
            Application.Current.CloseWindow(this.Window);
        }
    }
}