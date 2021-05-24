using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using IridiumEditor.Views;

namespace IridiumEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string windowTitle = "";
        public string WindowTitle
        {
            get => windowTitle;
            set => this.RaiseAndSetIfChanged(ref windowTitle, value);
        }
        public string Hint => "Hint Message";
        public string NoteCount => "Note Count: 17048";
        public string CursorPosition => "13.3.120 : 12";

        private readonly int project;
        private readonly MainWindow window;

        public MainWindowViewModel(MainWindow win)
        {
            project = App.Projects.CreateProject();
            window = win;
            WindowTitle = GenWindowTitle();
        }

        private string GenWindowTitle()
        {
            return App.Projects.GetProject(project).details.Name + " - Iridium";
        }

        public void OnTitleMenuClick()
        {
            ProjectDetails details = new(project);
            details.ShowDialog(window);
            WindowTitle = GenWindowTitle();
        }
    }
}
