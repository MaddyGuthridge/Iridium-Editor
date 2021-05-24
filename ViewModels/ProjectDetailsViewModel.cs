using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using IridiumEditor;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class ProjectDetailsViewModel : ViewModelBase
    {
        private readonly int associatedProject;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }

        public string WorkTime { get; }

        public string WindowTitle
        { 
            get
            {
                return "Project Details - " + Name + " - Iridium";
            }
        }

        public ProjectDetailsViewModel(int projId)
        {
            associatedProject = projId;

            Models.ProjectDetails details = App.Projects.GetProject(projId).details;

            Name = details.Name;
            Description = details.Description;
            Author = details.Author;
            Copyright = details.Copyright;
            WorkTime = "Working time: " + details.GetWorkingTime().ToString(@"d\:hh\:mm\:ss");
            
            OkCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                SaveDetails();
            });
        }

        public ReactiveCommand<Unit, Unit> OkCommand { get; }
        
        private void SaveDetails()
        {
            Models.ProjectDetails details = App.Projects.GetProject(associatedProject).details;

            details.Name = Name;
            details.Description = Description;
            details.Author = Author;
            details.Copyright = Copyright;
        }
    }
}
