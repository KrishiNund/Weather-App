using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void FetchWeatherData(string city)
        {
            string apiKey = "api_key_from_openweatherapi";
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            { 
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode) { 
                    string data = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(data);

                    string temp = json["main"]["temp"].ToString();
                    string description = json["weather"][0]["description"].ToString();
                    string icon = json["weather"][0]["icon"].ToString();

                    weatherLabel.Text = $"temp: {temp} °C\n Description: {description}";
                } 
                else
                {
                    weatherLabel.Text = "City not found!";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = entryField.Text;
            FetchWeatherData(city);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
