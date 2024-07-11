using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Maui.Core.Primitives;

namespace ManimGUI.Windows
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
                projectLocation = pickedFolder.Path;
                (sender as Button).Text = "Choose (" + pickedFolder.Name + ")";
            }
            else
            {
                
            }

        }

        private void ProjectName_Changed(object sender, TextChangedEventArgs e)
        {
            projectName = e.NewTextValue;
        }

        private void NewProject_Clicked(object sender, EventArgs e)
        {
            Project project = new(projectName, projectLocation);
            ManimGUI.New(project);
        }
    }
}