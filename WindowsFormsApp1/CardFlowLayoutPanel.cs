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
        private PictureBox cardImage;
        private Label piece, commissioner;
        private float imageXSize, imageYSize;
        private float windowXSize, windowYSize;

        public CardFlowLayoutPanel() {
            
        }

        // In cases of the parent form resizing, we must resize ourselves.

        public void OnParentResize(float newXSize, float newYSize) {
            if (newXSize < windowXSize) {
                // We are shrinking the form. Adjust accordingly - downsize cards.
                if (newXSize < 160) {
                    // We need to resize the image. We have already stopped displaying the Labels.
                }
                if (newXSize < 240) {
                    // Stop displaying the labels. Center the image.
                }
                if (newXSize < 320) {
                    // Begin to shorten the label size.
                }
            } else {
                // We are increasing the size of the form. Adjust accordingly - upsize cards.
                if (newXSize > 320)
                {
                    // We need do nothing.
                }
                else if (newXSize > 240)
                {
                    // We should now begin exanding the labels.
                }
                else if (newXSize > 160)
                {
                    // Check if the imagesize is at 160. If not, we should bring it up to 160.
                }
                else {
                    // The imagesize should be below 160. We need to increase it to a size of
                    // newXSize - 20. Our margins are 20.
                }
            }
        }

        public List<String> ConvertToCSON() {
            List<String> CSONOutput = new List<String>();

            // CSON gives the type in the initial line
            // Followed by variables.
            // Essentially, this is the expected output:
            // CardFlowLayoutPanel {
            // "pictureImage" : "/url"
            // "pieceTitle" : "$title"
            // "commissionerName" : "$name"
            // }

            CSONOutput.Add(this.GetType().ToString() + " {\n");
            CSONOutput.Add("\"pictureImage\" : \"" + this.cardImage.ImageLocation + "\"\n");
            CSONOutput.Add("\"pieceTitle\" : \"" + this.piece.Text + "\"\n");
            CSONOutput.Add("\"commisionerName\" : \"" + this.commissioner.Text + "\"\n}");

            return CSONOutput;
        }
    }
}
