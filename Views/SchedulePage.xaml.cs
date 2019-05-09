﻿using System;

using TCSS_WindowsApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TCSS_WindowsApp.Views
{
    public sealed partial class SchedulePage : Page
    {
        public ScheduleViewModel ViewModel { get; } = new ScheduleViewModel();

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on SchedulePage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public SchedulePage()
        {
            InitializeComponent();
        }
    }
}
