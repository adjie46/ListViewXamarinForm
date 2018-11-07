using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace List
{
    
    public partial class MainPage : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        string heightList;
        int heightRowsList = 90;
        private const string Url = "https://next.json-generator.com/api/json/get/EkiykGshr";
        // This handles the Web data request
        private HttpClient _client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            GetJSON();
        }
        public async void GetJSON()
        {
            //Check network status   
            if (CrossConnectivity.Current.IsConnected)
            {

                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("https://next.json-generator.com/api/json/get/EkiykGshr");
                string contactsJson = await response.Content.ReadAsStringAsync();
                ContactList ObjContactList = new ContactList();
                if (contactsJson != "")
                {
                    //Converting JSON Array Objects into generic list  
                    ObjContactList = JsonConvert.DeserializeObject<ContactList>(contactsJson);
                }
                //Binding listview with server response    
                listviewConacts.ItemsSource = ObjContactList.foos;
            }
            else
            {
                await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }
            //Hide loader after server response    
            ProgressLoader.IsVisible = false;
        }
    }
}
