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
    public partial class Finance : Form
    {
        Functions Con;
        int key = 0;
        public Finance()
        {
            InitializeComponent();
            Con = new Functions();
            showExp();
            showInc();
            getEmpId();
        }

        private void getEmpId()
        {
            string Query = "Select EmpId from EmpTbl";
            EID.ValueMember = "EmpId";
            EID.DataSource = Con.GetData(Query);
        }

        private void showExp()
        {
            String Query = "Select * from ExpenditureTbl";
            FExList.DataSource = Con.GetData(Query);
        }

        private void showInc()
        {
            String Query = "Select * from IncomeTbl";
            FInList.DataSource = Con.GetData(Query);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void ClearExp()
        {
            FExDate.Value = DateTime.Today.Date;
            FExPorp.SelectedIndex = -1;
            FExAmo.Text = "";
            key = 0;
        }

        private void ClearInc()
        {
            FInDate.Value = DateTime.Today.Date;
            FInType.SelectedIndex = -1;
            FInAmo.Text = "";
            key = 0;
        }

        private void ExSave_Click(object sender, EventArgs e)
        {
            if (FExAmo.Text == "" || FExPorp.SelectedIndex == -1 || EID.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into ExpenditureTbl values('" + FExDate.Value.Date.ToShortDateString() + "','" + FExPorp.SelectedItem.ToString() + "','" + Convert.ToInt32(FExAmo.Text) + "'," + EID.SelectedValue + ")";
                    Con.SetData(Query);
                    showExp();
                    ClearExp();
                    MessageBox.Show("Expenditure Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InSave_Click(object sender, EventArgs e)
        {
            if (FInAmo.Text == "" || FInType.SelectedIndex == -1 || EID.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into IncomeTbl values('" + FInDate.Value.Date.ToShortDateString() + "','" + FInType.SelectedItem.ToString() + "','" + Convert.ToInt32(FInAmo.Text) + "'," + EID.SelectedValue + ")";
                    Con.SetData(Query);
                    showInc();
                    ClearInc();
                    MessageBox.Show("Income Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FilterExpenditure()
        {
            String Query = "Select * from ExpenditureTbl where ExpDate='" + FExFilter.Value.Date.ToShortDateString() + "'";
            FExList.DataSource = Con.GetData(Query);
        }

        private void Filterincome()
        {
            String Query = "Select * from IncomeTbl where IncDate='" + FInFilter.Value.Date.ToShortDateString() + "'";
            FInList.DataSource = Con.GetData(Query);
        }

        private void FExFilter_ValueChanged(object sender, EventArgs e)
        {
            FilterExpenditure();
        }

        private void FInFilter_ValueChanged(object sender, EventArgs e)
        {
            Filterincome();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ExRef_Click(object sender, EventArgs e)
        {
            showExp();
        }

        private void IncRef_Click(object sender, EventArgs e)
        {
            showInc();
        }
    }
}
