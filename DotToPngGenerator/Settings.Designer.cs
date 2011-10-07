namespace DotToPngGenerator
{
    partial class Settings
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
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabControl();
            this.generalSettingsTab = new System.Windows.Forms.TabPage();
            this.externalViewerCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dotFileNameTextBox = new System.Windows.Forms.TextBox();
            this.browse_dotFile_button = new System.Windows.Forms.Button();
            this.btRestoreDefaults = new System.Windows.Forms.Button();
            this.SettingsTab.SuspendLayout();
            this.generalSettingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(257, 334);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(347, 334);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 0;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.generalSettingsTab);
            this.SettingsTab.Location = new System.Drawing.Point(12, 12);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.SelectedIndex = 0;
            this.SettingsTab.Size = new System.Drawing.Size(403, 307);
            this.SettingsTab.TabIndex = 2;
            // 
            // generalSettingsTab
            // 
            this.generalSettingsTab.Controls.Add(this.btRestoreDefaults);
            this.generalSettingsTab.Controls.Add(this.externalViewerCheckBox);
            this.generalSettingsTab.Controls.Add(this.label1);
            this.generalSettingsTab.Controls.Add(this.dotFileNameTextBox);
            this.generalSettingsTab.Controls.Add(this.browse_dotFile_button);
            this.generalSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.generalSettingsTab.Name = "generalSettingsTab";
            this.generalSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalSettingsTab.Size = new System.Drawing.Size(395, 281);
            this.generalSettingsTab.TabIndex = 0;
            this.generalSettingsTab.Text = "General";
            this.generalSettingsTab.UseVisualStyleBackColor = true;
            // 
            // externalViewerCheckBox
            // 
            this.externalViewerCheckBox.AutoSize = true;
            this.externalViewerCheckBox.Location = new System.Drawing.Point(6, 53);
            this.externalViewerCheckBox.Name = "externalViewerCheckBox";
            this.externalViewerCheckBox.Size = new System.Drawing.Size(300, 17);
            this.externalViewerCheckBox.TabIndex = 5;
            this.externalViewerCheckBox.Text = "Show in External Image Viewer (Default OS Image Viewer)";
            this.externalViewerCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dot Generator Location";
            // 
            // dotFileNameTextBox
            // 
            this.dotFileNameTextBox.Location = new System.Drawing.Point(127, 17);
            this.dotFileNameTextBox.Name = "dotFileNameTextBox";
            this.dotFileNameTextBox.Size = new System.Drawing.Size(169, 20);
            this.dotFileNameTextBox.TabIndex = 3;
            // 
            // browse_dotFile_button
            // 
            this.browse_dotFile_button.Location = new System.Drawing.Point(302, 16);
            this.browse_dotFile_button.Name = "browse_dotFile_button";
            this.browse_dotFile_button.Size = new System.Drawing.Size(75, 23);
            this.browse_dotFile_button.TabIndex = 2;
            this.browse_dotFile_button.Text = "Browse";
            this.browse_dotFile_button.UseVisualStyleBackColor = true;
            this.browse_dotFile_button.Click += new System.EventHandler(this.browse_dotFile_button_Click);
            // 
            // btRestoreDefaults
            // 
            this.btRestoreDefaults.Location = new System.Drawing.Point(241, 252);
            this.btRestoreDefaults.Name = "btRestoreDefaults";
            this.btRestoreDefaults.Size = new System.Drawing.Size(148, 23);
            this.btRestoreDefaults.TabIndex = 6;
            this.btRestoreDefaults.Text = "Restore Defaults";
            this.btRestoreDefaults.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 369);
            this.Controls.Add(this.SettingsTab);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.SettingsTab.ResumeLayout(false);
            this.generalSettingsTab.ResumeLayout(false);
            this.generalSettingsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TabControl SettingsTab;
        private System.Windows.Forms.TabPage generalSettingsTab;
        private System.Windows.Forms.TextBox dotFileNameTextBox;
        private System.Windows.Forms.Button browse_dotFile_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox externalViewerCheckBox;
        private System.Windows.Forms.Button btRestoreDefaults;
    }
}