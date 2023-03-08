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
    public partial class CowBreeding : Form
    {
        Functions Con;
        int key = 0;
        public CowBreeding()
        {
            InitializeComponent();
            Con = new Functions();
            showBreading();
            getCowId();
        }

        private void showBreading()
        {
            String Query = "Select * from BreedTbl";
            BList.DataSource = Con.GetData(Query);
        }

        private void getCowId()
        {
            string Query = "Select CowId from CowTbl";
            BCowID.ValueMember = "CowId";
            BCowID.DataSource = Con.GetData(Query);
        }

        private void getCowName()
        {
            string Query = "Select * from CowTbl where CowId=" + BCowID.SelectedValue + "";
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                BCName.Text = dr["CowName"].ToString();
                BCAge.Text = dr["Age"].ToString();
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
            BHDate.Value = DateTime.Today.Date;
            BPregDate.Value = DateTime.Today.Date;
            BExCalve.Value = DateTime.Today.Date;
            BDCalved.Value = DateTime.Today.Date;
            BBDate.Value = DateTime.Today.Date;
            BCName.Text = "";
            BCAge.Text = "";
            BRemark.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BCowID.SelectedIndex == -1 || BCName.Text == "" || BCAge.Text == "" || BRemark.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    String Query = "insert into BreedTbl values('" + BHDate.Value.Date.ToShortDateString() + "','" + BBDate.Value.Date.ToShortDateString() + "'," + Convert.ToInt32(BCowID.SelectedValue.ToString()) + ",'" + BCName.Text + "','" + BPregDate.Value.Date.ToShortDateString() + "','" + BExCalve.Value.Date.ToShortDateString() + "', '" + BDCalved.Value.Date.ToShortDateString() + "', " + Convert.ToInt32(BCAge.Text) + ", '" + BRemark.Text + "')";
                    Con.SetData(Query);
                    showBreading();
                    Clear();
                    MessageBox.Show("Breading Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BCowID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getCowName();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BCowID.SelectedIndex == -1 || BCName.Text == "" || BCAge.Text == "" || BRemark.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
        }
    }
}
