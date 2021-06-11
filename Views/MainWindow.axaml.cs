using System.Collections.Generic;
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
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.ShowDetails.RegisterHandler(DoShowDetailsWindow)));
            this.WhenActivated(d => d(ViewModel!.ShowAbout.RegisterHandler(DoShowAboutWindow)));
            this.WhenActivated(d => d(ViewModel!.SaveFile.RegisterHandler(DoSave)));
        }
        
        private async Task DoShowDetailsWindow(InteractionContext<ProjectDetailsViewModel, ProjectDetailsViewModel> interaction)
        {
            var dialog = new ProjectDetailsWindow {DataContext = interaction.Input};
            interaction.SetOutput(await dialog.ShowDialog<ProjectDetailsViewModel>(this));
        }
        
        private async Task DoShowAboutWindow(InteractionContext<AboutWindowViewModel, AboutWindowViewModel> interaction)
        {
            var dialog = new AboutWindow() {DataContext = interaction.Input};

            interaction.SetOutput(await dialog.ShowDialog<AboutWindowViewModel>(this));
        }

        private async Task DoSave(InteractionContext<Unit, string> interaction)
        {
            SaveFileDialog saveFileBox = new SaveFileDialog {Title = "Save Project As..."};
            //SaveFileBox.InitialFileName = Path.GetFullPath(DocumentFileName);
            //SaveFileBox.Directory = workdir;
            
            List<FileDialogFilter> filters = new List<FileDialogFilter>();
            FileDialogFilter filter = new FileDialogFilter();
            List<string> extension = new List<string> {"json"};
            filter.Extensions = extension;
            filter.Name = "JSON Project Files";
            filters.Add(filter);
            saveFileBox.Filters = filters;

            saveFileBox.DefaultExtension = "json";

            interaction.SetOutput(await saveFileBox.ShowAsync(this));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
