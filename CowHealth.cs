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
    public partial class CowHealth : Form
    {
        Functions Con;
        int key = 0;
        public CowHealth()
        {
            InitializeComponent();
            Con = new Functions();
            getCowId();
        }

        private void getCowId()
        {
            string Query = "Select CowId from CowTbl";
            CID.ValueMember = "CowId";
            CID.DataSource = Con.GetData(Query);
        }

        private void getCowName()
        {
            string Query = "Select * from CowTbl where CowId=" + CID.SelectedValue + "";
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                CName.Text = dr["CowName"].ToString();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashboardPg_Click(object sender, EventArgs e)
        {
            DashBoard page = new DashBoard();
            page.Show();
            this.Hide();
        }

        private void FinancePg_Click(object sender, EventArgs e)
        {
            Finance page = new Finance();
            page.Show();
            this.Hide();
        }

        private void SalesPg_Click(object sender, EventArgs e)
        {
            MilkSales page = new MilkSales();
            page.Show();
            this.Hide();
        }

        private void BreadingPg_Click(object sender, EventArgs e)
        {
            CowBreeding page = new CowBreeding();
            page.Show();
            this.Hide();
        }

        private void HealthPg_Click(object sender, EventArgs e)
        {
            CowHealth page = new CowHealth();
            page.Show();
            this.Hide();
        }

        private void MilkPg_Click(object sender, EventArgs e)
        {
            MilkProduction page = new MilkProduction();
            page.Show();
            this.Hide();
        }

        private void CowsPg_Click(object sender, EventArgs e)
        {
            Cows page = new Cows();
            page.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
