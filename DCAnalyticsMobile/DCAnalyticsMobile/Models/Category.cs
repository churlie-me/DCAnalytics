using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.Models
{
    public class Category: DataCollectionObject, INotifyPropertyChanged
    {
        public bool IsSelected { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        public Color TextColor { get; set; } = Color.Gray;
        public Color BackgroundColor { get; set; } = Color.Transparent;
    }
}
