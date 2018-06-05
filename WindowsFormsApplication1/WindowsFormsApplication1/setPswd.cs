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
    public partial class setPswd : Form
    {
        Form _frm;

        public setPswd(Form frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void ConfirmBtm_Click(object sender, EventArgs e)
        {
        //    if(confirmPw.Text==NewPw.Text)
        //    {
        //        if(confirmPw.Text.Length<8)
        //        {
        //            MessageBox.Show("The passwords must contain at least 8 characters");
        //        }
        //        else
        //        {
        //            homePage m = new homePage();
        //            m.myPsw.Text = NewPw.Text;
        //
        //            m.Show();
        //            this.Hide();
        //
        //        }
        //        
        //    }
        //    else
        //    {
        //        MessageBox.Show("The passwords do not match");
        //
        //    }
        }

        private void cancelBtm_Click(object sender, EventArgs e)
        {
            homePage m = new homePage();

            m.Show();
            this.Hide();
        }
    }
}
