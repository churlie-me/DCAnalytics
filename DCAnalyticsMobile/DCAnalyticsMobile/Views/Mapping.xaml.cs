using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using DCAnalyticsMobile.Views.Popups;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Naxam.Mapbox.Annotations;
using Plugin.Geolocator.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapping : ContentPage, PromptPageState, LocationPageState
    {
        private List<Position> outer_points = new List<Position>();
        private Question question;
        private LocationDialog locationDialog;
        private static string MARKER_ICON = "ic_marker.png";
        public List<SymbolAnnotation> symbolAnnotations = new List<SymbolAnnotation>();
        private Location location;
        public Mapping(Question question = null)
        {
            InitializeComponent();
            //this.question = question;
            this.question = new Question
            {
                Answers = new List<Answer>()
            };

            map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);
        }

        public async void Preview(object sender, EventArgs args)
        {
            try
            {
                if (symbolAnnotations.Count >= 4)
                {
                    SaveMarkers();
                    await Navigation.PushAsync(new Preview(question));
                }
                else
                    await PopupNavigation.Instance.PushAsync(new MessageBox("The land you're mapping is not enclosed", MessageType.Regular, this));
            }
            catch (Exception ex)
            {

            }
        }

        private async void LocateMe(object sender, EventArgs args)
        {
            try
            {
                //var location = await Geolocation.GetLastKnownLocationAsync();
                var location = await new GeolocationManager(this).GetLocationAsync();
                map.Center = new LatLng(location.Latitude, location.Longitude);
                map.ZoomLevel = 16;
            }
            catch(Exception ex)
            {

            }
        }

        private void SaveMarkers()
        {
            try
            {
                question.Answers = new List<Answer>();
                foreach (var annotation in symbolAnnotations)
                    question.Answers.Add(new Answer()
                    {
                        Key = Guid.NewGuid().ToString(),
                        AnswerText = annotation.Coordinates.Lat + ", " + annotation.Coordinates.Long
                    });
            }
            catch(Exception ex)
            {

            }
        }

        public void Refresh(object sender, EventArgs args)
        {

        }

        protected override void OnAppearing()
        {
            try
            {
                RefreshLocation();
            }
            catch(Exception ex)
            {

            }
        }

        public async void RefreshLocation()
        {
            try
            {
                while (true)
                {
                    // Get latest location 
                    OnCollectLocation();

                    // pause for the next check+
                    await Task.Delay(10000);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnCollectLocation()
        {
            try
            {
                latitude.Text = "...........";
                longitude.Text = "...........";
                accuracy.Text = "...........";

                location = await new GeolocationManager(this).GetLocationAsync();
                if (location != null)
                {
                    longitude.Text = location.Longitude.ToString();
                    latitude.Text = location.Latitude.ToString();
                    accuracy.Text = location.Accuracy.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnLocationCollected(Location _location)
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(locationDialog);
                if (_location != null)
                {
                    location = _location;
                    latitude.Text = _location.Latitude.ToString();
                    longitude.Text = _location.Longitude.ToString();
                    accuracy.Text = _location.Accuracy.ToString();
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps position could not be extracted, please turn on your gps and please ensure you have internet before you try again", MessageType.Gps, this, this));
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        private void HandleStyleLoaded(MapStyle obj)
        {
            try
            {
                map.Annotations = symbolAnnotations.ToArray();
            }
            catch(Exception ex)
            {

            }
        }

        private void AddMapMarker(object sender, EventArgs args)
        {
            try
            {
                var symbolAnnotation = new SymbolAnnotation
                {
                    Coordinates = new LatLng(location.Latitude, location.Longitude),
                    IconImage = (ImageSource)MARKER_ICON,
                    IconSize = 1.0f,
                    IsDraggable = false,
                    Id = Guid.NewGuid().ToString()
                };

                symbolAnnotations.Add(symbolAnnotation);

                Refresh();
            }
            catch(Exception ex)
            {

            }
        }

        private void Undo(object sender, EventArgs args)
        {
            try
            {
                if (symbolAnnotations.Count > 0)
                {
                    symbolAnnotations.RemoveAt(symbolAnnotations.Count - 1);
                    Refresh();
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void Refresh()
        {
            try
            {
                map.Annotations = null;
                map.Annotations = symbolAnnotations.ToArray();
            }
            catch(Exception ex)
            {

            }
        }

        public async void OnEnableLocation()
        {
            new GeolocationManager(this).TurnOnLocation();

            //Subscribe to geolocation again
            if (locationDialog == null)
                locationDialog = new LocationDialog(this);

            await PopupNavigation.Instance.PushAsync(locationDialog, true);
        }

        public void OnLocationIgnored()
        {
            throw new NotImplementedException();
        }

        public void OnResumePage(object o)
        {
            throw new NotImplementedException();
        }

        public void OnSleepPage()
        {
            throw new NotImplementedException();
        }

        public void OnRebound()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnConfirm()
        {
            throw new NotImplementedException();
        }

        public void OnSaveDraft()
        {
            try { } catch (Exception ex) { }
        }
    }
}