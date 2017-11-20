namespace WindowsFormsApp1
{
    partial class QueueForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.createCardBtn = new System.Windows.Forms.Button();
            this.showQueueBtn = new System.Windows.Forms.Button();
            this.listContainers = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createCardBtn
            // 
            this.createCardBtn.Location = new System.Drawing.Point(12, 824);
            this.createCardBtn.Name = "createCardBtn";
            this.createCardBtn.Size = new System.Drawing.Size(110, 25);
            this.createCardBtn.TabIndex = 0;
            this.createCardBtn.Text = "Create Commission";
            this.createCardBtn.UseVisualStyleBackColor = true;
            // 
            // showQueueBtn
            // 
            this.showQueueBtn.Location = new System.Drawing.Point(262, 824);
            this.showQueueBtn.Name = "showQueueBtn";
            this.showQueueBtn.Size = new System.Drawing.Size(110, 25);
            this.showQueueBtn.TabIndex = 1;
            this.showQueueBtn.Text = "Show All Queues";
            this.showQueueBtn.UseVisualStyleBackColor = true;
            this.showQueueBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // listContainers
            // 
            this.listContainers.Location = new System.Drawing.Point(13, 13);
            this.listContainers.Name = "listContainers";
            this.listContainers.Size = new System.Drawing.Size(359, 805);
            this.listContainers.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 824);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // QueueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 861);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listContainers);
            this.Controls.Add(this.showQueueBtn);
            this.Controls.Add(this.createCardBtn);
            this.MaximumSize = new System.Drawing.Size(1200, 900);
            this.Name = "QueueForm";
            this.Text = "Auto Queue";
            this.Load += new System.EventHandler(this.QueueForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button createCardBtn;
        private System.Windows.Forms.Button showQueueBtn;
        private System.Windows.Forms.Panel listContainers;
        private System.Windows.Forms.Button button1;
        }
}

