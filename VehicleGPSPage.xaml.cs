using System;

using TCSS_WindowsApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TCSS_WindowsApp.Views
{
    public sealed partial class VehicleGPSPage : Page
    {
        public VehicleGPSViewModel ViewModel { get; } = new VehicleGPSViewModel();

        public VehicleGPSPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
