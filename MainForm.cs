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

namespace WifiPriorityManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSetPriority_Click(object sender, EventArgs e)
        {
            if (listBoxProfiles.SelectedItem != null && int.TryParse(txtPriority.Text, out int priority))
            {
                string profile = listBoxProfiles.SelectedItem.ToString();
                string cmd = $"wlan set profileorder name=\"{profile}\" interface=\"Wi-Fi\" priority={priority}";
                RunNetshCommand(cmd);
                MessageBox.Show($"Priority set for '{profile}' to {priority}");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadWifiProfiles();
        }

        private void LoadWifiProfiles()
        {
            listBoxProfiles.Items.Clear();
            var process = new Process();
            process.StartInfo.FileName = "netsh";
            process.StartInfo.Arguments = "wlan show profiles";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            foreach (var line in output.Split('\n'))
            {
                if (line.Trim().StartsWith("All User Profile"))
                {
                    string profile = line.Split(':')[1].Trim();
                    listBoxProfiles.Items.Add(profile);
                }
            }
        }

        private void RunNetshCommand(string command)
        {
            var process = new Process();
            process.StartInfo.FileName = "netsh";
            process.StartInfo.Arguments = command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }

        private void txtPriority_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResetPriorities_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxProfiles.Items.Count; i++)
            {
                string profile = listBoxProfiles.Items[i].ToString();
                int priority = i + 1;

                string cmd = $"wlan set profileorder name=\"{profile}\" interface=\"Wi-Fi\" priority={priority}";
                RunNetshCommand(cmd);
            }

            MessageBox.Show("Priorities have been reset (1, 2, 3...)");
        }

    }
}
