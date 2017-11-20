using System;
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

    public partial class EditCardView : Form
    {
        //Input storage variables
        private string pieceNameIn, commissionerNameIn, imgRootDirIn, noteIn;
        private int priorityIn, positionIn;

        //Booleans to make sure that information is in the fields.
        private Boolean hasPieceName, hasCommissionerName, hasImgRootDir, hasPriority;

        public EditCardView()
        {
            InitializeComponent();
        }

        //Called when user clicks "Create Commission"
        public void createCard()
        {
            position.Visible = false;
            //Can't delete a card that isn't made yet.
            delete.Text = "Cancel";
            createUpdate.Text = "Create";
            this.Text = "Create Card";
        }

        //Called when user clicks on a card.
        public void updateCard()
        {
            commissionerName.ReadOnly = true;
            delete.Text = "Delete";
            createUpdate.Text = "Update";
            this.Text = "Update Card";
        }

        private void pieceName_TextChanged(object sender, EventArgs e)
        {
            this.hasPieceName = true;
        }

        private void label4_Click(object sender, EventArgs e)
            {

            }

        private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

        private void commissionerName_TextChanged(object sender, EventArgs e)
        {
            this.hasCommissionerName = true;
        }

        private void priority_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.hasPriority = true;
        }


        //Allow the user to choose a file from their directories and then store that file into imgRootDir.text
        private void browse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgRootDir.Text = openFileDialog1.FileName;
            }
        }

        private void imgRootDir_TextChanged(object sender, EventArgs e)
        {
            this.hasImgRootDir = true;
        }

        //Will cache the card as completed and all other cards will need to increment.
        private void finish_Click(object sender, EventArgs e)
        {
            
        }

        //Will delete the card from the layout panel and not increment all other cards
        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void createUpdate_Click(object sender, EventArgs e)
        {   
            //If the creation menu is up, create a new card object
            if (this.Text == "Create Card")
            {
                this.pieceNameIn = pieceName.Text;
                this.commissionerNameIn = commissionerName.Text;
                this.imgRootDirIn = imgRootDir.Text;
                this.noteIn = note.Text;

                this.priorityIn = Convert.ToInt32(priority.SelectedValue);

                //All necessary fields must be filled
                if (!hasPieceName || !hasCommissionerName || !hasImgRootDir || !hasPriority)
                {
                    string message = "The following items need to be entered: \n";

                    if (!hasPieceName) {
                        message += "\nPiece Name";
                    }
                    if (!hasCommissionerName)
                    {
                        message += "\nCommissioner Name";
                    }
                    if (!hasImgRootDir)
                    {
                        message += "\nImage Diretory";
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
                this.pieceNameIn = pieceName.Text;
                this.imgRootDirIn = imgRootDir.Text;
                this.noteIn = note.Text;

                this.priorityIn = Convert.ToInt32(priority.SelectedValue);
                this.positionIn = Convert.ToInt32(position.Value);

                EditCard updateCard = new EditCard(this.pieceNameIn, this.imgRootDirIn, this.noteIn, this.priorityIn, this.positionIn);
            }
        }
    }
}