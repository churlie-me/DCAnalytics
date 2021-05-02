using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Services;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Naxam.Mapbox.Expressions;
using Naxam.Mapbox.Layers;
using Naxam.Mapbox.Sources;
using Newtonsoft.Json;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandMapping : PopupPage, PromptPageState, LocationPageState
    {
        private MapView mapView;
        private Question question;
        private List<List<Position>> points = new List<List<Position>>();
        private List<Position> outer_points = new List<Position>();
        private bool isMappingClosed = false;
        private Location _location;
        private Polygon polygon;
        private Plugin.Geolocator.Abstractions.Position position;
        //private MapView map;
        public LandMapping(MapView mapView, Question question)
        {
            InitializeComponent();
            this.mapView = mapView;
            this.question = question;

            DrawLandPolygon();
            InitializeMap();
        }

        private async void InitializeMap()
        {
            try
            {
                //map = null;
                //map = new MapView { HorizontalOptions = LayoutOptions.Fill, HeightRequest = 300 };
                //mContainer.Children.Clear();
                //mContainer.Children.Add(map);

                _location = await Geolocation.GetLastKnownLocationAsync();
                if (_location != null)
                    map.Center = new LatLng(_location.Latitude, _location.Longitude);

                map.MapStyle = MapStyle.STREETS;
                map.ZoomLevel = 13;
                On<iOS>().SetUseSafeArea(true);
                map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);
            }
            catch (Exception ex)
            {

            }
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        private void OnProceed(object sender, EventArgs args)
        {
            try
            {
                if (outer_points.Count >= 4)
                {
                    SaveMapping();
                    Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
                }
                else
                    Task.Run(async () => await PopupNavigation.Instance.PushAsync(new MessageBox("The land your mapping is not enclosed", MessageType.Regular, this)));
            }
            catch (Exception ex)
            {

            }
        }

        private void OnCancelled(object sender, EventArgs args)
        {
            try
            {
                Task.Run(async () => await PopupNavigation.Instance.RemovePageAsync(this));
            }
            catch (Exception ex)
            {

            }
        }

        private LocationDialog locationDialog;
        private async void OnMap(object sender, EventArgs args)
        {
            try
            {
                locationDialog = new LocationDialog(this);
                await PopupNavigation.Instance.PushAsync(locationDialog, true);
            }
            catch (Exception ex)
            {

            }
        }

        //void ChangeButtonState(object sender)
        //{
        //    if (outer_points.Count > 3)
        //    {
        //        isMappingClosed = true;
        //    }
        //    else
        //    {
        //        isMappingClosed = false;
        //    }
        //}

        //private Timer addOutterPointsTimer;
        //void CollectOutterPoints()
        //{
        //    outer_points.Clear();

        //    addOutterPointsTimer = new Timer();
        //    addOutterPointsTimer.Elapsed += AddOutterPoint;
        //    addOutterPointsTimer.Interval = 3000; // in miliseconds
        //    addOutterPointsTimer.Start();
        //}

        void SaveMapping()
        {
            question.Answers = new List<Answer>();
            foreach(var outer_point in outer_points)
                question.Answers.Add(new Answer()
                {
                    Key = Guid.NewGuid().ToString(),
                    AnswerText = outer_point.Latitude + ", " + outer_point.Longitude
                });
        }

        double lat; double lng;
        void DrawLandPolygon()
        {
            try
            {
                points.Clear();
                outer_points.Clear();
                foreach (Answer answer in question.Answers)
                {
                    var coords = Regex.Split(answer.AnswerText, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "").ToList();
                    outer_points.Add(FromLngLat(Convert.ToDouble(coords[0]), Convert.ToDouble(coords[1])));
                }

                points.Add(outer_points);
            }
            catch (Exception ex)
            {

            }
        }

        void AddPointToPolygon(double latitude, double longitude)
        {
            outer_points.Add(FromLngLat(latitude, longitude));
        }

        static Position FromLngLat(double lng, double lat)
        {
            return new Position(lat, lng);
        }

        private void HandleStyleLoaded(MapStyle obj)
        {
            if (outer_points.Count >= 4)
                Map();
        }

        private void Map()
        {
            try
            {
                polygon = new Polygon(
                    points.Select(x => x.Select(y => new[] { y.Longitude, y.Latitude }))
                    );
                var layer = new FillLayer("layer-id", "source-id")
                {
                    FillColor = Color.FromHex("#FF0000")
                };
                var source = new GeoJsonSource("source-id", new Feature(polygon));

                if (map.Functions.GetLayers().Count() > 0)
                {
                    DisplayAlert(null, "Layers found", "OK");

                    map.Functions.RemoveSource("source-id");
                    map.Functions.RemoveLayer("settlement-label");

                    DisplayAlert(null, "Layers removed", "OK");
                }
                else
                {
                    DisplayAlert(null, "No layers found", "OK");
                }

                map.Functions.AddSource(source);
                map.Functions.AddLayerBelow(layer, "settlement-label");
                DisplayAlert(null, "Done Mapping", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert(null, ex.Message, "OK");
            }
        }

        private void UpdateMap()
        {
            try
            {
                string coords = "";

                //outer_points.Clear();
                //outer_points.Add(new Position(0.387285, 32.4966683)); outer_points.Add(new Position(0.386040, 32.504007)); outer_points.Add(new Position(0.383723, 32.507698));
                //outer_points.Add(new Position(0.377715, 32.506925)); outer_points.Add(new Position(0.377627, 32.502161)); outer_points.Add(new Position(0.387285, 32.4966683));
                outer_points = outer_points.Distinct().ToList();
                if (outer_points.Count > 0)
                {
                    points.Clear();
                    outer_points.Add(new Position(outer_points[0].Latitude, outer_points[0].Longitude));
                    points.Add(outer_points);
                }

                outer_points.ForEach(y => coords += "\n" + y.Longitude + ", " + y.Latitude);
                DisplayAlert(null, coords, "Ok");

                InitializeMap();
            }
            catch (Exception ex)
            {

            }
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

        public async void OnLocationCollected(Location location ) //Plugin.Geolocator.Abstractions.Position position
        {
            try
            {
                await PopupNavigation.Instance.RemovePageAsync(locationDialog);
                //_location = new Location()
                //                {
                //                    Latitude = position.Latitude,
                //                    Longitude = position.Longitude,
                //                    Accuracy = position.Accuracy,
                //                    Altitude = position.Altitude,
                //                    Speed = position.Speed,
                //                    Timestamp = position.Timestamp
                //                };

                _location = location;

                if (location != null)
                {
                    AddPointToPolygon(location.Latitude, location.Longitude);

                    UpdateMap();
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new MessageBox("Your Gps position could not be extracted, please turn on your gps and please ensure you have internet before you try again", MessageType.Gps, this, this));
                }
            }
            catch (Exception ex)
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

        public async void OnLocationIgnored()
        {
            await PopupNavigation.Instance.RemovePageAsync(locationDialog);
        }

        protected override void OnAppearing()
        {
            
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