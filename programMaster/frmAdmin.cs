﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace programMaster
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            string sql = "select Program,Version from dbo.prog_version_numbers";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();

                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "select program,version from dbo.prog_version_numbers";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sql = "UPDATE dbo.prog_version_numbers SET [version] = '" + row.Cells[1].Value.ToString() + "' WHERE program = '" + row.Cells[0].Value.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            this.Close();

        }
    }
}
