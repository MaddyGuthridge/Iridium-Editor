using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using IridiumEditor.ViewModels;

namespace IridiumEditor
{
    public partial class ProjectDetails : Window
    {
        public ProjectDetails(int projId)
        {
            DataContext = new ProjectDetailsViewModel(projId);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public ProjectDetails()
        {

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
