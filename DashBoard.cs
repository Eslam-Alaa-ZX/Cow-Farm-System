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
    public partial class DashBoard : Form
    {
        Functions Con;
        int key = 0;
        public DashBoard()
        {
            InitializeComponent();
            Con = new Functions();
            FinanceCalc();
            LogistecCalc();
            getMax();
        }

        private void FinanceCalc()
        {
            int inc, exp;
            double bal;
            String Query = "Select sum(IncAmount) from IncomeTbl";
            inc = Convert.ToInt32(Con.GetData(Query).Rows[0][0]);
            FInc.Text = "$ "+inc.ToString();

            String Query2 = "Select sum(ExpAmount) from ExpenditureTbl";
            exp = Convert.ToInt32(Con.GetData(Query2).Rows[0][0]);
            FExp.Text = "$ " + exp.ToString();

            bal = inc - exp;
            FBal.Text = "$ " + bal;
        }

        private void LogistecCalc()
        {
            String Query = "Select count(*) from CowTbl";
            LCow.Text = Con.GetData(Query).Rows[0][0].ToString();

            String Query2 = "Select sum(TotalMilk) from MilkTbl";
            LMilk.Text = Con.GetData(Query2).Rows[0][0].ToString()+" Litters";

            String Query3 = "Select count(*) from EmpTbl";
            LEmp.Text = Con.GetData(Query3).Rows[0][0].ToString();
        }

        private void getMax()
        {
            String Query = "Select Max(IncAmount) from IncomeTbl";
            SMax.Text = "$ " + Con.GetData(Query).Rows[0][0].ToString();

            String Query2 = "Select Max(ExpAmount) from ExpenditureTbl";
            ExpMax.Text = "$ " + Con.GetData(Query2).Rows[0][0].ToString();
        }

        private void label18_Click(object sender, EventArgs e)
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
