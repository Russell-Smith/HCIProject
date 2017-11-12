using System;

namespace WindowsFormsApp1
{
    partial class CreateEditCardView
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pieceName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.commissionerName = new System.Windows.Forms.TextBox();
            this.note = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.imgRootDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.finish = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.NumericUpDown();
            this.delete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.position)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pieceName
            // 
            this.pieceName.Location = new System.Drawing.Point(12, 25);
            this.pieceName.Name = "pieceName";
            this.pieceName.Size = new System.Drawing.Size(360, 20);
            this.pieceName.TabIndex = 0;
            this.pieceName.TextChanged += new System.EventHandler(this.pieceName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Piece Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // commissionerName
            // 
            this.commissionerName.Location = new System.Drawing.Point(12, 76);
            this.commissionerName.Name = "commissionerName";
            this.commissionerName.Size = new System.Drawing.Size(360, 20);
            this.commissionerName.TabIndex = 3;
            this.commissionerName.TextChanged += new System.EventHandler(this.commissionerName_TextChanged);
            // 
            // note
            // 
            this.note.Location = new System.Drawing.Point(127, 172);
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.Size = new System.Drawing.Size(172, 63);
            this.note.TabIndex = 4;
            this.note.TextChanged += new System.EventHandler(this.note_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Commissioner Name:";
            // 
            // priority
            // 
            this.priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priority.FormattingEnabled = true;
            this.priority.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.priority.Location = new System.Drawing.Point(305, 172);
            this.priority.MaxDropDownItems = 3;
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(67, 21);
            this.priority.Sorted = true;
            this.priority.TabIndex = 6;
            this.priority.SelectedIndexChanged += new System.EventHandler(this.priority_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Priority Level:";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(319, 124);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(53, 20);
            this.browse.TabIndex = 8;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // imgRootDir
            // 
            this.imgRootDir.Location = new System.Drawing.Point(12, 124);
            this.imgRootDir.Name = "imgRootDir";
            this.imgRootDir.Size = new System.Drawing.Size(310, 20);
            this.imgRootDir.TabIndex = 9;
            this.imgRootDir.TextChanged += new System.EventHandler(this.imgRootDir_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Image Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Image Preview:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Note:";
            // 
            // finish
            // 
            this.finish.Location = new System.Drawing.Point(236, 249);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(53, 23);
            this.finish.TabIndex = 13;
            this.finish.Text = "Finish";
            this.finish.UseVisualStyleBackColor = true;
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Position:";
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(305, 214);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(67, 20);
            this.position.TabIndex = 16;
            this.position.ValueChanged += new System.EventHandler(this.position_ValueChanged);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(310, 249);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(53, 23);
            this.delete.TabIndex = 17;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Create/Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CreateEditCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.position);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.finish);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imgRootDir);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.note);
            this.Controls.Add(this.commissionerName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieceName);
            this.Name = "CreateEditCardView";
            this.Text = "Create/Edit Commission";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.position)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox pieceName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox commissionerName;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox priority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox imgRootDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button finish;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown position;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button button1;
    }
}