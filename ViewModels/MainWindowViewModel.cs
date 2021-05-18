using System;
using System.Collections.Generic;
using System.Text;

namespace IridiumEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Title => "Iridium Editor";
        public string Hint => "Hint Message";
        public string NoteCount => "Note Count: 17048";
        public string CursorPosition => "13.3.120 : 12";

        private int project;

        public MainWindowViewModel()
        {
            project = App.Projects.CreateProject();
        }

        public void OnTitleMenuClick()
        {
            ProjectDetails details = new ProjectDetails(project);
            details.Show();
        }
    }
}
