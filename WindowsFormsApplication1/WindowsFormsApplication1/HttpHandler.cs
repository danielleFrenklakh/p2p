using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;


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
            this.address = address;
        }
        public void setAddress(String new_address){
            this.address = new_address;
        }
     
        public async Task<string> Post(Dictionary<string, string> data)
        {
            var content = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(address, content).ConfigureAwait(false); 
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

    }
}
    