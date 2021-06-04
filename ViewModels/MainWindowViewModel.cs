using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
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

        private readonly Project _project;

        public MainWindowViewModel()
        {
            _project = new Project();
            WindowTitle = GenWindowTitle();
            
            ShowDetails = new Interaction<ProjectDetailsViewModel, ProjectDetailsViewModel>();
            ProjectDetailsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var details = new ProjectDetailsViewModel(_project.details);

                await ShowDetails.Handle(details);
                WindowTitle = GenWindowTitle();
            });
            
            ShowAbout = new Interaction<AboutWindowViewModel, AboutWindowViewModel>();
            AboutIridiumCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var about = new AboutWindowViewModel();

                await ShowAbout.Handle(about);
            });

            QuitProgram = new Interaction<Unit, Unit>();
            QuitProgramCommand = ReactiveCommand.Create(() =>
            {
                QuitProgram.Handle(Unit.Default);
            });
        }

        public Interaction<ProjectDetailsViewModel, ProjectDetailsViewModel> ShowDetails { get; }
        public ICommand ProjectDetailsCommand { get; }
        
        public Interaction<AboutWindowViewModel, AboutWindowViewModel> ShowAbout { get; }
        public ICommand AboutIridiumCommand { get; }
        
        public Interaction<Unit, Unit> QuitProgram { get; }
        public ICommand QuitProgramCommand { get; }
        
        private string GenWindowTitle()
        {
            return _project.details.Name + $" - {Constants.Name}";
        }
    }
}
