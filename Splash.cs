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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        int startP = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            ProgBar.Value = startP;
            if(ProgBar.Value == 100)
            {
                ProgBar.Value = 0;
                timer1.Stop();
                Login page = new Login();
                this.Hide();
                page.Show();
            }
        }
    }
}
