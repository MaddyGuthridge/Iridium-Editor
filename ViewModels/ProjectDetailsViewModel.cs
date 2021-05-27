using System;
using System.Reactive;
using Avalonia.Threading;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class ProjectDetailsViewModel : ViewModelBase
    {
        private readonly int _associatedProject;

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                value = value.Trim();
                if (value == "") value = "Untitled Project";
                _name = value;
                WindowTitle = GenWindowTitle();
            }
        }

        public string Description { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }

        private string _workTime;
        private TimeSpan _workTimeSpan;

        private void WorkTimeTick(object? sender, EventArgs e)
        {
            _workTimeSpan += TimeSpan.FromSeconds(1);
            WorkTime = GenWorkTimeStr();
        }
        private string GenWorkTimeStr() => "Working time: " + _workTimeSpan.ToString(@"d\:hh\:mm\:ss");
        public string WorkTime
        {
            get => _workTime;
            private set => this.RaiseAndSetIfChanged(ref _workTime, value);
        }

        private string GenWindowTitle() => "Project Details - " + Name + $" - {Constants.Name}";
        private string _windowTitle;
        public string WindowTitle
        {
            get => _windowTitle;
            set => this.RaiseAndSetIfChanged(ref _windowTitle, value);
        }

        public ProjectDetailsViewModel(int projId)
        {
            _associatedProject = projId;

            Models.ProjectDetails details = App.Projects.GetProject(projId).details;

            _name = details.Name;
            _windowTitle = GenWindowTitle();
            Description = details.Description;
            Author = details.Author;
            Copyright = details.Copyright;
            
            _workTimeSpan = details.GetWorkingTime();
            _workTime = GenWorkTimeStr();
            // Why does this continue to work when we leave the scope of the constructor?
            DispatcherTimer workTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
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
            Models.ProjectDetails details = App.Projects.GetProject(_associatedProject).details;

            details.Name = Name;
            details.Description = Description;
            details.Author = Author;
            details.Copyright = Copyright;
        }
    }
}
