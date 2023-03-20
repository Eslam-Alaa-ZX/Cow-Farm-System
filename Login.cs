using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cow_Farm_System
{
    public partial class Login : Form
    {
        Functions Con;
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            Password.Text = "";
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            if (Role.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Role");
            }
            else if (UserName.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Enter username and password");
            }
            else
            {
                if(Role.SelectedItem.ToString() == "Admin")
                {
                    Employees page = new Employees();
                    page.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin name or Password");
                }
                if(Role.SelectedItem.ToString() == "Employee")
                {

                }
            }
        }
    }
}
