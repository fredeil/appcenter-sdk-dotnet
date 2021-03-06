// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics.iOS.Bindings;
using Microsoft.AppCenter.Distribute;
using UIKit;

namespace Contoso.Forms.Puppet.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            Distribute.DontCheckForUpdatesInDebug();
            MSAnalytics.SetDelegate(new AnalyticsDelegate());
            LoadApplication(new App());
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            return base.FinishedLaunching(uiApplication, launchOptions);
        }

        public override void WillEnterForeground(UIApplication uiApplication)
        {
            base.WillEnterForeground(uiApplication);
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
    }

    public class AnalyticsDelegate : MSAnalyticsDelegate
    {
        public override void WillSendEventLog(MSAnalytics analytics, MSEventLog eventLog)
        {
            AppCenterLog.Debug(App.LogTag, "Will send event");
        }

        public override void DidSucceedSendingEventLog(MSAnalytics analytics, MSEventLog eventLog)
        {
            AppCenterLog.Debug(App.LogTag, "Did send event");
        }

        public override void DidFailSendingEventLog(MSAnalytics analytics, MSEventLog eventLog, NSError error)
        {
            AppCenterLog.Debug(App.LogTag, "Failed to send event with error: " + error);
        }
    }
}
