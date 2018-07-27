using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class homePage : Form
    {
        public string SERVER_IP = "localHost:3000";

        static string id;//the username entered
        static string psw;//the password entered

        public homePage()
        {
            InitializeComponent();
            //initilizes the texts to display the data about the user, to the user
            myID.Text = id;
            myPsw.Text = psw;
        }
        public homePage(string new_id, string new_psw)
        {
            id = new_id;
            psw = new_psw;
            //initilizes the texts to display the data about the user, to the user
            InitializeComponent();
            myID.Text = id;
            myPsw.Text = psw;
            my_ip_address.Text = getMyIP();//sets to display the ip of the user on the screen

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //while not asked to connect by another user
            allowconnection.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string getMyIP()//function that gets the ip of the computer
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


        private void MyPassword_Click(object sender, EventArgs e)
        {

        }
        private void form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine(e.KeyChar);
        }

        private void connectBtm_Click(object sender, EventArgs e)//generates the ability to connect to another pc
        {
            Dictionary<string, string> data = new Dictionary<string, string>()//stores the data entered by the user 
            {
                {"username", PartnerID.Text },
                { "password", PartnerPsw.Text}
            };
            HttpHandler handler = new HttpHandler("http://" + SERVER_IP + "/connect/");//the distanation of the request
            string received_ip = handler.Post(data).Result;//sending and receiving a response from the POST request
            if (received_ip != "F")//if the connction was confirmed
            {
                Thread cpp = new Thread(() => cpp_handler(received_ip, 1));//open the mouse and keyboard handeling project with the first thread
                cpp.Start();//start thread

                Thread ffmpeg = new Thread(() => ffmpeg_handler(received_ip, 1));//open the screen sharing in the second thread in order fpr them to run in the same time
                ffmpeg.Start();//start thread


            }


        }

        private void cpp_handler(string received_ip, int i)//handeling mouse and keyboard sharing
        {
            var process = new Process();//opening a new process
            var startInfo = new ProcessStartInfo();
            if (i == 1)
            {
                startInfo.FileName = "client_server.exe";//setting the information of the process- the file that im willing to open
                startInfo.Arguments = received_ip;//get the argumants of the file
            }
            else
            {
                startInfo.FileName = "server_client.exe";
            }
            startInfo.UseShellExecute = true;//display the command line

            process.StartInfo = startInfo;
            process.Start();//start, open and run the command on cmd

            process.WaitForExit();
        }

        private void ffmpeg_handler(string received_ip, int check)//handeling the screen sharing
        {

            Process cmd = new Process();//open a new process
            cmd.StartInfo.FileName = "C:\\Users\\Danielle\\Desktop\\ffmpeg\\ffmpeg-20180319-e5b4cd4-win64-static\\bin\\";//set open cmd
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = true;//set the cmd be hidden
            if (check == 1)
            {
                cmd.StartInfo.FileName += "ffplay.exe";
                string command = "-f mpegts udp://";//server
                string ip = received_ip;
                string port = ":4000";

                cmd.StartInfo.Arguments = command + ip + port;
            }
            else
            {
                cmd.StartInfo.FileName += "ffmpeg.exe";

                string command = "-f gdigrab -i desktop -f mpegts udp:";//client
                string ip = IP.Text;
                string port = ":4000";

                cmd.StartInfo.Arguments = command + ip + port;

            }
            cmd.Start();



           
            cmd.WaitForExit();

        }
        private void open_command_line()
        {


        }
        private void PartnerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void allowconnection_Click(object sender, EventArgs e)//allowing other computer to connect yours
        {
            if (IP.Text != "")
            {
                Dictionary<string, string> data = new Dictionary<string, string>()
                {
                    {"username", myID.Text }
                };
                HttpHandler handler = new HttpHandler("http://" + SERVER_IP + "/allowConnection/");//sending http request to allow the connection
                string getting = handler.Post(data).Result;
                Thread cpp = new Thread(() => cpp_handler("not important", 2));//open the ability to control the mouse and keyboard events 
                /*the cpp_handler function is handeling the connection and the allowing conection cases. is case of a connection, the function is gtting the ip of the user
                he is connecting to, that is why the function id getting a string.
                if handeling allowness, no need of a string and that is why sending a not important string*/
                cpp.Start();

                Thread ffmpeg = new Thread(() => ffmpeg_handler(IP.Text, 0));//handeling scren sharing
                ffmpeg.Start();
            }

        }

        private void logout_Click(object sender, EventArgs e)//logout function
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

        private void PartnerPsw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}