using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Threading;
using IridiumEditor;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class ProjectDetailsViewModel : ViewModelBase
    {
        private readonly int associatedProject;

        private string name;

        public string Name
        {
            get => name;
            set
            {
                value = value.Trim();
                if (value == "") value = "Untitled Project";
                name = value;
                WindowTitle = GenWindowTitle();
            }
        }

        public string Description { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }

        private string workTime;
        private TimeSpan workTimeSpan;
        private DispatcherTimer workTimer;

        private void WorkTimeTick(object sender, EventArgs e)
        {
            workTimeSpan += TimeSpan.FromSeconds(1);
            WorkTime = GenWorkTimeStr();
        }
        private string GenWorkTimeStr() => "Working time: " + workTimeSpan.ToString(@"d\:hh\:mm\:ss");
        public string WorkTime
        {
            get => workTime;
            private set => this.RaiseAndSetIfChanged(ref workTime, value);
        }

        private string GenWindowTitle() => "Project Details - " + Name + " - Iridium";
        private string windowTitle;
        public string WindowTitle
        {
            get => windowTitle;
            set => this.RaiseAndSetIfChanged(ref windowTitle, value);
        }

        public ProjectDetailsViewModel(int projId)
        {
            associatedProject = projId;

            Models.ProjectDetails details = App.Projects.GetProject(projId).details;

            Name = details.Name;
            WindowTitle = GenWindowTitle();
            Description = details.Description;
            Author = details.Author;
            Copyright = details.Copyright;
            
            workTimeSpan = details.GetWorkingTime();
            WorkTime = GenWorkTimeStr();
            workTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            workTimer.Tick += WorkTimeTick;
            workTimer.Start();
            
            OkCommand = ReactiveCommand.Create(() =>
            {
                SaveDetails();
                return this;
            });
            CancelCommand = ReactiveCommand.Create(() => this);
        }

        public ReactiveCommand<Unit, ProjectDetailsViewModel> OkCommand { get; }
        public ReactiveCommand<Unit, ProjectDetailsViewModel> CancelCommand { get; }
        
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
