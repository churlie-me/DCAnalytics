using DCAnalyticsMobile.Models;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Naxam.Controls.Forms;
using Naxam.Mapbox;
using Naxam.Mapbox.Layers;
using Naxam.Mapbox.Sources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace DCAnalyticsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preview : ContentPage
    {
        private Polygon polygon;
        private List<List<Position>> points = new List<List<Position>>();
        private List<Position> outter_points = new List<Position>();
        private Question question;

        public Preview(Question question = null)
        {
            InitializeComponent();
            this.question = question;
        }

        protected override void OnAppearing()
        {
            DrawLandPolygon();
            InitializeMap();
        }

        private async void InitializeMap()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                    map.Center = new LatLng(location.Latitude, location.Longitude);

                map.MapStyle = MapStyle.STREETS;
                map.ZoomLevel = 16;
                //On<iOS>().SetUseSafeArea(true);

                map.DidFinishLoadingStyleCommand = new Command<MapStyle>(HandleStyleLoaded);
            }
            catch (Exception ex)
            {

            }
        }

        private void Done(object sender, EventArgs args)
        {
            try
            {
                Navigation.RemovePage(this);
            }
            catch(Exception ex)
            {

            }
        }

        private void HandleStyleLoaded(MapStyle obj)
        {
            try
            {
                if (outter_points.Count >= 4)
                {
                    var polygon = new Polygon(points.Select(x => x.Select(y => new[] { y.Longitude, y.Latitude })));

                    var layer = new FillLayer("layer-id", "source-id")
                    {
                        FillColor = Color.FromHex("#FF0000")
                    };
                    var source = new GeoJsonSource("source-id", new Feature(polygon));

                    if (map.Functions.GetLayers().Count() > 0)
                    {
                        map.Functions.RemoveSource("source-id");
                        map.Functions.RemoveLayer("settlement-label");
                    }

                    map.Functions.AddSource(source);
                    map.Functions.AddLayerBelow(layer, "settlement-label");
                }
                else
                    DisplayAlert(null, "You have less than 4 points", "OK");
            }
            catch(Exception ex)
            {

            }
        }

        void DrawLandPolygon()
        {
            points.Clear();
            outter_points.Clear();
            foreach (Answer answer in question.Answers)
            {
                var coords = Regex.Split(answer.AnswerText, @"[^0-9\.]+").Where(c => c != "." && c.Trim() != "").ToList();
                outter_points.Add(FromLngLat(Convert.ToDouble(coords[0]), Convert.ToDouble(coords[1])));
            }

            //sort coordinates in ascending order
            outter_points = outter_points.OrderByDescending(p => p.Latitude).ToList();
            outter_points.Add(outter_points[0]);

            points.Add(outter_points);
        }

        static Position FromLngLat(double lat, double lng)
        {
            return new Position(lat, lng);
        }
    }
}