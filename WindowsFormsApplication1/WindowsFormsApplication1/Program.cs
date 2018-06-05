using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new firstPage());
        }
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                //Console.WriteLine("Console window closing, death imminent");
                HttpHandler handler = new HttpHandler("http://localHost:3000/disconnect/");
               
                string taskResult = handler.Post(null).Result;
            }
            return false;
        }
        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }
   // class MyDataGrid : System.Windows.Forms.DataGrid
   // {
   //
   //     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
   //     {
   //         const int WM_KEYDOWN = 0x100;
   //         const int WM_SYSKEYDOWN = 0x104;
   //
   //         if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
   //         {
   //             switch (keyData)
   //             {
   //                 case Keys.Down:
   //                     this.Parent.Text = "Down Arrow Captured";
   //                     break;
   //
   //                 case Keys.Up:
   //                     this.Parent.Text = "Up Arrow Captured";
   //                     break;
   //
   //                 case Keys.Tab:
   //                     this.Parent.Text = "Tab Key Captured";
   //                     break;
   //
   //                 case Keys.Control | Keys.M:
   //                     this.Parent.Text = "<CTRL> + M Captured";
   //                     break;
   //
   //                 case Keys.Alt | Keys.Z:
   //                     this.Parent.Text = "<ALT> + Z Captured";
   //                     break;
   //             }
   //         }
   //
   //         return base.ProcessCmdKey(ref msg, keyData);
   //     }
   // }
}
