using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.Http;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace WindowsFormsApplication1
{

    public class HttpHandler
    {
        private String address = "";
        private static readonly HttpClient client = new HttpClient();

        public HttpHandler(String address)
        {
            // address looks like this: http://localhost:1356/register
            this.address = address;
             
            //
            // TODO: Add constructor logic here
            //
        }
        public void setAddress(String new_address){
            this.address = new_address;
        }
     
        public async Task<string> Post(Dictionary<string, string> data)
        {
            /*  data should look like this
             * {
                 { "username", "danielle" },
                 { "password", "David2007" }
              };
              */
            Console.WriteLine("*******************In Post**************");
            var content = new FormUrlEncodedContent(data);
            Console.WriteLine("*******************In Post2 to address: " + address);
            var response = await client.PostAsync(address, content).ConfigureAwait(false); 
            Console.WriteLine("*******************In Post3**************");
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("*******************In Post4**************");
            return responseString;

            //var request = (HttpWebRequest)WebRequest.Create(address);
            //
            //var postData = "thing1=hello";
            //postData += "&amp;amp;amp;amp;amp;thing2=world";
            //var datat = Encoding.ASCII.GetBytes(postData);
            //
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = datat.Length;
            //
            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(datat, 0, datat.Length);
            //}
            //
            //var response = (HttpWebResponse)request.GetResponse();
            //
            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            //return responseString;
        }

    }
}
    