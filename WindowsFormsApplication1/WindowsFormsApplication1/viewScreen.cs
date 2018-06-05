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
    public partial class viewScreen : Form
    {
        public viewScreen()
        {
            InitializeComponent();
        }

        private void endCnnctBtn_Click(object sender, EventArgs e)
        {
            //call end connection function in cpp
            homePage m = new homePage();
            
            m.Show();
            this.Hide();
        }

        private void viewCnnctDetailsBtn_Click(object sender, EventArgs e)
        {
            connectionDetails m = new connectionDetails();

            m.Show();
            this.Hide();
        }
    }
}
