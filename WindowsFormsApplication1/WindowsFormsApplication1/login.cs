using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using Dns = System.Net.Dns;
using AddressFamily = System.Net.Sockets.AddressFamily;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        public string SERVER_IP = "localHost:3000";

        public login()
        {
            InitializeComponent();
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectBtm_Click(object sender, EventArgs e)
        {
            string ipAddress = GetLocalIPAddress();
            //check if the user connected to the internet at all
            Dictionary<string, string> data = new Dictionary<string, string>()
            { 
                {"username", userNameBox.Text },
                { "password", passwordBox.Text},
                {"ip_address",ipAddress}
            };
            if(userNameBox.Text!="" && passwordBox.Text!="")
            {
                HttpHandler handler = new HttpHandler("http://"+ SERVER_IP +"/ login/");
                string confirm = handler.Post(data).Result;
                //Console.WriteLine(taskResult);
                //if the username exist and the password match:
                if (!confirm.Equals("F"))
                {
                    homePage hp = new homePage(userNameBox.Text, passwordBox.Text);
                    hp.Show();
                    this.Hide();
                }

            }
           
        }
        
        //private string GetMacAddress()
        //{
        //    string macAddresses = string.Empty;
        //
        //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //    {
        //        if (nic.OperationalStatus == OperationalStatus.Up)
        //        {
        //            macAddresses += nic.GetPhysicalAddress().ToString();
        //            break;
        //        }
        //    }
        //    Console.WriteLine(macAddresses);
        //    return macAddresses;
        //}
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

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
