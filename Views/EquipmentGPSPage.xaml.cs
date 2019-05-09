using System;

using TCSS_WindowsApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TCSS_WindowsApp.Views
{
    public sealed partial class EquipmentGPSPage : Page
    {
        public EquipmentGPSViewModel ViewModel { get; } = new EquipmentGPSViewModel();

        public EquipmentGPSPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
