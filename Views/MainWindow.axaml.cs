using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Reactive;
using Avalonia.ReactiveUI;
using IridiumEditor.ViewModels;

namespace IridiumEditor.Views
{
    public partial class MainWindow : ReactiveWindow<ViewModels.MainWindowViewModel>
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel(this);

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
