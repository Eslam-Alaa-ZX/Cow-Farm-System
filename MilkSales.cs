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
    public partial class MilkSales : Form
    {
        Functions Con;
        int key = 0;
        public MilkSales()
        {
            InitializeComponent();
            Con = new Functions();
            getEmpId();
            showSales();
        }

        private void getEmpId()
        {
            string Query = "Select EmpId from EmpTbl";
            EID.ValueMember = "EmpId";
            EID.DataSource = Con.GetData(Query);
        }

        private void showSales()
        {
            String Query = "Select * from MilkSalesTbl";
            SList.DataSource = Con.GetData(Query);
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

        private void Clear()
        {
            SDate.Value = DateTime.Today.Date;
            SCName.Text = "";
            SCPhone.Text = "";
            SPrice.Text = "";
            SQuantity.Text = "";
            STotal.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SCName.Text == "" || EID.SelectedIndex == -1 || SPrice.Text == "" || SQuantity.Text == "" || STotal.Text == "" || SCPhone.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into MilkSalesTbl values('" + SDate.Value.Date.ToShortDateString() + "'," + Convert.ToInt32(SPrice.Text) + ",'" + SCName.Text + "','" + SCPhone.Text + "'," + Convert.ToInt32(EID.SelectedValue.ToString()) + "," + Convert.ToInt32(SQuantity.Text) + ", " + Convert.ToInt32(STotal.Text) + ")";
                    Con.SetData(Query);
                    showSales();
                    Clear();
                    MessageBox.Show("Sales Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SQuantity_Leave(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(SPrice.Text) * Convert.ToInt32(SQuantity.Text);
            STotal.Text = total.ToString();
        }

        private void SList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
