using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class firstPage : Form
    {
        public firstPage()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            register registerForm = new register();
            registerForm.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            login log_in = new login();
            log_in.Show();
            this.Hide();
        }
    }
}
