using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public enum SyncDirection
    {
        None = 0,
        Up,
        Down,
        TwoWay
    }

    public enum MessageType
    {
        Configuration,
        Regular,
        Exit,
        Gps,
        Info,
        Warning,
        Discard,
        Logout
    }

    public enum QuestionaireStatus
    {
        Create,
        Modify
    }

    public enum PageNavigation
    {
        Profile,
        Synchronize,
        RecentActivity,
        Settings,
        Notifications,
        HelpSupport,
        Logout
    }

    public enum LocationType
    {
        Current,
        LastKnown
    }
}
