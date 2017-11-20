namespace WindowsFormsApp1
    {
    partial class SettingsForm
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
            this.alwaysOnTopChkBox = new System.Windows.Forms.CheckBox();
            this.confirmDialogChkBox = new System.Windows.Forms.CheckBox();
            this.darkModeChkBox = new System.Windows.Forms.CheckBox();
            this.defaultBtn = new System.Windows.Forms.Button();
            this.finishBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // alwaysOnTopChkBox
            // 
            this.alwaysOnTopChkBox.AutoSize = true;
            this.alwaysOnTopChkBox.Location = new System.Drawing.Point(12, 12);
            this.alwaysOnTopChkBox.Name = "alwaysOnTopChkBox";
            this.alwaysOnTopChkBox.Size = new System.Drawing.Size(98, 17);
            this.alwaysOnTopChkBox.TabIndex = 0;
            this.alwaysOnTopChkBox.Text = "Always On Top";
            this.alwaysOnTopChkBox.UseVisualStyleBackColor = true;
            // 
            // confirmDialogChkBox
            // 
            this.confirmDialogChkBox.AutoSize = true;
            this.confirmDialogChkBox.Location = new System.Drawing.Point(13, 36);
            this.confirmDialogChkBox.Name = "confirmDialogChkBox";
            this.confirmDialogChkBox.Size = new System.Drawing.Size(152, 17);
            this.confirmDialogChkBox.TabIndex = 1;
            this.confirmDialogChkBox.Text = "Confirm on Finish or Delete";
            this.confirmDialogChkBox.UseVisualStyleBackColor = true;
            // 
            // darkModeChkBox
            // 
            this.darkModeChkBox.AutoSize = true;
            this.darkModeChkBox.Location = new System.Drawing.Point(13, 60);
            this.darkModeChkBox.Name = "darkModeChkBox";
            this.darkModeChkBox.Size = new System.Drawing.Size(79, 17);
            this.darkModeChkBox.TabIndex = 2;
            this.darkModeChkBox.Text = "Dark Mode";
            this.darkModeChkBox.UseVisualStyleBackColor = true;
            // 
            // defaultBtn
            // 
            this.defaultBtn.Location = new System.Drawing.Point(12, 94);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(75, 23);
            this.defaultBtn.TabIndex = 3;
            this.defaultBtn.Text = "&Defaults";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(94, 94);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(75, 23);
            this.finishBtn.TabIndex = 4;
            this.finishBtn.Text = "&Finish";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(184, 129);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.defaultBtn);
            this.Controls.Add(this.darkModeChkBox);
            this.Controls.Add(this.confirmDialogChkBox);
            this.Controls.Add(this.alwaysOnTopChkBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.CheckBox alwaysOnTopChkBox;
        private System.Windows.Forms.CheckBox confirmDialogChkBox;
        private System.Windows.Forms.CheckBox darkModeChkBox;
        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.Button finishBtn;
        }
    }