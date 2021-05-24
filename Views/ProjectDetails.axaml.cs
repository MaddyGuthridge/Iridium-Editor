using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
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

        public void OnClickOk(object sender, RoutedEventArgs e)
        {
            //DataContext.SaveDetails();
            Close();
        }
    }
}
