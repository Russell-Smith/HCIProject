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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            createButton.Click += createButton_Click;
        }

            //the event that clicking on "create"
        private void createButton_Click(object sender, EventArgs e)
        {
            //take input from the fields here.
            String artistName = artistBox.value.ToString();

            //this puts all our data from the form into the card objecct.
            var cqc = new QueueCard();
            cqc.createCard();
        }
    }
}
