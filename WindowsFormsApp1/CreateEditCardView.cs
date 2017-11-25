﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class CreateEditCardView : Form
    {
        //The card handed to us, if it exists, in List Form - no need to hand a UI element with it.
        List<String> cardToEditIfExistent;

        //Input storage variables
        private string pieceNameIn, commissionerNameIn, imgRootDirIn, noteIn;
        private int priorityIn, positionIn;

        //Default constructor assumes that we are looking at creating a new card.
        //Ironically, we change default values. Huh.
        public CreateEditCardView()
        {
            InitializeComponent();

            this.Text = "Create New Commission";
            this.deleteBtn.Text = "Clear";
            this.updateBtn.Text = "Cancel";
            this.finishBtn.Text = "Create";
            this.noteTxtBox.ForeColor = Color.Gray;
            this.pieceNameTxtBox.ForeColor = Color.Gray;
            this.commissionerNameTxtBox.ForeColor = Color.Gray;
            this.imageLocationTxtBox.ForeColor = Color.Gray;
            this.noteTxtBox.Text = "Write any notes here, or leave blank if you have no notes.";
            this.pieceNameTxtBox.Text = "Enter the piece name here.";
            this.commissionerNameTxtBox.Text = "Enter the name of the commissioner here.";
            this.imageLocationTxtBox.Text = "Enter the location of the image, or leave blank for white image.";

            this.noteTxtBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.pieceNameTxtBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.commissionerNameTxtBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.imageLocationTxtBox.Enter += new System.EventHandler(this.textBox_Enter);


            this.noteTxtBox.Leave += new System.EventHandler(this.noteTxtBox_Exit);
            this.pieceNameTxtBox.Leave += new System.EventHandler(this.pieceTxtBox_Exit);
            this.commissionerNameTxtBox.Leave += new System.EventHandler(this.commTxtBox_Exit);
            this.imageLocationTxtBox.Leave += new System.EventHandler(this.imageTxtBox_Exit);

            this.imagePreviewPicBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            this.imagePreviewPicBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.updateBtn.Click -= this.updateBtn_Click;
            this.deleteBtn.Click -= this.delete_Click;
            this.updateBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            this.deleteBtn.Click += new System.EventHandler(this.clear_Click);

        }

        //Since there is a String list, we're making an edit to a currently existent card.
        public CreateEditCardView(List<String> cardToEdit)
        {
            InitializeComponent();

            cardToEditIfExistent = cardToEdit;

            this.commissionerNameTxtBox.ReadOnly = true;
            this.pieceNameTxtBox.Text = cardToEditIfExistent.ElementAt(0);
            this.commissionerNameTxtBox.Text = cardToEditIfExistent.ElementAt(1);
            this.imageLocationTxtBox.Text = cardToEditIfExistent.ElementAt(2);
            this.positionNumInput.Value = Int32.Parse(cardToEditIfExistent.ElementAt(3));
            this.priorityDropDown.SelectedIndex = Int32.Parse(cardToEditIfExistent.ElementAt(4));
            this.noteTxtBox.Text = cardToEditIfExistent.ElementAt(5);
            this.imagePreviewPicBox.ImageLocation = cardToEditIfExistent.ElementAt(2);

        }


        //We're using constructors for this.
        //That way we're not doing multiple calls before Show.
        /*
        //Called when user clicks "Create Commission"
        public void createCard()
        {
            positionNumInput.Visible = false;
            //Can't delete a card that isn't made yet.
            deleteBtn.Text = "Cancel";
            updateBtn.Text = "Create";
            this.Text = "Create Card";
        }

        //Called when user clicks on a card.
        public void updateCard()
        {
            commissionerNameTxtBox.ReadOnly = true;
            deleteBtn.Text = "Delete";
            updateBtn.Text = "Update";
            this.Text = "Update Card";
        }*/

        private void pieceName_TextChanged(object sender, EventArgs e)
        {
            if (this.pieceNameTxtBox.BackColor == Color.LightPink)
            {
                this.pieceNameTxtBox.BackColor = Color.White;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e) {

            bool imageFound = false;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files.TakeWhile(j => !imageFound))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(file);
                    if(info.Extension.ToLower() == ".png" || info.Extension.ToLower() == ".jpg" || info.Extension.ToLower() == ".gif")
                    {
                        this.imagePreviewPicBox.ImageLocation = file;
                        imageFound = true;
                    }
                }
            }
        }

        private void textBox_Enter(object sender, EventArgs e) {
            if (((TextBox)sender).ForeColor == Color.Gray)
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).ForeColor = Color.Black;
            }            
        }

        private void commTxtBox_Exit(object sender, EventArgs e) {

            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Enter the name of the commissioner here.";
                ((TextBox)sender).ForeColor = Color.Gray;
            }
        }

        private void pieceTxtBox_Exit(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Enter the piece name here.";
                ((TextBox)sender).ForeColor = Color.Gray;
            }
        }

        private void imageTxtBox_Exit(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Enter the location of the image, if one exists.";
                ((TextBox)sender).ForeColor = Color.Gray;
            }
        }

        private void noteTxtBox_Exit(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "Write any notes here...";
                ((TextBox)sender).ForeColor = Color.Gray;
            }
        }

        //  Creating a list from the old card's data
        //  Old Card Format: PieceName, CommissionerName, CardImageLocation, QueuePosition, QueuePriority, Note
        //  New List Format: PieceName, CardImageLocation, Note, QueuePosition, QueuePriority
        // ###In Code Review### Reform all lists to have similar structure, with most commonly used information at front.
        private void updateBtn_Click(object sender, EventArgs e)
        {
            string unfilledInputs = "";

            if (this.pieceNameTxtBox.Text == "")
            {
                this.pieceNameTxtBox.BackColor = Color.LightPink;
                unfilledInputs += "Piece";
            }

            if (unfilledInputs == "")
            {

                List<string> oldCard = new List<string>();
                oldCard.Add(cardToEditIfExistent.ElementAt(0));
                oldCard.Add(cardToEditIfExistent.ElementAt(2));
                oldCard.Add(cardToEditIfExistent.ElementAt(5));
                oldCard.Add(cardToEditIfExistent.ElementAt(3));
                oldCard.Add(cardToEditIfExistent.ElementAt(4));

                List<string> newCard = new List<string>();
                newCard.Add(this.pieceNameTxtBox.Text);
                newCard.Add(this.imageLocationTxtBox.Text);
                newCard.Add(this.noteTxtBox.Text);
                newCard.Add(this.positionNumInput.Value.ToString());
                newCard.Add(this.priorityDropDown.SelectedIndex.ToString());

                if (oldCard.ElementAt(0) != newCard.ElementAt(0))
                {
                    unfilledInputs += "\nPiece Name";
                }
                if(oldCard.ElementAt(1) != newCard.ElementAt(1))
                {
                    unfilledInputs += "\nImage Location";
                }
                if (oldCard.ElementAt(2) != newCard.ElementAt(2))
                {
                    unfilledInputs += "\nNote";
                }
                if (oldCard.ElementAt(3) != newCard.ElementAt(3))
                {
                    unfilledInputs += "\nQueue Position";
                }
                if (oldCard.ElementAt(4) != newCard.ElementAt(4))
                {
                    unfilledInputs += "\nQueue Priority";
                }

                if(unfilledInputs == "")
                {
                    QueueForm.updateCommission(newCard, oldCard);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    unfilledInputs = "You've updated the following items:" + unfilledInputs + "\n\nContinue?";

                    DialogResult result = MessageBox.Show(this, unfilledInputs, "Are you sure?", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        QueueForm.updateCommission(newCard, oldCard);
                        this.Close();
                        this.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Commissions require a Piece Name!", "Piece Name Missing");
            }


        }

        //  Creating a new commission
        //  
        // ###In Code Review### Reform all lists to have similar structure, with most commonly used information at front.
        private void createBtn_Click(object sender, EventArgs e)
        {
            string unfilledInputs = "";

            if (this.pieceNameTxtBox.Text == "")
            {
                this.pieceNameTxtBox.BackColor = Color.LightPink;
                unfilledInputs += "\nPiece Name";
            }
            if (this.commissionerNameTxtBox.Text == "")
            {
                this.commissionerNameTxtBox.BackColor = Color.LightPink;
                unfilledInputs += "\nCommissioner Name";
            }

            //  All required inputs have been input.
            if (unfilledInputs == "")
            {
                List<string> newCard = new List<string>();
                newCard.Add(this.pieceNameTxtBox.Text);
                newCard.Add(this.imageLocationTxtBox.Text);
                newCard.Add(this.noteTxtBox.Text);
                newCard.Add(this.positionNumInput.Value.ToString());
                newCard.Add(this.priorityDropDown.SelectedIndex.ToString());
                
                QueueForm.addCommissionFromList(newCard);
                this.Close();
                this.Dispose();
            }
            else
            {
                unfilledInputs = "You've left empty the following items:" + unfilledInputs + "\n\nPlease enter values for those items.";

                MessageBox.Show(this, unfilledInputs, "Empty Items!");
            }


        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.Close();
            this.Dispose();
        }

        private void commissionerName_TextChanged(object sender, EventArgs e)
        {
            if (this.commissionerNameTxtBox.BackColor == Color.LightPink)
            {
                this.commissionerNameTxtBox.BackColor = Color.White;
            }
        }

        private void priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Useless. Remove.
        }


        //Allow the user to choose a file from their directories and then store that file into imgRootDir.text
        private void browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocationTxtBox.Text = openFileDialog1.FileName;
            }
        }

        private void imgRootDir_TextChanged(object sender, EventArgs e)
        {
            if (this.imageLocationTxtBox.BackColor == Color.LightPink)
            {
                this.imageLocationTxtBox.BackColor = Color.White;
            }
        }

        //Will cache the card as completed and all other cards will need to increment.
        private void finish_Click(object sender, EventArgs e)
        {
            
        }

        //Will delete the card from the layout panel and not increment all other cards
        private void delete_Click(object sender, EventArgs e)
        {
            QueueForm.deleteCommission(Int32.Parse(cardToEditIfExistent.ElementAt(4)), Int32.Parse(cardToEditIfExistent.ElementAt(3)));
        }

        private void clear_Click(object sender, EventArgs e) {

            this.noteTxtBox.ForeColor = Color.Gray;
            this.pieceNameTxtBox.ForeColor = Color.Gray;
            this.commissionerNameTxtBox.ForeColor = Color.Gray;
            this.imageLocationTxtBox.ForeColor = Color.Gray;
            this.noteTxtBox.Text = "Write any notes here...";
            this.pieceNameTxtBox.Text = "Enter the piece name here.";
            this.commissionerNameTxtBox.Text = "Enter the name of the commissioner here.";
            this.imageLocationTxtBox.Text = "Enter the location of the image, if one exists.";

        }

        /*
        private void createUpdate_Click(object sender, EventArgs e)
        {   
            //If the creation menu is up, create a new card object
            if (this.Text == "Create Card")
            {
                this.pieceNameIn = pieceNameTxtBox.Text;
                this.commissionerNameIn = commissionerNameTxtBox.Text;
                this.imgRootDirIn = imageLocationTxtBox.Text;
                this.noteIn = noteTxtBox.Text;

                this.priorityIn = Convert.ToInt32(priorityDropDown.SelectedValue);

                //All necessary fields must be filled
                if (!hasPieceName || !hasCommissionerName || !hasImgRootDir || !hasPriority)
                {
                    string message = "The following items need to be entered:";

                    if (!hasPieceName) {
                        message += "\nPiece Name";
                    }
                    if (!hasCommissionerName)
                    {
                        message += "\nCommissioner Name";
                    }
                    if (!hasImgRootDir)
                    {
                        message += "\nImage Directory";
                    }
                    if (!hasPriority)
                    {
                        message += "\nPriority";
                    }
                    //Display what info is missing.
                    MessageBox.Show(message, "Form Incomplete", MessageBoxButtons.OK);
                }
                else
                {
                    CreateCard newCard = new CreateCard(pieceNameIn, commissionerNameIn, imgRootDirIn, noteIn, priorityIn);
                }
            }
            else
            {   
                //Will need to make sure that they do not leave fields blank
                this.pieceNameIn = pieceNameTxtBox.Text;
                this.imgRootDirIn = imageLocationTxtBox.Text;
                this.noteIn = noteTxtBox.Text;

                this.priorityIn = Convert.ToInt32(priorityDropDown.SelectedValue);
                this.positionIn = Convert.ToInt32(positionNumInput.Value);

                EditCard updateCard = new EditCard(this.pieceNameIn, this.imgRootDirIn, this.noteIn, this.priorityIn, this.positionIn);
            }
        }*/
    }
}