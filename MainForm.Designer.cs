namespace WifiPriorityManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxProfiles = new ListBox();
            btnResetPriorities = new Button();
            btnSavePreset = new Button();
            btnLoadPreset = new Button();
            SuspendLayout();
            // 
            // listBoxProfiles
            // 
            listBoxProfiles.FormattingEnabled = true;
            listBoxProfiles.ItemHeight = 15;
            listBoxProfiles.Location = new Point(223, 1);
            listBoxProfiles.Name = "listBoxProfiles";
            listBoxProfiles.Size = new Size(167, 154);
            listBoxProfiles.TabIndex = 0;
            listBoxProfiles.SelectedIndexChanged += listBoxProfiles_SelectedIndexChanged;
            // 
            // btnResetPriorities
            // 
            btnResetPriorities.Location = new Point(260, 190);
            btnResetPriorities.Name = "btnResetPriorities";
            btnResetPriorities.Size = new Size(75, 23);
            btnResetPriorities.TabIndex = 4;
            btnResetPriorities.Text = "Reset Priorities";
            btnResetPriorities.UseVisualStyleBackColor = true;
            btnResetPriorities.Click += btnResetPriorities_Click;
            // 
            // btnSavePreset
            // 
            btnSavePreset.Location = new Point(223, 161);
            btnSavePreset.Name = "btnSavePreset";
            btnSavePreset.Size = new Size(75, 23);
            btnSavePreset.TabIndex = 5;
            btnSavePreset.Text = "Save Preset";
            btnSavePreset.UseVisualStyleBackColor = true;
            btnSavePreset.Click += btnSavePreset_Click;
            // 
            // btnLoadPreset
            // 
            btnLoadPreset.Location = new Point(304, 161);
            btnLoadPreset.Name = "btnLoadPreset";
            btnLoadPreset.Size = new Size(86, 23);
            btnLoadPreset.TabIndex = 6;
            btnLoadPreset.Text = "Load Preset";
            btnLoadPreset.UseVisualStyleBackColor = true;
            btnLoadPreset.Click += btnLoadPreset_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLoadPreset);
            Controls.Add(btnSavePreset);
            Controls.Add(btnResetPriorities);
            Controls.Add(listBoxProfiles);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxProfiles;
        private Button btnResetPriorities;
        private Button btnSavePreset;
        private Button btnLoadPreset;
    }
}