using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Bookswagon.Credentials
{

    // Getter Setter methods 
    public class JsonCredData
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string outlookMail { get; set; }
        public string outlookPassword { get; set; }
        public string SearchBook { get; set; }
        public string Url { get; set; }
        public string title { get; set; }
        public string BookTitleToSearch { get; set; }
        public string RecipientName { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string subject { get; set; }
        public string contentBody { get; set; }
    }

    // Reading Json data from path location
    public static class JsonData
    {
        public static WebClient client = new WebClient();
        public static string text = client.DownloadString(@"C:\Users\Admin\source\repos\Bookswagon\Bookswagon\Credentials\Data.json");
        public static JsonCredData data = JsonConvert.DeserializeObject<JsonCredData>(text);
    }
}
