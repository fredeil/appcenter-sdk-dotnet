// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.AppCenter
{
    public partial class AppCenter
    {
        private const string PlatformIdentifier = "windowsdesktop";

        static void PlatformSetUserId(string userId)
        {
            AppCenterLog.Error(AppCenterLog.LogTag, "AppCenter.SetUserId is not supported on Windows.");
        }
    }
}
