using APL_FE.Utils;
using APL_FE.Utils.IMDB.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace APL_FE.RestClients
{
    public class IMDBRestClient
    {
        private WebClient _webClient;
        private string _url;
        private readonly string _correctExpression = "Please insert a correct expression to search.";

        public IMDBRestClient()
        {
            _webClient = new WebClient();
            _webClient.Headers["Content-Type"] = "application/json;charset=UTF-8";
            _webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36");
        }

        public SearchData SearchMovie(string expression)
        {

            try
            {
                if (expression == null)
                {
                    Console.WriteLine(_correctExpression);
                    return new SearchData() { ErrorMessage = _correctExpression };
                }
                else
                {
                    //EXAMPLE https://imdb-api.com/en/API/SearchMovie/k_12345678/leon the professional
                    _url = $"{Properties.Settings.Default.IMDB_APIURL}/{IMDBAPIEnum.SearchMovie}/{Properties.Settings.Default.IMDB_APIKEY}/{expression}";
                    string json;

#if DEBUG
                    Console.WriteLine("Debug version");
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                    using (StreamReader r = new StreamReader(projectDirectory + "\\APL_FE\\Resources\\Movies.json"))
                    {
                        json = r.ReadToEnd();
                        if (string.IsNullOrEmpty(json))
                            throw new Exception("Generic error calling API");

                        return JsonConvert.DeserializeObject<SearchData>(json);
                    }
#else
                    json = _webClient.DownloadString(_url);

                    if (string.IsNullOrEmpty(json))
                        throw new Exception("Generic error calling API");

                    return JsonConvert.DeserializeObject<SearchData>(json);
#endif
                }
            }
            catch (Exception ex)
            {
                return new SearchData() { ErrorMessage = ex.Message };
            }
        }
    }
}
