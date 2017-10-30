using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using TestBot;

namespace AdaBot
{
    public static class Helpers
    {
        public static MemoryStream NewStream(this Stream s)
        {
            var ms = new MemoryStream();
            s.CopyTo(ms);
            ms.Position = 0;
            return ms;
        }
        public static async System.Threading.Tasks.Task UploadFileAsync(Uri uri, string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var client = new HttpClient();
                var response = await client.PostAsync(uri, new StreamContent(stream));
                response.EnsureSuccessStatusCode();
            }
        }

        public static List<TaskIn> GetTasks()
        {
            StorageConnecting sC = new StorageConnecting("tasks", "Tasks.json");
            string json = sC.GetJSon();
            List<TaskIn> tasks = JsonConvert.DeserializeObject<List<TaskIn>>(json);
            return tasks;
        }
        public static int NumParser(string inp)
        {
            string withoutnum = "";
            int result = 0;
            for (int i = 0; i < inp.Length; i++)
            {
                if (Char.IsDigit(inp[i]))
                {
                    withoutnum += inp[i];
                }
            }
            if (Int32.TryParse(withoutnum, out result))
            {

            }
            else
            {
                result = -1;
            }

            return result;
        }

        public static async Task<string> TranslateText(string inputText, string language, string accessToken)
        {
            string result = "";
            string url = "http://api.microsofttranslator.com/v2/Http.svc/Translate";
            string query = $"?text={System.Net.WebUtility.UrlEncode(inputText)}&to={language}&contentType=text/plain";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(url + query);
                result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return "Hata: " + result;

                var translatedText = XElement.Parse(result).Value;
                return translatedText;
            }
            return result;
        }
        
        public static async Task<string> GetAuthenticationToken(string key)
        {
            string endpoint = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                var response = await client.PostAsync(endpoint, null);
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }
        }
    }
}