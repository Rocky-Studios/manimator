using ManimGUI.Windows;

namespace ManimGUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartupPage());
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            if (window != null)
            {
                window.Title = "Manim GUI";
            }

            return window;
        }
    }
}
