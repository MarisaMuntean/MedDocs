using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MedDocs
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string name = this.name.Text;
            string F_name = FName.Text;
            string email = Email.Text;
            string pass = Pass.Text;
            string Cpass = Check_Pass.Text;
            bool este_bifat = Doctor.Checked;

            if (pass != Cpass)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(F_name) || string.IsNullOrWhiteSpace(email)|| string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("evrey space must be completed.");
                return;
            }



        }
    }
}
