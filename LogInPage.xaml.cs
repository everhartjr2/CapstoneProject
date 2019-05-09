using System;

using TCSS_WindowsApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TCSS_WindowsApp.Views
{
    public sealed partial class LogInPage : Page
    {
        public LogInViewModel ViewModel { get; } = new LogInViewModel();

        public LogInPage()
        {
            InitializeComponent();
        }
    }
}
