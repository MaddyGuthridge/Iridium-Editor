using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using IridiumEditor.ViewModels;

namespace IridiumEditor.Views
{
    public partial class MainWindow : Window
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
