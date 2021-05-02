using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Region = DCAnalyticsMobile.Models.Region;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AIDropdown : PopupPage
    {
        private SelectPageState selectPageState;
        private List<EnumValue> enumValues;
        private List<Category> categories;
        private List<Region> regions;
        private EnumValue _enumValue;
        private Label label;
        public AIDropdown(List<EnumValue> enumValues, SelectPageState selectPageState, Label label, List<Category> categories = null, List<Region> regions = null)
        {
            InitializeComponent();

            this.selectPageState = selectPageState;
            this.enumValues = enumValues;
            this.label = label;
            this.regions = regions;
            this.categories = categories;
            Init();
        }

        private void Init()
        {
            try
            {
                if (enumValues == null)
                    eValues.IsVisible = false;

                if (categories == null && regions == null)
                    starters.IsVisible = false;

                if (!string.IsNullOrEmpty(label.ClassId))
                {
                    if (enumValues != null)
                    {
                        EnumValue v = enumValues.Find(x => x.Code == Convert.ToInt32(label.ClassId));
                        if (v != null)
                        {
                            v.IsSelected = true;
                            v.TextColor = Color.White;
                            v.BackgroundColor = Color.FromHex("#39b835");
                            v.OnPropertyChanged();
                        }
                        eValues.ItemsSource = enumValues;
                    }
                    else if(categories != null)
                    {
                        Category c = categories.Find(x => x.Key == label.ClassId);
                        if (c != null)
                        {
                            c.IsSelected = true;
                            c.TextColor = Color.White;
                            c.BackgroundColor = Color.FromHex("#39b835");
                            c.OnPropertyChanged();
                        }

                        starters.ItemsSource = categories;
                    }
                    else if(regions != null)
                    {
                        Region r = regions.Find(x => x.Key == label.ClassId);
                        if (r != null)
                        {
                            r.IsSelected = true;
                            r.TextColor = Color.White;
                            r.BackgroundColor = Color.FromHex("#39b835");
                            r.OnPropertyChanged();
                        }

                        starters.ItemsSource = regions;
                    }
                }
                else
                {
                    if (enumValues != null)
                        eValues.ItemsSource = enumValues;
                    else if (categories != null)
                        starters.ItemsSource = categories;
                    else if (regions != null)
                        starters.ItemsSource = regions;
                }    
            }
            catch (Exception ex)
            {

            }
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                if (enumValues != null)
                    eValues.ItemsSource = enumValues;
                else if (categories != null)
                    starters.ItemsSource = categories;
                else if (regions != null)
                    starters.ItemsSource = regions;
            }
            else
            {
                if (enumValues != null)
                    eValues.ItemsSource = enumValues.Where(s => s.Description.ToLower().Contains(e.NewTextValue.ToLower()));
                else if (categories != null)
                    starters.ItemsSource = categories.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower()));
                else if (regions != null)
                    starters.ItemsSource = regions.Where(s => s.Name.ToLower().Contains(e.NewTextValue.ToLower())); ;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs args)
        {
            try
            {
                var _listView = sender as ListView;
                if (categories != null)
                {
                    var selectedCategory = args.Item as Category;
                    selectedCategory.IsSelected = true;
                    selectedCategory.TextColor = Color.White;
                    selectedCategory.BackgroundColor = Color.FromHex("#39b835");
                    selectedCategory.OnPropertyChanged();

                    var _category = selectedCategory;
                    // set the text color of the selected item
                    foreach (Category category in _listView.ItemsSource)
                    {
                        if (category != selectedCategory)
                            if (selectedCategory.IsSelected)
                            {
                                category.IsSelected = false;
                                category.TextColor = Color.Gray;
                                category.BackgroundColor = Color.Transparent;
                                category.OnPropertyChanged();
                            }
                    }

                    label.ClassId = _category.Key.ToString();
                    label.Text = _category.Name;
                }
                else if (enumValues != null)
                {
                    var selectedItem = args.Item as EnumValue;
                    selectedItem.IsSelected = true;
                    selectedItem.TextColor = Color.White;
                    selectedItem.BackgroundColor = Color.FromHex("#39b835");
                    selectedItem.OnPropertyChanged();

                    _enumValue = selectedItem;
                    // set the text color of the selected item
                    foreach (EnumValue enumValue in _listView.ItemsSource)
                    {
                        if (enumValue != selectedItem)
                            if (selectedItem.IsSelected)
                            {
                                enumValue.IsSelected = false;
                                enumValue.TextColor = Color.Gray;
                                enumValue.BackgroundColor = Color.Transparent;
                                enumValue.OnPropertyChanged();
                            }
                    }
                    label.ClassId = _enumValue.Code.ToString();
                    label.Text = _enumValue.Description;
                }
                else if (regions != null)
                {
                    var selectedRegion = args.Item as Region;
                    selectedRegion.IsSelected = true;
                    selectedRegion.TextColor = Color.White;
                    selectedRegion.BackgroundColor = Color.FromHex("#39b835");
                    selectedRegion.OnPropertyChanged();

                    var _region = selectedRegion;
                    // set the text color of the selected item
                    foreach (Region region in _listView.ItemsSource)
                    {
                        if (region != selectedRegion)
                            if (selectedRegion.IsSelected)
                            {
                                region.IsSelected = false;
                                region.TextColor = Color.Gray;
                                region.BackgroundColor = Color.Transparent;
                                region.OnPropertyChanged();
                            }
                    }

                    label.ClassId = _region.Key.ToString();
                    label.Text = _region.Name;
                }

                selectPageState.OnDropDownOptionSelected();
            }
            catch(Exception ex)
            {

            }
        }

        private void OnCancel(object sender, EventArgs args)
        {
            Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
        }

        private async void Exit(object sender, EventArgs args)
        {
            await PopupNavigation.Instance.RemovePageAsync(this);
        }
    }
}