namespace ManimGUI.Windows
{
    public partial class StartupPage : ContentPage
    {
        public StartupPage()
        {
            InitializeComponent();
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
