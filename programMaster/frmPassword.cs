using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programMaster
{
    public partial class frmPassword : Form
    {
        public int _prog_num { get; set; }
        public string _path { get; set; }
        public frmPassword(int prog_num,string path)
        {
            InitializeComponent();
            _prog_num = prog_num;
            _path = path;

          

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEnter.PerformClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "m1lkman" || CONNECT.master_user == -1)
            {
                if (_prog_num == -1)
                {
                    var frm = new frmAdmin();
                    frm.Closed += (s, args) => this.Close();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    Process.Start(_path);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid passowrd", "Please try again...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void frmPassword_Shown(object sender, EventArgs e)
        {
            if (CONNECT.master_user == -1)
                btnEnter.PerformClick();
        }
    }
}
