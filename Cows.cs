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
    public partial class Cows : Form
    {
        Functions Con;
        int key = 0;
        int age = 0;
        public Cows()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCows();
        }

        private void ShowCows()
        {
            String Query = "Select * from CowTbl";
            CowGV.DataSource = Con.GetData(Query);
        }

        private void SearchCow()
        {
            String Query = "Select * from CowTbl where CowName like '%"+CFilter.Text+"%'";
            CowGV.DataSource = Con.GetData(Query);
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
            age = 0;
            CDOB.Value = DateTime.Today.Date;
            CName.Text = "";
            CTag.Text = "";
            CColor.Text = "";
            CBread.Text = "";
            CAge.Text = age.ToString();
            CWAB.Text = "";
            CPasture.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CTag.Text == "" || CColor.Text == "" || CBread.Text == "" || CAge.Text == "" || CWAB.Text == "" || CPasture.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into CowTbl values('"+ CName.Text + "','" + CTag.Text + "','" + CColor.Text + "','" + CBread.Text + "',"+age+ "," + Convert.ToInt32(CWAB.Text) + ",'" + CPasture.Text + "')";
                    Con.SetData(Query);
                    ShowCows();
                    Clear();
                    MessageBox.Show("Cow Added!!!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CDOB_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date- CDOB.Value.Date).Days)/365;
            CAge.Text = age.ToString();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CowGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CName.Text = CowGV.SelectedRows[0].Cells[1].Value.ToString();
            CTag.Text = CowGV.SelectedRows[0].Cells[2].Value.ToString();
            CColor.Text = CowGV.SelectedRows[0].Cells[3].Value.ToString();
            CBread.Text = CowGV.SelectedRows[0].Cells[4].Value.ToString();
            CAge.Text = CowGV.SelectedRows[0].Cells[5].Value.ToString();
            CWAB.Text = CowGV.SelectedRows[0].Cells[6].Value.ToString();
            CPasture.Text = CowGV.SelectedRows[0].Cells[7].Value.ToString();
            //age = Convert.ToInt32(CAge.Text);
            if (CName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CowGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Please Sellect a Cow!!!");
            }
            else
            {
                try
                {
                    String Query = "Delete from CowTbl where CowId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowCows();
                    Clear();
                    MessageBox.Show("Cow Deleted!!!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CTag.Text == "" || CColor.Text == "" || CBread.Text == "" || CAge.Text == "" || CWAB.Text == "" || CPasture.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "Update CowTbl set CowName = '" + CName.Text + "',EarTag = '" + CTag.Text + "',Color = '" + CColor.Text + "',Breed = '" + CBread.Text + "',Age = " + age + ",WeigtAtBirth = " + Convert.ToInt32(CWAB.Text) + ",Pasture = '" + CPasture.Text + "'  where CowId = " + key + "";
                    Con.SetData(Query);
                    ShowCows();
                    Clear();
                    MessageBox.Show("Cow Edited!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CFilter_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
