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
            showHealth();
        }

        private void showHealth()
        {
            String Query = "Select * from HealthTbl";
            HList.DataSource = Con.GetData(Query);
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

        private void Clear()
        {
            HDDate.Value = DateTime.Today.Date;
            CName.Text = "";
            HVName.Text = "";
            HEvent.Text = "";
            HTreat.Text = "";
            HDiag.Text = "";
            HCOT.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CID.SelectedIndex == -1 || HEvent.Text == "" || HDiag.Text == "" || HTreat.Text == "" || HCOT.Text == "" || HVName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into HealthTbl values('" + CID.SelectedValue.ToString() + "','" + CName.Text + "','" + HDDate.Value.Date.ToShortDateString() + "','" + HEvent.Text + "','" + HDiag.Text + "','" + HTreat.Text + "', " + HCOT.Text + ", '" + HVName.Text + "')";
                    Con.SetData(Query);
                    showHealth();
                    Clear();
                    MessageBox.Show("Health Report Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void CID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getCowName();
        }

        private void HList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CID.SelectedValue = HList.SelectedRows[0].Cells[1].Value.ToString();
            CName.Text = HList.SelectedRows[0].Cells[2].Value.ToString();
            HDDate.Text = HList.SelectedRows[0].Cells[3].Value.ToString();
            HEvent.Text = HList.SelectedRows[0].Cells[4].Value.ToString();
            HDiag.Text = HList.SelectedRows[0].Cells[5].Value.ToString();
            HTreat.Text = HList.SelectedRows[0].Cells[6].Value.ToString();
            HCOT.Text = HList.SelectedRows[0].Cells[7].Value.ToString();
            HVName.Text = HList.SelectedRows[0].Cells[8].Value.ToString();
            if (CName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CID.SelectedIndex == -1 || HEvent.Text == "" || HDiag.Text == "" || HTreat.Text == "" || HCOT.Text == "" || HVName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "update HealthTbl set CowId='" + CID.SelectedValue.ToString() + "',CowName= '" + CName.Text + "',RepDate='" + HDDate.Value.Date.ToShortDateString() + "',Event='" + HEvent.Text + "',Diagnosis='" + HDiag.Text + "',Treatment='" + HTreat.Text + "',Cost=" + HCOT.Text + ",VetName='" + HVName.Text + "' where RepId=" + key + " ";
                    Con.SetData(Query);
                    showHealth();
                    Clear();
                    MessageBox.Show("Health Report Edited!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Sellect a Health Report!!!");
            }
            else
            {
                try
                {
                    String Query = "Delete from HealthTbl where RepId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    showHealth();
                    Clear();
                    MessageBox.Show("Health Report Deleted!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
