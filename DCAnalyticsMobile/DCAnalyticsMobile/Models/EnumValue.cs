using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class EnumValue : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public int Code { get; set; }
        public string TableName { get; set; }
        //Keep track of each item selected
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
