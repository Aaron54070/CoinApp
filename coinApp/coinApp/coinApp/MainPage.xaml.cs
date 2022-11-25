using coinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms;

namespace coinApp
{
    public partial class MainPage : ContentPage
    {
        private string ApiKey = "F8F8694E-580B-4D7C-A413-AE2150567103";
        private string baseimageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_256/";
        public MainPage()
        {
            InitializeComponent();
            coinListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;
            var client = new RestClient("http://rest.coinapi.io/v1/assets/?filter_asset_id=BTC;DOGE;SGD;LTC;KRW");
            var request = new RestRequest();
            request.AddHeader("X-CoinAPI-Key", ApiKey);

            var response = client.Execute(request);
            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                if (!string.IsNullOrEmpty(c.Id_icon))
                    c.Icon_url = baseimageUrl + c.Id_icon.Replace("-", "") + ".png";
                else
                    c.Icon_url = "";
            }
            return coins;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }
    }
}
