using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IridiumEditor;

namespace IridiumEditor.ViewModels
{
    class ProjectDetailsViewModel
    {
        private readonly int associatedProject;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }

        public string WorkTime { get; }

        public ProjectDetailsViewModel(int projId)
        {
            associatedProject = projId;

            Models.ProjectDetails details = App.Projects.GetProject(projId).details;

            Name = details.Name;
            Description = details.Description;
            Author = details.Author;
            Copyright = details.Copyright;
            WorkTime = "Working time: " + details.GetWorkingTime().ToString(@"d\:hh\:mm\:ss");
        }

        private void SaveDetails()
        {
            Models.ProjectDetails details = App.Projects.GetProject(associatedProject).details;

            details.Name = Name;
            details.Description = Description;
            details.Author = Author;
            details.Copyright = Copyright;
        }

        public void OnSaveClick()
        {
            SaveDetails();
        }
    }
}
