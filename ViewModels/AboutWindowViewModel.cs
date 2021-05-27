using System.Reactive;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        public static string ProgName { get; } = Constants.Name;
        public static string ProgAuthor { get; } = $"by {Constants.Author}";
        public static string ProgGit { get; } = Constants.GitHubUrl;

        public static string ProgVersion { get; } = "Version " + Constants.GetVersion();
        
        public ReactiveCommand<Unit, AboutWindowViewModel> CloseCommand { get; }

        public AboutWindowViewModel()
        {
            CloseCommand = ReactiveCommand.Create(() => this);
        }
    }
}