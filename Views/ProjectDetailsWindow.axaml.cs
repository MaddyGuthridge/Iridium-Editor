using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using IridiumEditor.ViewModels;
using ReactiveUI;

namespace IridiumEditor
{
    public partial class ProjectDetailsWindow : ReactiveWindow<ProjectDetailsViewModel>
    {
        public ProjectDetailsWindow(int projId)
        {
            DataContext = new ProjectDetailsViewModel(projId);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel.OkCommand.Subscribe(Close)));
        }

        public ProjectDetailsWindow()
        {
            // This code is never run, I just have it here so Avalonia doesn't
            // have a hissy fit
            DataContext = new ProjectDetailsViewModel(0);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
