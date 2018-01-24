using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyConverter
{
    class RemoteRequest
    {
        private string remoteApiForLatestRate = "https://api.fixer.io/latest";
        private string remoteApiForHistoricalRate = "https://api.fixer.io/";

        private string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //Cookie cookie = new Cookie();
            CookieContainer cookieContainer = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookieContainer;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        private string HttpGet(string baseUrl, string postDataStr = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + (postDataStr == "" ? "" : "?") + postDataStr);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        public string GetLatestRate(string currencyCode1, string currencyCode2)
        {
            if(currencyCode1 == currencyCode2)
            {
                return 1.ToString();
            }
            else
            {
                string rate = HttpGet(remoteApiForLatestRate, String.Format("base={0}", currencyCode1));
                //string rate = HttpGet(remoteApiForLatestRate);
                Root ra = JsonConvert.DeserializeObject<Root>(rate);
                //DataTable dt = JsonConvert.DeserializeObject<DataTable>(rate);
                string returnRate = "";
                foreach (System.Reflection.PropertyInfo p in ra.Rates.GetType().GetProperties())
                {
                    if (p.Name == currencyCode2)
                    {
                        returnRate = p.GetValue(ra.Rates).ToString();
                    }
                }
                return returnRate;
            }
            
        }
    }
    public class Rates
    {
        /// <summary>
        /// 
        /// </summary>
        public double AUD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BGN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BRL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double CAD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double CHF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double CNY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double CZK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DKK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double GBP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HKD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HRK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HUF { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double IDR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ILS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double INR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double JPY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double KRW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MXN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MYR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NOK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NZD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PHP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PLN { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RON { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RUB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double SEK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double SGD { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double THB { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TRY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ZAR { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double EUR { get; set; }
        public double USD { get; set; }
    }
    public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string Base { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Date { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Rates Rates { get; set; }
        }
}
