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
    public partial class cardCreationForm : Form
    {
        public cardCreationForm()
        {
            InitializeComponent();
            createButton.Click += createButton_Click;
        }

        //the event that clicking on "create"
        private void createButton_Click(object sender, EventArgs e)
        {
            //take input from the fields here.
            String pieceName = artistBox.Text;
            String commissionerName = commissionerBox.Text;
            String note = noteBox.Text;

            decimal price = priceBox.Value;

            //this puts all our data from the form into the card object.
            //For now, this is how this will be done. However, eventually, this will be done differently.
            QueueForm.addCommission(pieceName, commissionerName, note);
        }
    }
}
