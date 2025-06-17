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
            txtPriority = new TextBox();
            label1 = new Label();
            btnSetPriority = new Button();
            btnResetPriorities = new Button();
            SuspendLayout();
            // 
            // listBoxProfiles
            // 
            listBoxProfiles.FormattingEnabled = true;
            listBoxProfiles.ItemHeight = 15;
            listBoxProfiles.Location = new Point(240, 52);
            listBoxProfiles.Name = "listBoxProfiles";
            listBoxProfiles.Size = new Size(120, 94);
            listBoxProfiles.TabIndex = 0;
            // 
            // txtPriority
            // 
            txtPriority.Location = new Point(470, 94);
            txtPriority.Name = "txtPriority";
            txtPriority.Size = new Size(100, 23);
            txtPriority.TabIndex = 1;
            txtPriority.TextChanged += txtPriority_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 97);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 2;
            label1.Text = "Priority (1, 2, 3...):";
            // 
            // btnSetPriority
            // 
            btnSetPriority.Location = new Point(366, 123);
            btnSetPriority.Name = "btnSetPriority";
            btnSetPriority.Size = new Size(75, 23);
            btnSetPriority.TabIndex = 3;
            btnSetPriority.Text = "Set Priority";
            btnSetPriority.UseVisualStyleBackColor = true;
            btnSetPriority.Click += btnSetPriority_Click;
            // 
            // btnResetPriorities
            // 
            btnResetPriorities.Location = new Point(486, 123);
            btnResetPriorities.Name = "btnResetPriorities";
            btnResetPriorities.Size = new Size(75, 23);
            btnResetPriorities.TabIndex = 4;
            btnResetPriorities.Text = "Reset Priorities";
            btnResetPriorities.UseVisualStyleBackColor = true;
            btnResetPriorities.Click += btnResetPriorities_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnResetPriorities);
            Controls.Add(btnSetPriority);
            Controls.Add(label1);
            Controls.Add(txtPriority);
            Controls.Add(listBoxProfiles);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxProfiles;
        private TextBox txtPriority;
        private Label label1;
        private Button btnSetPriority;
        private Button btnResetPriorities;
    }
}