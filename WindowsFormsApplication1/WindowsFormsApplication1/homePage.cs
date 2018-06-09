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
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace WindowsFormsApplication1
{

    /* public class Win32
     {
         [DllImport("client_server.dll")]
         public static extern int main(string ip);

       
     }*/

    public partial class homePage : Form
    {
        public string SERVER_IP = "127.0.0.1:3000";
        //[DllImport(@".\client_server.dll")]
        //public static extern int mainFunction(char[] ip);

        // [DllImport(@".\connection2.dll")]
        // public static extern int main();


        static string id;
        static string psw;

        public homePage()
        {
            InitializeComponent();
            myID.Text = id;
            myPsw.Text = psw;
        }
        public homePage(string new_id, string new_psw)
        {
            id = new_id;
            psw = new_psw;

            InitializeComponent();
            myID.Text = id;
            myPsw.Text = psw;
            label9.Text = getMyIP();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //while not asked to connect by another user
            allowconnection.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /*private void Change_Click(object sender, EventArgs e)
         {
             string btPw = "";
             btPw = CreatePassword(8);
             myPsw.Text = btPw;
         }*/
        public string getMyIP()
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
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        /*private void Set_Click(object sender, EventArgs e)
        {
            setPswd m = new setPswd(this);
            m.Show();
            this.Hide();
        }*/

        private void MyPassword_Click(object sender, EventArgs e)
        {

        }
        private void form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            Console.WriteLine(e.KeyChar);
        }
        private void connectBtm_Click(object sender, EventArgs e)
        {

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"username", PartnerID.Text },
                { "password", PartnerPsw.Text}
            };
            HttpHandler handler = new HttpHandler("http://" + SERVER_IP + "/connect/");
            string received_ip = handler.Post(data).Result;
            Console.WriteLine(received_ip);

            //string strCmdText;
            //strCmdText = "ffplay -f mpegts udp://127.0.0.1:7654";//client
            //strCmdText = "ffmpeg -f gdigrab -i desktop -f mpegts udp:127.0.0.1:7654";//server
            //system.Diagnostics.Process.Start("CMD.exe", strCmdText);

            // var thread_cmd_handler = new Thread(cmd_handler);

            if (received_ip != "F")
            {
                 Thread cpp = new Thread(() => cpp_handler(received_ip, 1));
                 cpp.Start();

                 Thread ffmpeg = new Thread(() => ffmpeg_handler(received_ip, 1));
                 ffmpeg.Start();

                //cpp_handler(received_ip, 1);

                //ffmpeg_handler(received_ip);
                // ThreadStart cmdThread = new ThreadStart(cmd_handler);
            }


            //this.Hide();
        }

        private void cpp_handler(string received_ip, int i)
        {

            System.Windows.Forms.MessageBox.Show("cmd");

            var process = new Process();
            var startInfo = new ProcessStartInfo();
            if (i == 1)
            {
                startInfo.FileName = "client_server.exe";
                startInfo.Arguments = received_ip;
            }
            else
            {
                startInfo.FileName = "server_client.exe";
            }


            startInfo.UseShellExecute = true;

            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();
        }

        private void ffmpeg_handler(string received_ip, int check)
        {
            System.Windows.Forms.MessageBox.Show("ffmpeg");

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            //System.Windows.Forms.MessageBox.Show("1");

            cmd.Start();
            //System.Windows.Forms.MessageBox.Show("2");

            //string command = "ffplay -f mpegts udp://";//server
            if(check==1)
            {
                string command = "ffmpeg - f gdigrab - i desktop - f mpegts udp:";//client
                string ip = received_ip;
                string port = ":5643";
                cmd.StandardInput.WriteLine(command + ip + port);//client
            }
            else
            {
                string command = "ffplay -f mpegts udp://";
                string ip =IP.Text;
                string port = ":5643";
                cmd.StandardInput.WriteLine(command + ip + port);//server

            }

            //cmd.StandardInput.WriteLine(command + ip + port);
            //System.Windows.Forms.MessageBox.Show("3");

            //cmd.StandardInput.WriteLine("ffmpeg -f gdigrab -i desktop -f mpegts udp:127.0.0.1:7654");

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            System.Windows.Forms.MessageBox.Show("4");

            //Socket s = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);  
            //viewScreen m = new viewScreen();
            //m.Show();
        }
        private void open_command_line()
        {


        }
        private void PartnerID_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void allowConnectBtm_Click(object sender, EventArgs e)
        {

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            
            cmd.StandardInput.WriteLine("ffmpeg -f gdigrab -i desktop -f mpegts udp:127.0.0.1:7654");

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }*/

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            register rg = new register();
            rg.Show();

        }

        private void allowconnection_Click(object sender, EventArgs e)
        {
            if(IP.Text!="")
            {
                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"username", myID.Text }
                };
                HttpHandler handler = new HttpHandler("http://" + SERVER_IP + "/allowConnection/");
                //string received_ip = handler.Post(data).Result;
                // cpp_handler("blaa", 2);
                Thread cpp = new Thread(() => cpp_handler("blaa", 2));
                cpp.Start();

                Thread ffmpeg = new Thread(() => ffmpeg_handler(IP.Text, 0));
                ffmpeg.Start();
                /*var process = new Process();
                var startInfo = new ProcessStartInfo();

                startInfo.FileName = "ffmpeg -f gdigrab -i desktop -f mpegts udp:127.0.0.1:7654";
                //startInfo.Arguments = received_ip;

                startInfo.UseShellExecute = true;

                process.StartInfo = startInfo;
                process.Start();

                process.WaitForExit();*/

                /*Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();


                cmd.StandardInput.WriteLine("ffmpeg -f gdigrab -i desktop -f mpegts udp:127.0.0.1:7654");

                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());*/
            }

        }

        private void logout_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"username", myID.Text },
            };
            HttpHandler handler = new HttpHandler("http://" + SERVER_IP + "/logout/");
            string receive = handler.Post(data).Result;
            Console.Write(receive);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}