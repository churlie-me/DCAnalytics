using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DCAnalyticsMobile.Services
{
    public interface IGeoLocationSettings
    {
        Task<bool> OpenSettings();
        Task<bool> IsGpsEnabled();
        Task<Location> GetLocation();
    }
}
