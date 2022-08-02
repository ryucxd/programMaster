using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace programMaster
{
    public partial class frmMain : Form
    {
        public string version { get; set; }
        public frmMain()
        {
            InitializeComponent();
            this.ShowIcon = false;
            this.Text = "Program Menu - Logged in As: " + CONNECT.staffName;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        private void btnDoorOrder_Click(object sender, EventArgs e)
        {
            string app_name = "Order System";
            string path = @"C:\DesignAndSupply_Programs\Order_Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Order Database 3.0\stable\";
            string sql = "select version from dbo.prog_version_numbers where program = 'door_order';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //non dialog messagebox - creates it on a seperate thread and then exits when the user hits ok - probably
            new Thread(new ThreadStart(delegate
            {
                MessageBox.Show
                (
                  "Please wait while the newest version of " + app_name + " downloads",
                  "Downloading...",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning
                );
            })).Start();
            /////////////////////////////////////
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnComplaint_Click(object sender, EventArgs e)
        {
            string app_name = "Complaint_Program";
            string path = @"C:\DesignAndSupply_Programs\Complaint_Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Complaint_Program\";
            string sql = "select version from dbo.prog_version_numbers where program = 'complaint_program';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Please wait while the newest version of " + app_name + " downloads", "Downloading...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnFitting_Click(object sender, EventArgs e)
        {
            string app_name = "Fitting_Program";
            string path = @"C:\DesignAndSupply_Programs\Fitting_Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Fitting_Program\";
            string sql = "select version from dbo.prog_version_numbers where program = 'fitting_program';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Please wait while the newest version of " + app_name + " downloads", "Downloading...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnPriceLog_Click(object sender, EventArgs e)
        {
            string app_name = "Price_Log_Program";
            string path = @"C:\DesignAndSupply_Programs\Price_Log_Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Price_Log_Program\";
            string sql = "select version from dbo.prog_version_numbers where program = 'price_log_program';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Please wait while the newest version of " + app_name + " downloads", "Downloading...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            string app_name = "Slimline_CE_Program";
            string path = @"C:\DesignAndSupply_Programs\Slimline_CE_Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Slimline_CE_Program\";
            string sql = "select version from dbo.prog_version_numbers where program = 'slimline_ce_program';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Please wait while the newest version of " + app_name + " downloads", "Downloading...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnEnquiryLog_Click(object sender, EventArgs e)
        {
            var excelProcesses = Process.GetProcessesByName("enquiryMaster");
            foreach (var process in excelProcesses)
            {
                    process.Kill();
            }
            string server_path = @"\\designsvr1\apps\Design and Supply CSharp\MiniApps\enquiryMaster\enquiryMaster.application";
            Process.Start(server_path);
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            var excelProcesses = Process.GetProcessesByName("InstallCalculator");
            foreach (var process in excelProcesses)
            {
                process.Kill();
            }
            string server_path = @"\\designsvr1\apps\Design and Supply CSharp\MiniApps\InstallationCalculator\InstallCalculator.application";
            Process.Start(server_path);
        }

        private void btnPowerPlanner_Click(object sender, EventArgs e)
        {
            var excelProcesses = Process.GetProcessesByName("PowerPlanner");
            foreach (var process in excelProcesses)
            {
                process.Kill();
            }
            string server_path = @"\\designsvr1\apps\Design and Supply CSharp\MiniApps\PowerPlanner\PowerPlanner.application";
            Process.Start(server_path);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmPassword frm = new frmPassword(-1,"");
            frm.ShowDialog();
        }

        private void btnBatching_Click(object sender, EventArgs e)
        {
            string app_name = "Batching Program";
            string path = @"C:\DesignAndSupply_Programs\Batching Program\";
            string server_path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Batching Program\";
            string sql = "select version from dbo.prog_version_numbers where program = 'batch_program';";
            //get the latest prog number 
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                    version = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
            string full_local_path = path + app_name + version;

            //check if the directory exists 
            DirectoryInfo di = Directory.CreateDirectory(path);
            //if the access file already exists in here we need to remove it
            try
            {
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
            }
            catch
            {
                MessageBox.Show("Unable to download new version - Please check that you do not already have the " + app_name + " open.", "Unable to download " + app_name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Please wait while the newest version of " + app_name + " downloads", "Downloading...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //download the new version from the server
            File.Copy(server_path + app_name + version, full_local_path);
            Process.Start(full_local_path);
        }

        private void btnBatchFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Batching Program";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }

        private void btnDoorOrderFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Order Database 3.0\stable";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }

        private void btnFittingFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Fitting_Program";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }

        private void btnComplaintFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Complaint_Program";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }

        private void btnPriceLogFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Price_Log_Program";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }

        private void btnCEFolder_Click(object sender, EventArgs e)
        {
            string path = @"\\designsvr1\apps\Design and Supply MS ACCESS\Frontend\Slimline_CE_Program";
            frmPassword frm = new frmPassword(0, path);
            frm.ShowDialog();
        }
    }
}
