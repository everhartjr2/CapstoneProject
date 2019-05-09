using System;
using System.Collections.ObjectModel;

using TCSS_WindowsApp.Core.Models;
using TCSS_WindowsApp.Core.Services;
using TCSS_WindowsApp.Helpers;

namespace TCSS_WindowsApp.ViewModels
{
    public class ScheduleViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
