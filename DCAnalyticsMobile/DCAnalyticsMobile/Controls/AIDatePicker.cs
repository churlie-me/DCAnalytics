using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.Controls
{
    public class AIDatePicker : DatePicker
    {
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder",
                                                                                            returnType: typeof(string),
                                                                                            declaringType: typeof(AIDatePicker),
                                                                                            defaultValue: default(string));
        public string Placeholder { get; set; }
        public int Occurance { get; internal set; }
    }
}
