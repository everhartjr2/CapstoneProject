using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MasterDetailPageNavigation.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
            AiForms.Renderers.iOS.SettingsViewInit.Init();
            Syncfusion.SfPdfViewer.XForms.iOS.SfPdfDocumentViewRenderer.Init();
            Syncfusion.SfRangeSlider.XForms.iOS.SfRangeSliderRenderer.Init();

            LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

