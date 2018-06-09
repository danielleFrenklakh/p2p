using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

//using System.Web.Routing;
using Dns = System.Net.Dns;
using AddressFamily = System.Net.Sockets.AddressFamily;
namespace WindowsFormsApplication1
{
    public partial class register : Form
    {
        public string SERVER_IP = "127.0.0.1:3000";

        public register()
        {
            InitializeComponent();

        }

        private void titleRegister_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            string ipAddress = GetLocalIPAddress();
            //check if the user connected to internet at all
            Dictionary<string, string> data = new Dictionary<string, string>()
            { 
                {"username", ID.Text },
                { "password", Password.Text},
                {"ip_address",ipAddress}
            };
            string confirm = "";
            if (ID.Text != "" && Password.Text != "" && (Password.Text == confirmpsw.Text))
            {

                HttpHandler handler = new HttpHandler("http://"+ SERVER_IP +"/ register/");
                confirm = handler.Post(data).Result;
                Console.WriteLine(confirm);

                
                //server confirmation check
                //RegisterRoutes(RouteTable.Routes);

                if(!confirm.Equals("F"))
                {
                    homePage hp = new homePage(ID.Text, Password.Text);
                    hp.Show();
                    this.Hide();
                }
                             
            }
           
            
           
            //Console.WriteLine(taskResult);
            
            //if the register complited:
            
            //else:
            //go back to register page with suitable notification
        }
       // public static void RegisterRoutes(RouteCollection routes)
       // {
       //     routes.MapPageRoute("",
       //         "Category/{action}/{categoryName}",
       //         "~/categoriespage.aspx");
       // }
        // private string GetMacAddress()
        // {
        //     string macAddresses = string.Empty;
        //
        //     foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //     {
        //         if (nic.OperationalStatus == OperationalStatus.Up)
        //         {
        //             macAddresses += nic.GetPhysicalAddress().ToString();
        //             break;
        //         }
        //     }
        //     Console.WriteLine(macAddresses);
        //     return macAddresses;
        // }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)//email
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
