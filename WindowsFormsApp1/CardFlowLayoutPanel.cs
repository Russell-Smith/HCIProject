using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CardFlowLayoutPanel : Panel
    {

        private static int MAX_CARD_SIZE = 320;
        private static int MID_CARD_SIZE = 240;
        private static int MIN_CARD_SIZE = 160;
        private PictureBox cardImage;
        private Label piece, commissioner;

        private string note;
        private int commissionsFinishedCounter, queuePosition, priorityLevel, maxFinishedCommissions;
        //private float imageXSize, imageYSize;
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

            this.piece = new Label() {
                Text = title,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.commissioner = new Label() {
                Text = commissioner,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.Size = new System.Drawing.Size(320, 170);

            this.cardImage.Size = new System.Drawing.Size(160, 160);
            this.piece.Size = new System.Drawing.Size(140, 40);
            this.commissioner.Size = new System.Drawing.Size(140, 40);
            this.cardImage.Location = new System.Drawing.Point(0,0);
            this.piece.Location = new System.Drawing.Point(170, 40);
            this.commissioner.Location = new System.Drawing.Point(170, 80);

        }

        //Temporary constructor for use with the CardCreationForm for now.
        //This fills in NON-FINAL VALUES.
        //IF THIS IS IN THE FINAL PRESENTATION, WE DUN GOOFED.
        public CardFlowLayoutPanel(string title, string commissioner, int priority, string note){
            this.commissionsFinishedCounter = 0;
            if(priority == 0){
                this.priorityLevel = 0;
                this.maxFinishedCommissions = -1;
            } else {
                this.priorityLevel = priority;
                this.maxFinishedCommissions = priority * 5;
            }

            this.note = note;
            this.cardImage = new PictureBox{
                ImageLocation = "blankImage.jpg",
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.queuePosition = 0;

            this.piece = new Label() {
                Text = title,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.commissioner = new Label() {
                Text = commissioner,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
        }

        //Temporary constructor for use with the CardCreationForm for now.
        //This fills in NON-FINAL VALUES.
        //IF THIS IS IN THE FINAL PRESENTATION, WE DUN GOOFED.
        //WE HAVE TWO OF THESE NOW.
        //I AM A WONDERFUL DEVELOPER.
        public CardFlowLayoutPanel(string title, string commissioner, string imgURL, string note, int priority, int position)
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.commissionsFinishedCounter = 0;
            this.priorityLevel = priority;
            if (priority == 0)
            {
                this.maxFinishedCommissions = -1;
            }
            else
            {
                this.maxFinishedCommissions = priority * 5;
            }

            this.note = note;
            this.cardImage = new PictureBox
            {
                ImageLocation = imgURL,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.queuePosition = position;

            this.piece = new Label()
            {
                Text = title,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.piece.Font = new System.Drawing.Font(this.piece.Font, System.Drawing.FontStyle.Bold);

            this.commissioner = new Label()
            {
                Text = commissioner,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };


            this.commissioner.Font = new System.Drawing.Font(this.commissioner.Font, System.Drawing.FontStyle.Bold);

            this.Controls.Add(this.commissioner);
            this.Controls.Add(this.piece);
            this.Controls.Add(this.cardImage);

            this.Click += new System.EventHandler(this.CardPanel_Clicked);
            this.commissioner.Click += new System.EventHandler(this.CardPanel_Clicked);
            this.piece.Click += new System.EventHandler(this.CardPanel_Clicked);
            this.cardImage.Click += new System.EventHandler(this.CardPanel_Clicked);

            this.Size = new System.Drawing.Size(320, 170);

            this.cardImage.Size = new System.Drawing.Size(160, 160);
            this.piece.Size = new System.Drawing.Size(140, 40);
            this.commissioner.Size = new System.Drawing.Size(140, 40);
            this.cardImage.Location = new System.Drawing.Point(0, 0);
            this.piece.Location = new System.Drawing.Point(170, 40);
            this.commissioner.Location = new System.Drawing.Point(170, 80);
        }

        //This is for testing, and does not represent ANY FORM OF TRUE CARD.
        //Remove this after testing functionality of layout methods.
        public CardFlowLayoutPanel(){
            this.commissionsFinishedCounter = 0;
            this.maxFinishedCommissions = -1;
            this.priorityLevel = 0;
            this.note = "Test Card -- Please Ignore";
            this.cardImage = new PictureBox{
                ImageLocation = "blankImage.jpg",
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            
            this.queuePosition = 0;         
           
            this.piece = new Label() {
                Text = "Test Card -- Please Ignore",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.commissioner = new Label() {
                Text = "Test Commissioner -- Please Ignore",
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            
            this.BackColor = System.Drawing.Color.Blue;
        }

        /*
            NOTE: Need to keep track of previous X size to know if we are moving towards Min or Max to scale appropriateley
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
                    //Russ - MessageBox("YOU SHALL NOT GROW") <- No.
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

        // The update method takes a list ordered in the inputs of the update window:
        // Piece Name, Image Location, Note, Priority, and Position.
        public void updateCard(List<String> changes) {
            this.piece.Text = changes.ElementAt(0);
            this.cardImage.ImageLocation = changes.ElementAt(1);
            this.note = changes.ElementAt(2);
            this.priorityLevel = Int32.Parse(changes.ElementAt(3));
            this.queuePosition = Int32.Parse(changes.ElementAt(4));

        }

        public void ReducePosition() {
            this.queuePosition -= 1;
        }

        public void IncreasePosition() {
            this.queuePosition += 1;
        }

        public void SetName(string inName) {
            this.piece.Text = inName;
        }

        public void SetImageURL(string imgURL) {
            this.cardImage.ImageLocation = imgURL;
        }

        public void SetNote(string inNote)
        {
            this.note = inNote;
        }

        //Intentional typo. We are imposing, after all.
        public void SetPosition(int imPosition) {
            this.queuePosition = imPosition;
        }

        public int GetPosition()
        {
            return this.queuePosition;
        }

        public void SetPriority(int priority) {
            this.priorityLevel = priority;
        }

        public int GetPriority()
        {
            return this.priorityLevel;
        }

        public String ConvertToCSV()
        {
            String CSVOutput;

            //We're outputting a CSV file to
            CSVOutput = this.piece.Text + "\",\"" + this.commissioner.Text + "\",\"" + 
                            this.cardImage.ImageLocation + "\",\"" + this.commissionsFinishedCounter.ToString() +
                            "\",\"" + this.maxFinishedCommissions.ToString() + "\",\"" + queuePosition.ToString() + "\",\"" + priorityLevel.ToString() + "\",\"" + note;

            return CSVOutput;
        }

        public List<String> ConvertToList() {
            List <String> output = new List<String>();

            output.Add(this.piece.Text);
            output.Add(this.commissioner.Text);
            output.Add(this.cardImage.ImageLocation);
            output.Add(this.queuePosition.ToString());
            output.Add(this.priorityLevel.ToString());
            output.Add(this.note);

            return output;
        }

        public bool IncrementCommissionsFinished(){
            this.commissionsFinishedCounter++;

            if(this.commissionsFinishedCounter == maxFinishedCommissions){
                this.priorityLevel = 0;
                this.commissionsFinishedCounter = 0;
                this.maxFinishedCommissions = -1;
                return true;
            }
            return false;
        }

        public void CardPanel_Clicked(object sender, EventArgs e) {
            CreateEditCardView updateView = new CreateEditCardView(this.ConvertToList());
            updateView.Show();
        }
    }
}
