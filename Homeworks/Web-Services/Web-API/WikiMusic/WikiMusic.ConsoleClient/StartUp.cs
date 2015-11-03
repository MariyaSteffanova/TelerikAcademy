namespace WikiMusic.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Text;
    using Newtonsoft.Json.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.Write("Please enter your localhost port:");
            var port = int.Parse(Console.ReadLine().Trim());
            var connection = new Uri(string.Format("http://localhost:{0}/", port));

            PrintJsonSongs(connection, "api/songs");
            PostSongs(connection, "api/artists");

            Console.ReadLine();
        }

        private static async void PrintJsonSongs(Uri connection, string requestPath)
        {
            // Thank you, Misha <3
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Songs: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PostSongs(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Name\": \"Lindsey Stirling\",\"Country\": \"USA\",\"BirthDate\": \"1986-09-21T00:00:00Z\" }");

                var response = await httpClient.PostAsync(
                    requestPath,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json"));

                string artist = await response.Content.ReadAsStringAsync();
                Console.WriteLine(Environment.NewLine + "Added Artist: " + artist);
            }
        }
    }
}
