﻿using System;
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
    public partial class Employees : Form
    {
        Functions Con;
        int key = 0;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            getCowId();
            showHealth();
        }

        private void showHealth()
        {
            String Query = "Select * from HealthTbl";
            EList.DataSource = Con.GetData(Query);
        }

        private void getCowId()
        {
            string Query = "Select CowId from CowTbl";
            EGen.ValueMember = "CowId";
            EGen.DataSource = Con.GetData(Query);
        }

        private void getCowName()
        {
            string Query = "Select * from CowTbl where CowId=" + EGen.SelectedValue + "";
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                EName.Text = dr["CowName"].ToString();
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
            Employees page = new CowHealth();
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
            EDate.Value = DateTime.Today.Date;
            EName.Text = "";
            EPass.Text = "";
            HEvent.Text = "";
            EPhon.Text = "";
            HDiag.Text = "";
            EAdd.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EName.Text == "" || EGen.SelectedIndex == -1 || HEvent.Text == "" || HDiag.Text == "" || EPhon.Text == "" || EAdd.Text == "" || EPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "insert into HealthTbl values('" + EGen.SelectedValue.ToString() + "','" + EName.Text + "','" + EDate.Value.Date.ToShortDateString() + "','" + HEvent.Text + "','" + HDiag.Text + "','" + EPhon.Text + "', " + EAdd.Text + ", '" + EPass.Text + "')";
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
            EGen.SelectedValue = EList.SelectedRows[0].Cells[1].Value.ToString();
            EName.Text = EList.SelectedRows[0].Cells[2].Value.ToString();
            EDate.Text = EList.SelectedRows[0].Cells[3].Value.ToString();
            HEvent.Text = EList.SelectedRows[0].Cells[4].Value.ToString();
            HDiag.Text = EList.SelectedRows[0].Cells[5].Value.ToString();
            EPhon.Text = EList.SelectedRows[0].Cells[6].Value.ToString();
            EAdd.Text = EList.SelectedRows[0].Cells[7].Value.ToString();
            EPass.Text = EList.SelectedRows[0].Cells[8].Value.ToString();
            if (EName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EName.Text == "" || EGen.SelectedIndex == -1 || HEvent.Text == "" || HDiag.Text == "" || EPhon.Text == "" || EAdd.Text == "" || EPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    String Query = "update HealthTbl set CowId='" + EGen.SelectedValue.ToString() + "',CowName= '" + EName.Text + "',RepDate='" + EDate.Value.Date.ToShortDateString() + "',Event='" + HEvent.Text + "',Diagnosis='" + HDiag.Text + "',Treatment='" + EPhon.Text + "',Cost=" + EAdd.Text + ",VetName='" + EPass.Text + "' where RepId=" + key + " ";
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
