using System.ComponentModel;
using System.Windows.Input;

namespace ManimGUI.Windows.EditorWindow
{
    public class EditorMenuManager : INotifyPropertyChanged
    {
        public ICommand ExitCommand { get; private set; }

        public EditorMenuManager()
        {
            ExitCommand = new Command(Exit);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Exit()
        {
            Application.Current.Quit();
        }
    }
}
