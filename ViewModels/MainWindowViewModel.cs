using System;
using System.Collections.Generic;
using System.Text;

using IridiumEditor.Views;

namespace IridiumEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string WindowTitle => App.Projects.GetProject(project).details.Name + " - Iridium";
        public string Hint => "Hint Message";
        public string NoteCount => "Note Count: 17048";
        public string CursorPosition => "13.3.120 : 12";

        private int project;
        private MainWindow window;

        public MainWindowViewModel(MainWindow win)
        {
            project = App.Projects.CreateProject();
            window = win;
        }

        public void OnTitleMenuClick()
        {
            ProjectDetails details = new ProjectDetails(project);
            details.ShowDialog(window);
        }
    }
}
