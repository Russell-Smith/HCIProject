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
    public partial class QueueForm : Form
    {
        public static CardListFlowLayoutPanel topList;
        public static CardListFlowLayoutPanel intermediateList;
        public static CardListFlowLayoutPanel bottomList;
        public static CardFileFactory fileFactory;
        public static CardFactory cardFactory;

        public QueueForm()
        {
            topList = new CardListFlowLayoutPanel(0);
            intermediateList = new CardListFlowLayoutPanel(1);
            bottomList = new CardListFlowLayoutPanel(2);
            fileFactory = new CardFileFactory();
            cardFactory = new CardFactory();
            InitializeComponent();
            listContainers.BackColor = Color.Black;
            this.TopMost = Properties.Settings.Default.alwaysOnTop;
        }

        //Once a commission is finished, all cards will increment by one
        public static void finishCommission()
        {
            List<CardFlowLayoutPanel> pushToTopList = new List<CardFlowLayoutPanel>();

            topList.CardIncrement();
            pushToTopList.AddRange(intermediateList.CardIncrement());
            pushToTopList.AddRange(bottomList.CardIncrement());

            topList.AddRange(pushToTopList);

        }

        //Delete a commission, no incrementing.
        public static void deleteCommission(int queue, int position) {
            switch (queue)
            {
                case 0:
                    topList.DeleteCardAtPosition(position);
                    break;
                case 1:
                    intermediateList.DeleteCardAtPosition(position);
                    break;
                case 2:
                    bottomList.DeleteCardAtPosition(position);
                    break;
                default:
                    break;
            }
        }

        public static void addCommission(string pieceName, string commissionerName, string note) {
            bottomList.Add(cardFactory.getCardPanelFromInput(pieceName, commissionerName, 2, note));
            foreach(CardFlowLayoutPanel card in bottomList.)
            
        }

        /*
        public static CardListFlowLayoutPanel getQueue(int priority)
        {
            if (priority == 1)
            {
                return queue1;
            } else if (priority == 2)
            {
                return queue2;
            } else if (priority == 3)
            {
                return queue3;
            }
            return null;
        }*/

        private void QueueForm_Load(object sender, EventArgs e)
        {
            List<CardFlowLayoutPanel>[] populatedList = CardFactory.PopulateFromDisk();
            topList.AddRange(populatedList[0]);
            intermediateList.AddRange(populatedList[1]);
            bottomList.AddRange(populatedList[2]);

            this.listContainers.Controls.Add(topList);
            this.listContainers.Controls.Add(intermediateList);
            this.listContainers.Controls.Add(bottomList);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        override protected void OnResize(EventArgs e) {
            base.OnResize(e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button senderBtn = (Button)sender;
            if (senderBtn.Text == "Show All Queues")
            {
                this.Size = new Size(1143, 900);
                listContainers.Size = new Size(1100, 800);
                senderBtn.Text = "Hide Additional Queues";
                intermediateList.Visible = true;
                bottomList.Visible = true;
            }
            else
            {
                this.Size = new Size(400, 900);
                listContainers.Size = new Size(360, 800);
                senderBtn.Text = "Show All Queues";
                intermediateList.Visible = false;
                bottomList.Visible = false;
            }
        }

        private void createCardBtn_Click(object sender, EventArgs e)
        {
            CreateEditCardView createForm = new CreateEditCardView();
            createForm.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.Show(this);
        }

        /*
        //Temporary function that will handle the information from the create commission form
        private void createClicked()
        {
            Card card = new Card();
            card = card.createCard();

        }
        */

    }

    //used to create a file that stores all of the information held by the cards
    //Cards will always follow the following format:
    //[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
    //  [queuePosition] [completionCounter] [maxCompletionCounter] \t\n
    public class CardFileFactory
    {

        static string filename = "cardlist.csv";

        static String CSVFile;
        public static void writeFile(List<String> cardList)
        {

            //Using a CSV file, we will write to delimit values by comma, and objects by newline.
            foreach(String s in cardList){
                CSVFile += s + "\n";
            }

            using(System.IO.FileStream fs = System.IO.File.Create(filename)){
                fs.Write(Encoding.UTF8.GetBytes(CSVFile), 0, Encoding.UTF8.GetByteCount(CSVFile));
                fs.Flush();
            }
        }
    }

    //Cards will always follow the following format from the file:
    //[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
    //  [queuePosition] [completionCounter] [maxCompletionCounter] \t\n
    public class CardFactory
    {

        static string filename = "cardlist.csv";

        public static List<CardFlowLayoutPanel>[] PopulateFromDisk(){

            List<CardFlowLayoutPanel>[] cardListArray = new List<CardFlowLayoutPanel>[3];
            cardListArray[0] = new List<CardFlowLayoutPanel>();
            cardListArray[1] = new List<CardFlowLayoutPanel>();
            cardListArray[2] = new List<CardFlowLayoutPanel>();

            if (System.IO.File.Exists(filename)){

                String piece, commissioner, imgURL, commissionsFinished, maxCommissions, queuePosition, priorityLevel, note;

                using(System.IO.FileStream fs = System.IO.File.OpenRead(filename)){
                    byte[] b = new byte[fs.Length];

                    UTF8Encoding encoder = new UTF8Encoding(true);
                    String CSVFull = "";
                    List<String> CSVParsed = new List<String>();

                    fs.Read(b, 0, b.Length);
                    CSVFull = encoder.GetString(b);
                    CSVParsed.AddRange(CSVFull.Split('\n'));

                    foreach(String s in CSVParsed){
                        String[] cardStrings = s.Split(',');
                        piece = cardStrings[0];
                        commissioner = cardStrings[1];
                        imgURL = cardStrings[2];
                        commissionsFinished = cardStrings[3];
                        maxCommissions = cardStrings[4];
                        queuePosition = cardStrings[5];
                        priorityLevel = cardStrings[6];
                        note = cardStrings[7];

                        switch (priorityLevel){
                            case "0":
                                cardListArray[0].Add(new CardFlowLayoutPanel(
                                    piece, commissioner, imgURL, Int32.Parse(commissionsFinished), Int32.Parse(maxCommissions), Int32.Parse(queuePosition),
                                    Int32.Parse(priorityLevel), note));
                                break;
                            case "1":
                                cardListArray[1].Add(new CardFlowLayoutPanel(
                                    piece, commissioner, imgURL, Int32.Parse(commissionsFinished), Int32.Parse(maxCommissions), Int32.Parse(queuePosition),
                                    Int32.Parse(priorityLevel), note));
                                break;
                            case "2":
                                cardListArray[2].Add(new CardFlowLayoutPanel(
                                    piece, commissioner, imgURL, Int32.Parse(commissionsFinished), Int32.Parse(maxCommissions), Int32.Parse(queuePosition),
                                    Int32.Parse(priorityLevel), note));
                                break;
                            default:
                                Console.WriteLine("Bad input encountered. CardStrings is " + cardStrings.Length + " elements long!");
                                break;
                        }
                    }
                }

            } else {
                Console.WriteLine("No file present in root directory. User has no cards saved.");
                }
            return cardListArray;
        }

        public CardFlowLayoutPanel getCardPanelFromInput(string title, string commissioner, string imageURL, int commissionsFinished, int maxCommissions, int position, int priority, string note){
            return new CardFlowLayoutPanel(title, commissioner, imageURL, commissionsFinished, maxCommissions, position, priority, note);
        }

        public CardFlowLayoutPanel getCardPanelFromInput(string title, string commissioner, int priority, string note)
            {
            return new CardFlowLayoutPanel(title, commissioner, priority, note);
            }
        }

    /*

    //the class that manages the cards within the queues, and each queue.
    //constructs them in UI as well
    public class CardList
    {
        //add, bindarySearch, removeAt, contains, insert; are possibly needed methods

        //when a card is removed, remove the bottom UI card and shift all info up.
        private List<CardFlowLayoutPanel> queue = new List<CardFlowLayoutPanel>(); //high queue priority

        public int getSize()
        {
            return queue.Count;
        }

        public void addCard(Card card)
        {
            queue.Add(card);
        }

        public void cardIncrement()
        {
            for(int i = 0; i < queue.Count; i++)
            {
                queue.ElementAt(i).increment();
            }
        }

        public void cardMoved(Card movedCard)
        {

        }

        public void removeCard(int position)
        {
            queue.RemoveAt(position);
        }

        public void insertCard(int position, Card card)
        {
            queue.Insert(position, card);
        }

        public Card getCard(int position)
        {
            return queue[position];
        }
    }*/

    /*
    //the class that creates and maintains the cards information.
    public class Card
    {
        //can change to have whatever we need to store. same as object and form for Card.
        private string commissionerName, pieceName, imgRootDir, note;
        private decimal price;
        private int priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter;

        //image reference here for card

        //method that creates an object of class Card, with inputs from the Card Creation Form.
        //can change taken values as necessary to what we're storing.
        public Card createCard(String commissionerName, String pieceName, String imgRootDir, String note, decimal price, int priority) 
        {
            this.commissionerName = commissionerName;
            this.pieceName = pieceName;
            this.imgRootDir = imgRootDir;
            this.note = note;

            this.price = price;

            this.priority = this.initialPriority = priority;

            //get the current length of the queue to determine position
            CardList dummy = mainForm.getQueue(priority);
            this.queuePosition = dummy.getSize();
            
            this.completionCounter = 0;
            if (priority == 1)
            {
                this.maxCompletionCounter = int.MaxValue;
            } else if (priority == 2)
            {
                this.maxCompletionCounter = 5;
            } else
            {
                this.maxCompletionCounter = 8;
            }

            return this;
        }

        //This will be done on startup to load all current card information into the application
        public Card recreateCard(String commissionerName, String pieceName, String imgRootDir, String note,
                    decimal price, int priority, int initialPriority, int queuePosition, int completionCounter, 
                    int maxCompletionCounter)
        {
            this.commissionerName = commissionerName;
            this.pieceName = pieceName;
            this.imgRootDir = imgRootDir;
            this.note = note;

            this.price = price;

            this.priority =  priority;
            this.initialPriority = initialPriority;
            this.queuePosition = queuePosition;
            this.completionCounter = completionCounter;
            this.maxCompletionCounter = maxCompletionCounter;


            return this;
        }

        //pulls information from Card Update Form and sets the card objects values to those.
            //only the pieceName, imgRootDir, and note can be changed through this feature
        public Card updateCard(String pieceName, String imgRootDir, String note)
        {
            this.pieceName = pieceName;
            this.imgRootDir = imgRootDir;
            this.note = note;
            return this;
        }

        public int getPosition()
        {
            return this.queuePosition;
        }

        //Method to handle if the user manually changes the position of a commission
            //Needs to update the queue
            //Make sure that the new Postion being fed is the entered position - 1
        public void changePriorityAndPosition(int newPriority, int newPosition)
        {
            //all commissions' positions after the moved commission's new position will have to increment by one
            //match the counter of the piece before it so that it stays in the correct position
            if (this.priority == 1)
            {
                mainForm.queue1.removeCard(this.queuePosition);
            }
            else if (this.priority == 2)
            {
                mainForm.queue2.removeCard(this.queuePosition);
            }
            else
            {
                mainForm.queue3.removeCard(this.queuePosition);
            }
            if (newPriority == 1)
            {
                mainForm.queue1.insertCard(newPosition, this);
                this.completionCounter = mainForm.queue1.getCard(newPosition - 1).getPosition();
            }
            else if (newPriority == 2)
            {
                mainForm.queue2.insertCard(newPosition, this);
                this.completionCounter = mainForm.queue2.getCard(newPosition - 1).getPosition();
            }
            else
            {
                mainForm.queue3.insertCard(newPosition, this);
                this.completionCounter = mainForm.queue3.getCard(newPosition - 1).getPosition();
            }

            this.queuePosition = newPosition;
            this.priority = newPriority;

            if (newPriority == this.priority)
            {
                //reset maxCompletionCounter to match the new queue. Artist would like to wait that long to see 
                //  the piece again
                if (newPriority == 1)
                {
                    this.maxCompletionCounter = int.MaxValue;
                }
                else if (newPriority == 2)
                {
                    this.maxCompletionCounter = 5;
                }
                else
                {
                    this.maxCompletionCounter = 8;
                }
            }
        }
        

        //incrment the counter of every commission when one is completed. if the move bool becomes true,
        //the card will need to be moved to the first queue. 
        public void increment()
        {
            this.completionCounter++;
            if (this.completionCounter == this.maxCompletionCounter)
            {
                this.priority = 1;
                this.completionCounter = 0;
                this.maxCompletionCounter = int.MaxValue;
               
            }
        }

        //marks the card as completed, deletes the information from the file
        //A possible way to make this possible is to set all of the string values to empty and 
        //num values to -1
        public void completeCard()
        {
            if (this.priority == 1 && this.queuePosition == 0) {
                mainForm.queue1.removeCard(0);
                mainForm.finishCommission();
            }
        }

        //removes a card from the appropraite queue
        public void deleteCard()
        {
            if(this.priority == 1)
            {
                mainForm.queue1.removeCard(this.queuePosition);
            } else if (this.priority == 2)
            {
                mainForm.queue2.removeCard(this.queuePosition);
            } else
            {
                mainForm.queue3.removeCard(this.queuePosition);
            }
        }

        //Converts the information into a string to be inserted into the CardFileFactory
        public void ToCSON()
        {
            String CSON = this.commissionerName +
                this.pieceName +
                this.imgRootDir +
                this.note +
                this.price.ToString() +
                this.priority.ToString() +
                this.initialPriority.ToString() +
                this.queuePosition.ToString() +
                this.completionCounter.ToString() +
                this.maxCompletionCounter.ToString();

            CardFileFactory.append(CSON);
        }
    }*/
}
