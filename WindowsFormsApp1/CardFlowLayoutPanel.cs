using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CardFlowLayoutPanel : Panel
    {

        private static int MAX_CARD_SIZE = 320;
        private static int MID_CARD_SIZE = 240;
        private static int MIN_CARD_SIZE = 160;
        private PictureBox cardImage;
        private Label piece, commissioner;

        private string note;
        private int commissionsFinishedCounter, queuePosition, priorityLevel, maxFinishedCommissions;
        private float imageXSize, imageYSize;
        private float listXSize;

        // Title, Commissioner, and imageURL are strings passed to visually impact the card.
        // The commissionsFinished represents the number of commissions the card has been in the queue for.
        // The position is the plaacement in the queue.
        // The priority is the queue priority level, from 0 - 2, 0 being highest.
        public CardFlowLayoutPanel(string title, string commissioner, string imageURL, int commissionsFinished, int maxCommissions, int position, int priority, string note)
        {
            this.commissionsFinishedCounter = commissionsFinished;
            this.maxFinishedCommissions = maxCommissions;
            this.queuePosition = position;
            this.priorityLevel = priority;
            this.note = note;

            this.cardImage = new PictureBox
            {
                ImageLocation = imageURL,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.piece = new Label();
            this.piece.Text = title;
            this.piece.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.commissioner = new Label();
            this.commissioner.Text = commissioner;
            this.commissioner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.Size = new System.Drawing.Size(320, 170);

            this.cardImage.Size = new System.Drawing.Size(160, 160);
            this.piece.Size = new System.Drawing.Size(140, 40);
            this.commissioner.Size = new System.Drawing.Size(140, 40);
            this.cardImage.Location = new System.Drawing.Point(0,0);
            this.piece.Location = new System.Drawing.Point(170, 40);
            this.commissioner.Location = new System.Drawing.Point(170, 80);

        }

        /*
        NOTE: Need to keep track of previous X size to know if we are moving towards Min or Max to scale appropriatley
            EX: If new size is above mid moving towards max, stretch labels. If above mid moving towards mid, shrink. 
        */

        //In cases of the parent form resizing, we must resize ourselves.
        public void OnParentResize(float newXSize) {
            if (newXSize < listXSize) {
                // We are shrinking the form. Adjust accordingly - downsize cards.
                if (newXSize < MIN_CARD_SIZE) {
                    // We will simply add scroll bars on the form, not the card.
                }
                if (newXSize < MID_CARD_SIZE) {

                    // Stop displaying the labels. Center the image.
                    if (piece.Visible)
                    {
                        piece.Hide();
                        commissioner.Hide();
                    }

                    var newLocation = (newXSize - 160) / 2;
                    this.Size = new System.Drawing.Size((int)newXSize, 170);

                    cardImage.Location = new System.Drawing.Point((int)newLocation, 0);

                }
                //Might should be newXSize < currentXSize, consistent problem
                if (newXSize < MAX_CARD_SIZE) {
                    
                    // Begin to shorten the label size.
                }
            } else {
                // We are increasing the size of the form. Adjust accordingly - upsize cards.
                if (newXSize > MAX_CARD_SIZE)
                {
                    // We need do nothing.
                    //Russ - MessageBox("YOU SHALL NOT GROW");
                }
                else if (newXSize > MID_CARD_SIZE)
                {
                    if(!piece.Visible){
                        this.piece.Show();
                        this.commissioner.Show();
                        this.cardImage.Location = new System.Drawing.Point(0, 0);
                    } else {
                        var length = Math.Round((newXSize / 320) * 140);

                        this.piece.Size = new System.Drawing.Size((int)length, 40);
                        this.commissioner.Size = new System.Drawing.Size((int)length, 40);
                    }
                    // We should now begin exanding the labels.
                }
                else if (newXSize > MIN_CARD_SIZE)
                {
                    // Check if the imagesize is at 160. If not, we should bring it up to 160.
                    if(this.cardImage.Size.Height < 160){
                        this.Size = new System.Drawing.Size((int)newXSize, 170);
                        this.cardImage.Size = new System.Drawing.Size(160, 160);
                    }


                    var newLocation = (newXSize - 160) / 2;
                    this.cardImage.Location = new System.Drawing.Point((int)newLocation, 0);
                }
                else 
                {
                    //We don't want to go below MIN_CARD_SIZE.
                }
            }

            this.listXSize = newXSize;
        }

        public String ConvertToCSV()
        {
            String CSVOutput;

            //We're outputting a CSV file to
            CSVOutput = this.piece.Text + "," + this.commissioner.Text + "," + 
                            this.cardImage.ImageLocation + "," + this.commissionsFinishedCounter.ToString() +
                            "," + queuePosition.ToString() + "," + priorityLevel.ToString() + "," + note;

            return CSVOutput;
        }
    }
}
