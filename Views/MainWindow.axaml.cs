using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using IridiumEditor.ViewModels;
using ReactiveUI;

namespace IridiumEditor.Views
{
    public class MainWindow : ReactiveWindow<ViewModels.MainWindowViewModel>
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.ShowDetails.RegisterHandler(DoShowDetailsWindow)));
        }
        
        private async Task DoShowDetailsWindow(InteractionContext<ProjectDetailsViewModel, ProjectDetailsViewModel> interaction)
        {
            var dialog = new ProjectDetailsWindow {DataContext = interaction.Input};

            interaction.SetOutput(await dialog.ShowDialog<ProjectDetailsViewModel>(this));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
