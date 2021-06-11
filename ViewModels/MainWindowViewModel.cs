using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Controls;
using IridiumEditor.Models;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _windowTitle = "";
        public string WindowTitle
        {
            get => _windowTitle;
            set => this.RaiseAndSetIfChanged(ref _windowTitle, value);
        }
        public string Hint => "Hint Message";
        public string NoteCount => "Note Count: 17048";
        public string CursorPosition => "13.3.120 : 12";

        private Project _project;

        public MainWindowViewModel()
        {
            _project = new Project();
            WindowTitle = GenWindowTitle();
            
            ShowDetails = new Interaction<ProjectDetailsViewModel, ProjectDetailsViewModel>();
            ProjectDetailsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var details = new ProjectDetailsViewModel(_project.Details);

                await ShowDetails.Handle(details);
                WindowTitle = GenWindowTitle();
            });

            SaveFile = new Interaction<Unit, string>();
            SaveFileCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                _project.Save(await SaveFile.Handle(Unit.Default));
            });
            OpenFile = new Interaction<Unit, string>();
            OpenFileCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                string f = await OpenFile.Handle(Unit.Default);
                _project = new Project(f);
                WindowTitle = GenWindowTitle();
            });
            
            ShowAbout = new Interaction<AboutWindowViewModel, AboutWindowViewModel>();
            AboutIridiumCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var about = new AboutWindowViewModel();

                await ShowAbout.Handle(about);
            });
        }

        public Interaction<ProjectDetailsViewModel, ProjectDetailsViewModel> ShowDetails { get; }
        public ICommand ProjectDetailsCommand { get; }
        
        public Interaction<Unit, string> SaveFile { get; }
        public ICommand SaveFileCommand { get; }
        public Interaction<Unit, string> OpenFile { get; }
        public ICommand OpenFileCommand { get; }
        
        public Interaction<AboutWindowViewModel, AboutWindowViewModel> ShowAbout { get; }
        public ICommand AboutIridiumCommand { get; }

        
        
        public void QuitProgramCommand()
        {
            Environment.Exit(0);
        }

        private string GenWindowTitle()
        {
            return _project.Details.Name + $" - {Constants.Name}";
        }
    }
}
