using System;
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
            //open registration form
            register registerForm = new register();
            registerForm.Show();
            this.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            //open login form
            login log_in = new login();//
            log_in.Show();
            this.Hide();
        }
    }
}
