using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MakeItRain.Classes
{
    class CompanyService
    {
        public static CompanyResult GetStock(string input)
        {
            string urlMarkit = "http://dev.markitondemand.com/Api/v2/Quote/json?symbol=" + input;

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string json = webClient.DownloadString(urlMarkit);

                    var o = JObject.Parse(json);

                    CompanyResult cr = new CompanyResult();

                    cr.status = o["Status"].ToString();

                    if (cr.status == null)
                    {
                        Console.WriteLine("There is no data for " + input + ". Please make sure you have written the correct symbol for the company you are looking for.");
                        return null;
                    }

                    else
                    {
                        cr.name = o["Name"].ToString();

                        cr.symbol = o["Symbol"].ToString();

                        cr.lastPrice = o["LastPrice"].ToString();

                        cr.low = o["Low"].ToString();

                        cr.high = o["High"].ToString();

                        string lastPrice = cr.lastPrice;

                        decimal priceParse = Convert.ToDecimal(lastPrice);

                        return cr;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("There was an error, please try again.");
                return null;
            }
        }
    }
}
