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
            this.pieceNameTxtBox = new System.Windows.Forms.TextBox();
            this.pieceLabel = new System.Windows.Forms.Label();
            this.imagePreviewPicBox = new System.Windows.Forms.PictureBox();
            this.commissionerNameTxtBox = new System.Windows.Forms.TextBox();
            this.noteTxtBox = new System.Windows.Forms.TextBox();
            this.commissionerLabel = new System.Windows.Forms.Label();
            this.priorityDropDown = new System.Windows.Forms.ComboBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.imageLocationTxtBox = new System.Windows.Forms.TextBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.imagePreviewLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.finishBtn = new System.Windows.Forms.Button();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionNumInput = new System.Windows.Forms.NumericUpDown();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumInput)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pieceNameTxtBox
            // 
            this.pieceNameTxtBox.Location = new System.Drawing.Point(199, 25);
            this.pieceNameTxtBox.Name = "pieceNameTxtBox";
            this.pieceNameTxtBox.Size = new System.Drawing.Size(380, 20);
            this.pieceNameTxtBox.TabIndex = 0;
            this.pieceNameTxtBox.TextChanged += new System.EventHandler(this.pieceName_TextChanged);
            // 
            // pieceLabel
            // 
            this.pieceLabel.AutoSize = true;
            this.pieceLabel.Enabled = false;
            this.pieceLabel.Location = new System.Drawing.Point(196, 9);
            this.pieceLabel.Name = "pieceLabel";
            this.pieceLabel.Size = new System.Drawing.Size(68, 13);
            this.pieceLabel.TabIndex = 1;
            this.pieceLabel.Text = "Piece Name:";
            // 
            // imagePreviewPicBox
            // 
            this.imagePreviewPicBox.Location = new System.Drawing.Point(15, 25);
            this.imagePreviewPicBox.Name = "imagePreviewPicBox";
            this.imagePreviewPicBox.Size = new System.Drawing.Size(160, 160);
            this.imagePreviewPicBox.TabIndex = 2;
            this.imagePreviewPicBox.TabStop = false;
            this.imagePreviewPicBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // commissionerNameTxtBox
            // 
            this.commissionerNameTxtBox.Location = new System.Drawing.Point(199, 75);
            this.commissionerNameTxtBox.Name = "commissionerNameTxtBox";
            this.commissionerNameTxtBox.Size = new System.Drawing.Size(380, 20);
            this.commissionerNameTxtBox.TabIndex = 1;
            this.commissionerNameTxtBox.TextChanged += new System.EventHandler(this.commissionerName_TextChanged);
            // 
            // noteTxtBox
            // 
            this.noteTxtBox.Location = new System.Drawing.Point(15, 215);
            this.noteTxtBox.Multiline = true;
            this.noteTxtBox.Name = "noteTxtBox";
            this.noteTxtBox.Size = new System.Drawing.Size(400, 40);
            this.noteTxtBox.TabIndex = 4;
            // 
            // commissionerLabel
            // 
            this.commissionerLabel.AutoSize = true;
            this.commissionerLabel.Enabled = false;
            this.commissionerLabel.Location = new System.Drawing.Point(196, 59);
            this.commissionerLabel.Name = "commissionerLabel";
            this.commissionerLabel.Size = new System.Drawing.Size(105, 13);
            this.commissionerLabel.TabIndex = 5;
            this.commissionerLabel.Text = "Commissioner Name:";
            // 
            // priorityDropDown
            // 
            this.priorityDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityDropDown.FormattingEnabled = true;
            this.priorityDropDown.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.priorityDropDown.Location = new System.Drawing.Point(507, 196);
            this.priorityDropDown.MaxDropDownItems = 3;
            this.priorityDropDown.Name = "priorityDropDown";
            this.priorityDropDown.Size = new System.Drawing.Size(72, 21);
            this.priorityDropDown.Sorted = true;
            this.priorityDropDown.TabIndex = 5;
            this.priorityDropDown.SelectedIndexChanged += new System.EventHandler(this.priority_SelectedIndexChanged);
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(431, 199);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(70, 13);
            this.priorityLabel.TabIndex = 10;
            this.priorityLabel.Text = "Priority Level:";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(507, 151);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(72, 25);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "&Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browse_Click);
            // 
            // imageLocationTxtBox
            // 
            this.imageLocationTxtBox.AllowDrop = true;
            this.imageLocationTxtBox.Location = new System.Drawing.Point(199, 125);
            this.imageLocationTxtBox.Name = "imageLocationTxtBox";
            this.imageLocationTxtBox.Size = new System.Drawing.Size(380, 20);
            this.imageLocationTxtBox.TabIndex = 2;
            this.imageLocationTxtBox.TextChanged += new System.EventHandler(this.imgRootDir_TextChanged);
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Enabled = false;
            this.imageLabel.Location = new System.Drawing.Point(196, 109);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(39, 13);
            this.imageLabel.TabIndex = 10;
            this.imageLabel.Text = "Image:";
            this.imageLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // imagePreviewLabel
            // 
            this.imagePreviewLabel.AutoSize = true;
            this.imagePreviewLabel.Enabled = false;
            this.imagePreviewLabel.Location = new System.Drawing.Point(12, 9);
            this.imagePreviewLabel.Name = "imagePreviewLabel";
            this.imagePreviewLabel.Size = new System.Drawing.Size(80, 13);
            this.imagePreviewLabel.TabIndex = 11;
            this.imagePreviewLabel.Text = "Image Preview:";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(12, 199);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(30, 13);
            this.noteLabel.TabIndex = 12;
            this.noteLabel.Text = "Note";
            // 
            // finishBtn
            // 
            this.finishBtn.Location = new System.Drawing.Point(361, 287);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(105, 25);
            this.finishBtn.TabIndex = 8;
            this.finishBtn.Text = "&Finish Commission";
            this.finishBtn.UseVisualStyleBackColor = true;
            this.finishBtn.Click += new System.EventHandler(this.finish_Click);
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(454, 225);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(47, 13);
            this.positionLabel.TabIndex = 15;
            this.positionLabel.Text = "Position:";
            // 
            // positionNumInput
            // 
            this.positionNumInput.Location = new System.Drawing.Point(507, 223);
            this.positionNumInput.Name = "positionNumInput";
            this.positionNumInput.Size = new System.Drawing.Size(72, 20);
            this.positionNumInput.TabIndex = 6;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(472, 287);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(110, 25);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "&Delete Commission";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.delete_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(15, 287);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 25);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "&Update Card";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // CreateEditCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 321);
            this.ControlBox = false;
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.positionNumInput);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.imagePreviewLabel);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.imageLocationTxtBox);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.priorityDropDown);
            this.Controls.Add(this.commissionerLabel);
            this.Controls.Add(this.noteTxtBox);
            this.Controls.Add(this.commissionerNameTxtBox);
            this.Controls.Add(this.imagePreviewPicBox);
            this.Controls.Add(this.pieceLabel);
            this.Controls.Add(this.pieceNameTxtBox);
            this.Name = "CreateEditCardView";
            this.Text = "Edit Commission Information";
            ((System.ComponentModel.ISupportInitialize)(this.imagePreviewPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionNumInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox pieceNameTxtBox;
        private System.Windows.Forms.Label pieceLabel;
        private System.Windows.Forms.PictureBox imagePreviewPicBox;
        private System.Windows.Forms.TextBox commissionerNameTxtBox;
        private System.Windows.Forms.TextBox noteTxtBox;
        private System.Windows.Forms.Label commissionerLabel;
        private System.Windows.Forms.ComboBox priorityDropDown;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.TextBox imageLocationTxtBox;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Label imagePreviewLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button finishBtn;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.NumericUpDown positionNumInput;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}