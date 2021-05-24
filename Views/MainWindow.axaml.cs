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
            DataContext = new MainWindowViewModel(this);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.ShowDetails.RegisterHandler(DoShowDetailsWindow)));
        }
        
        private async Task DoShowDetailsWindow(InteractionContext<ProjectDetailsWindow, Unit> interaction)
        {
            var dialog = new ProjectDetailsWindow();
            dialog.DataContext = interaction.Input;

            await dialog.ShowDialog<Unit>(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
