using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.Models
{
    public class Region : DataCollectionObject, INotifyPropertyChanged
    {
        public string Prefix { get; set; }
        public bool IsSelected { get; set; } = false;
        // event handler for updating the list views
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public Color TextColor { get; set; } = Color.Gray;
        public Color BackgroundColor { get; set; } = Color.Transparent;
    }
}
