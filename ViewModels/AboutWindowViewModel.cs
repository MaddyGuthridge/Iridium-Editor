using System.Reactive;
using ReactiveUI;

namespace IridiumEditor.ViewModels
{
    public class AboutWindowViewModel : ViewModelBase
    {
        public static string ProgName { get; } = "Iridium";
        public static string ProgAuthor { get; } = "by Miguel Guthridge";
        public static string ProgGit { get; } = "https://github.com/MiguelGuthridge/Iridium-Editor";
        
        public ReactiveCommand<Unit, AboutWindowViewModel> CloseCommand { get; }

        public AboutWindowViewModel()
        {
            CloseCommand = ReactiveCommand.Create(() => this);
        }
    }
}