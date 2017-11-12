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

    public partial class CreateEditCardView : CreateEditCardView
    {
        private String pieceNameIn, commissionerNameIn, imgRootDirIn, noteIn;
        private int priorityIn, positionIn;

        public CreateEditCardView()
        {
            InitializeComponent();
        }

        public void createCard()
        {
            this.newCard = true;
            position.Visible = false;
            delete.Text = "Cancel";
            createUpdate.Text = "Create";
            this.Text = "Create Card";
        }

        public void updateCard()
        {
            this.newCard = false;
            commissionerName.ReadOnly = true;
            delete.Text = "Delete";
            createUpdate.Text = "Update";
            this.Text = "Update Card";
        }

        private void pieceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void commissionerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void note_TextChanged(object sender, EventArgs e)
        {

        }

        private void priority_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        }

        private void finish_Click(object sender, EventArgs e)
        {

        }

        private void position_ValueChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void createUpdate_Click(object sender, EventArgs e)
        {
            if (this.Text == "Create Card")
            {
                this.pieceNameIn = pieceName.Text;
                this.commissionerNameIn = commissionerName.Text;
                this.imgRootDirIn = imgRootDir.Text;
                this.noteIn = note.Text;

                this.priorityIn = Convert.ToInt32(priority.SelectedValue);

                CreateCard newCard = new CreateCard(pieceNameIn, commissionerNameIn, imgRootDirIn, noteIn, priorityIn);
            } else
            {
                this.pieceNameIn = pieceName.Text;
                this.imgRootDirIn = imgRootDir.Text;
                this.noteIn = note.Text;

                this.priorityIn = Convert.ToInt32(priority.SelectedValue);
                this.positionIn = Convert.ToInt32(position.Value);

            }
        }
    }