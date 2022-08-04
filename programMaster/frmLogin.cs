using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace programMaster
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //create session file here 

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check user/pass combo
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                string sql = "SELECT forename + ' ' + surname FROM dbo.[user] where username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var data = cmd.ExecuteScalar();
                    if (data != null)
                    {
                        CONNECT.staffName = Convert.ToString(data);
                        if (CONNECT.staffName == "Corey Jones" || CONNECT.staffName == "Tomas Grother")
                            CONNECT.master_user = -1;
                        else
                            CONNECT.master_user = 0;
                        
                        //we also need to write this shit into the session file
                        sessionFile();
                        this.Hide();
                        var frm = new frmMain();
                        frm.Closed += (s, args) => this.Close(); //hides login form and on the close of the main form it will also close the login form
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username/Password.", "Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }
                }
                conn.Close();
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();

        }

        private void sessionFile()
        {
            //all the excel stuffs here

            // Store the Excel processes before opening.
            Process[] processesBefore = Process.GetProcessesByName("excel");
            // Open the file in Excel.
            string temp = @"C:\DesignAndSupply_Programs\Session\user_session.csv";
            var xlApp = new Excel.Application();
            var xlWorkbooks = xlApp.Workbooks;
            var xlWorkbook = xlWorkbooks.Open(temp);
            var xlWorksheet = xlWorkbook.Sheets[1]; // assume it is the first sheet

            // Get Excel processes after opening the file.
            Process[] processesAfter = Process.GetProcessesByName("excel");

            xlWorksheet.Cells[2, 1].Value2 = txtUsername.Text; // username
            xlWorksheet.Cells[2, 2].Value2 = txtPassword.Text; // password
            xlApp.DisplayAlerts = false;
            xlWorkbook.SaveAs(temp, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,Type.Missing, Type.Missing);
            xlApp.DisplayAlerts = true;
            xlWorkbook.Close(true); //close the excel sheet
            // xlApp.Quit();


            // Manual disposal because of COM
            xlApp.Quit();

            // Now find the process id that was created, and store it.
            int processID = 0;
            foreach (Process process in processesAfter)
            {
                if (!processesBefore.Select(p => p.Id).Contains(process.Id))
                {
                    processID = process.Id;
                }
            }

            // And now kill the process.
            if (processID != 0)
            {
                Process process = Process.GetProcessById(processID);
                process.Kill();
            }
        }
    }
}
