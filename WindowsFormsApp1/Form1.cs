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
    public partial class mainForm : Form
    {
        public static CardList queue1;
        public static CardList queue2;
        public static CardList queue3; 

        public mainForm()
        {
            queue1 = new CardList();
            queue2 = new CardList();
            queue3 = new CardList();
            InitializeComponent();
        }

        //Once a commission is finished, all cards will increment by one
        public static void finishCommission()
        {
            queue1.cardIncrement();
            queue2.cardIncrement();
            queue3.cardIncrement();
        }

        public static CardList getQueue(int priority)
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        //Temporary function that will handle the information from the create commision form
        private void createClicked()
        {
            Card card = new Card();
            card = card.createCard();

        }

    }

    //used to create a file that stores all of the information held by the cards
    //Cards will always follow the following format:
    //[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
    //  [queuePosition] [completionCounter] [maxCompletionCounter] \t\n
    public class CardFileFactory
    {
        static String CSONFile;
        public static void append(String card)
        {
            //The \t is so that the file will still be somewhat readable in notepad
            //\n is for notepad++
            CSONFile += card + "\t\n";
        }
    }

    //Cards will always follow the following format from the file:
    //[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
    //  [queuePosition] [completionCounter] [maxCompletionCounter] \t\n
    public class CardFactory
    {
        Card card = new Card();

        public String cardCollection;
        public char[] cardDelims = ['\t', '\n'];
        public String[] cards = new String[10];

        public void cardParser()
        {
            string commissionerName, pieceName, imgRootDir, note;
            decimal price;
            int priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter;
            
            cards = cardCollection.Split(cardDelims);
            commissionerName = cards[0];
            pieceName = cards[1];
            imgRootDir = cards[2];
            note = cards[3];
            price = Convert.ToDecimal(cards[4]);
            priority = Convert.ToInt32(cards[5]);
            initialPriority = Convert.ToInt32(cards[6]);
            queuePosition = Convert.ToInt32(cards[7]);
            completionCounter = Convert.ToInt32(cards[8]);
            maxCompletionCounter = Convert.ToInt32(cards[9]);

            if (priority == 1)
            {
                mainForm.queue1.addCard(card.recreateCard(commissionerName, pieceName, imgRootDir, note,
                    price, priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter));
            } else if (priority == 2)
            {
                mainForm.queue2.addCard(card.recreateCard(commissionerName, pieceName, imgRootDir, note,
                    price, priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter));
            } else
            {
                mainForm.queue3.addCard(card.recreateCard(commissionerName, pieceName, imgRootDir, note,
                    price, priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter));
            }
        }

    }

    //the class that manages the cards within the queues, and each queue.
    //constructs them in UI as well
    public class CardList
    {
        //add, bindarySearch, removeAt, contains, insert; are possibly needed methods

        //when a card is removed, remove the bottom UI card and shift all info up.
        private List<Card> queue = new List<Card>(); //high queue priority

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
    }
    
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
    }
}
