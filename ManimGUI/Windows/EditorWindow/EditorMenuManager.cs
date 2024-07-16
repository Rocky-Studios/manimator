using System.ComponentModel;
using System.Windows.Input;

namespace ManimGUI.Windows.EditorWindow
{
    public class EditorMenuManager : INotifyPropertyChanged
    {
        // FILE
        public ICommand NewProjectCommand { get; private set; }
        public ICommand NewSceneSlideCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveAsCommand { get; private set; }
        public ICommand SaveACopyCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }
        public ICommand ProjectSettingsCommand { get; private set; }
        // EDIT
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }
        public ICommand CutCommand { get; private set; }
        public ICommand CopyCommand { get; private set; }
        public ICommand PasteCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand PreferencesCommand { get; private set; }

        public EditorMenuManager()
        {
            NewProjectCommand = new Command(NewProject);
            NewSceneSlideCommand = new Command(NewSceneSlide);
            OpenCommand = new Command(Open);
            CloseCommand = new Command(Close);
            ExitCommand = new Command(Exit);
            SaveCommand = new Command(Save);
            SaveAsCommand = new Command(SaveAs);
            SaveACopyCommand = new Command(SaveACopy);
            ImportCommand = new Command(Import);
            ExportCommand = new Command(Export);
            ProjectSettingsCommand = new Command(ProjectSettings);
            UndoCommand = new Command(Undo);
            RedoCommand = new Command(Redo);
            CutCommand = new Command(Cut);
            CopyCommand = new Command(Copy);
            PasteCommand = new Command(Paste);
            DeleteCommand = new Command(Delete);
            PreferencesCommand = new Command(Preferences);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NewProject()
        {
            throw new NotImplementedException();
        }

        private void NewSceneSlide()
        {
            throw new NotImplementedException();
        }

        private void Open()
        {
            throw new NotImplementedException();
        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            Application.Current.Quit();
        }

        private void Save()
        {
            throw new NotImplementedException();
        }

        private void SaveAs()
        {
            throw new NotImplementedException();
        }

        private void SaveACopy()
        {
            throw new NotImplementedException();
        }

        private void Import()
        {
            throw new NotImplementedException();
        }

        private void Export()
        {
            throw new NotImplementedException();
        }

        private void ProjectSettings()
        {
            throw new NotImplementedException();
        }

        private void Undo()
        {
            throw new NotImplementedException();
        }

        private void Redo()
        {
            throw new NotImplementedException();
        }

        private void Cut()
        {
            throw new NotImplementedException();
        }

        private void Copy()
        {
            throw new NotImplementedException();
        }

        private void Paste()
        {
            throw new NotImplementedException();
        }

        private void Delete()
        {
            throw new NotImplementedException();
        }

        private void Preferences()
        {
            throw new NotImplementedException();
        }
    }
}
