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
        private PictureBox cardImage;
        private Label piece, commissioner;

        private string note;
        private int commissionsFinishedCounter, queuePosition, priorityLevel, maxFinishedCommissions;
        //private float imageXSize, imageYSize;
        private float listXSize;

        //  Title, Commissioner, and imageURL are strings passed to visually impact the card.
        //  The commissionsFinished represents the number of commissions the card has been in the queue for.
        //  The position is the plaacement in the queue.
        //  The priority is the queue priority level, from 0 - 2, 0 being highest.
        //  This constructor is used for startup card creation from file.
        public CardFlowLayoutPanel(string title, string commissioner, string imageURL, int commissionsFinished, int maxCommissions, int position, int priority, string note)
        {

            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.commissionsFinishedCounter = commissionsFinished;
            this.maxFinishedCommissions = maxCommissions;
            this.queuePosition = position;
            this.priorityLevel = priority;
            this.note = note;
            this.BackColor = System.Drawing.Color.White;

            this.cardImage = new PictureBox
            {
                ImageLocation = imageURL,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            this.cardImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.piece = new Label() {
                Text = title,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            this.piece.Font = new System.Drawing.Font(this.piece.Font, System.Drawing.FontStyle.Bold);

            this.commissioner = new Label() {
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
            this.cardImage.Location = new System.Drawing.Point(5,5);
            this.piece.Location = new System.Drawing.Point(170, 40);
            this.commissioner.Location = new System.Drawing.Point(170, 80);

        }

        //  Constructor for use with runtime creation.
        public CardFlowLayoutPanel(string title, string commissioner, string imgURL, string note, int priority, int position)
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

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
            this.cardImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

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
            this.cardImage.Location = new System.Drawing.Point(5, 5);
            this.piece.Location = new System.Drawing.Point(170, 40);
            this.commissioner.Location = new System.Drawing.Point(170, 80);
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

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
            if (this.queuePosition > 0)
            {
                this.queuePosition -= 1;
            }
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
                updateView.ShowDialog(this);
        }
    }
}
