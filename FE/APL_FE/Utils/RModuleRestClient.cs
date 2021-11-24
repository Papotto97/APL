using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace APL_FE.Utils
{
    public class RModuleRestClient
    {
        private WebClient _webClient;
        private string _url;
        private readonly string _correctExpression = "Please insert a correct expression to search.";

        public readonly string PLOT1 = "plot_apl1";
        public readonly string PLOT2 = "plot_apl2";

        public RModuleRestClient()
        {
            _webClient = new WebClient();
            _webClient.Headers["Content-Type"] = "image/png";
            _webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36");
        }

        public Bitmap SearchPlot(string expression)
        {

            if (expression == null)
            {
                Console.WriteLine(_correctExpression);
                throw new Exception(_correctExpression);
            }
            else
            {
                try
                {
                    _url = $"{Properties.Settings.Default.R_URL}/{expression}";
                    using (Stream stream = _webClient.OpenRead(_url))
                    {
                        Bitmap bitmap;
                        bitmap = new Bitmap(stream);

                        if (bitmap != null)
                        {
                            bitmap.Save("plot");
                        }
                        else
                            throw new Exception("Generic error calling API");

                        return bitmap;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
    }
}
