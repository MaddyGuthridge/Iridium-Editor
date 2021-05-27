using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using IridiumEditor.ViewModels;
using ReactiveUI;

namespace IridiumEditor.Views
{
    public class ProjectDetailsWindow : ReactiveWindow<ProjectDetailsViewModel>
    {
        public ProjectDetailsWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d => d(ViewModel!.OkCommand.Subscribe(Close)));
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
