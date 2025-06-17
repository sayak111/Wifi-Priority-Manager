using System.Data;
using System.Diagnostics;

namespace WifiPriorityManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listBoxProfiles.AllowDrop = true;
            listBoxProfiles.MouseDown += ListBoxProfiles_MouseDown;
            listBoxProfiles.DragOver += ListBoxProfiles_DragOver;
            listBoxProfiles.DragDrop += ListBoxProfiles_DragDrop;

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


        private void ListBoxProfiles_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listBoxProfiles.IndexFromPoint(e.X, e.Y);
            if (index >= 0)
            {
                listBoxProfiles.DoDragDrop(listBoxProfiles.Items[index], DragDropEffects.Move);
            }
        }

        private void ListBoxProfiles_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ListBoxProfiles_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxProfiles.PointToClient(new Point(e.X, e.Y));
            int index = listBoxProfiles.IndexFromPoint(point);

            if (index < 0) index = listBoxProfiles.Items.Count - 1;

            object data = e.Data.GetData(typeof(string));
            listBoxProfiles.Items.Remove(data);
            listBoxProfiles.Items.Insert(index, data);
        }

        private void btnSavePreset_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files|*.txt";
            sfd.Title = "Save Wi-Fi Priority Preset";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(sfd.FileName, listBoxProfiles.Items.Cast<string>());
                MessageBox.Show("Preset saved.");
            }
        }

        private void btnLoadPreset_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.Title = "Load Wi-Fi Priority Preset";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var profiles = File.ReadAllLines(ofd.FileName);
                listBoxProfiles.Items.Clear();
                foreach (var profile in profiles)
                {
                    listBoxProfiles.Items.Add(profile);
                }
                MessageBox.Show("Preset loaded.");
            }
        }

    }
}
