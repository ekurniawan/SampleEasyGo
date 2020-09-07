using Newtonsoft.Json;
using SampleXamarinJuly.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;

namespace SampleXamarinJuly
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //ambil api dari easy go API
        private async Task<MyResult> GetAPI(MyParam param)
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "https://vtsapi.easygo-gps.co.id/api/report/idle";
               
                try
                {
                    var jsonData = JsonConvert.SerializeObject(param);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    content.Headers.Add("Token", "");
                    //await DisplayAlert("Ket", $"{await content.ReadAsStringAsync()}", "OK");
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Gagal !");
                    }
                    else
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        MyResult myResult = JsonConvert.DeserializeObject<MyResult>(result);
                        return myResult;
                    } 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        } 



        private async void btnGetAPI_Clicked(object sender, EventArgs e)
        {
            var newParam = new MyParam
            {
                start_time = "2017/12/01",
                stop_time = "2020/12/19",
                lstNoPOL = new List<string> { "B 9181 UCN" }
            };
            try
            {
                var listNopol = await GetAPI(newParam);
                lblResult.Text = $"Hasil: {listNopol.ResponseCode} - {listNopol.ResponseMessage} \n\n";
                foreach (var data in listNopol.Data)
                {
                    lblResult.Text += $"{data.company_nm} - {data.idle.addr} \n";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"{ex.Message}", "OK");
            }
           
        }
    }
}
