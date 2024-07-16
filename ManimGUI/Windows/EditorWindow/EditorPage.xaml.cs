using System.Windows.Input;

namespace ManimGUI.Windows.EditorWindow;

public partial class EditorPage : ContentPage
{
	public EditorPage()
	{
		InitializeComponent();
        BindingContext = new EditorMenuManager();
    }
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
    #if WINDOWS
                      var window = App.Current.Windows.FirstOrDefault().Handler.PlatformView as Microsoft.UI.Xaml.Window;
                      IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                      Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                      Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    (appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter).Maximize();
                // this line can maximize the window
    #endif

    }
}