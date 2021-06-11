using System;
using System.Reactive;
using Avalonia.Threading;
using IridiumEditor.Models;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class ProjectDetailsViewModel : ViewModelBase
    {
        public readonly ProjectDetails Details;

        private string _name = null!;

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

        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Copyright { get; set; } = null!;

        private string _workTime = null!;
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
        private string _windowTitle = null!;
        public string WindowTitle
        {
            get => _windowTitle;
            set => this.RaiseAndSetIfChanged(ref _windowTitle, value);
        }

        public ProjectDetailsViewModel(ProjectDetails d)
        {
            Details = d;
            InitData();
            
            OkCommand = ReactiveCommand.Create(() =>
            {
                SaveDetails();
                return this;
            });
            CancelCommand = ReactiveCommand.Create(() => this);
        }

        public ProjectDetailsViewModel()
        {
            Details = new ProjectDetails();
            InitData();
        }

        private void InitData()
        {
            _name = Details.Name;
            _windowTitle = GenWindowTitle();
            Description = Details.Description;
            Author = Details.Author;
            Copyright = Details.Copyright;
            
            _workTimeSpan = Details.GetWorkingTime();
            _workTime = GenWorkTimeStr();
            // Why does this continue to work when we leave the scope of the constructor?
            DispatcherTimer workTimer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            workTimer.Tick += WorkTimeTick;
            workTimer.Start();
        }
        
        public ReactiveCommand<Unit, ProjectDetailsViewModel> OkCommand { get; } = null!;
        public ReactiveCommand<Unit, ProjectDetailsViewModel> CancelCommand { get; } = null!;

        private void SaveDetails()
        {
            Details.Name = Name;
            Details.Description = Description;
            Details.Author = Author;
            Details.Copyright = Copyright;
        }
    }
}
