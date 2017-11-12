using WindowsFormApp1;

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
        }
        else if (priority == 2)
        {
            this.maxCompletionCounter = 5;
        }
        else
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

        this.priority = priority;
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
        if (this.priority == 1 && this.queuePosition == 0)
        {
            mainForm.queue1.removeCard(0);
            mainForm.finishCommission();
        }
    }

    //removes a card from the appropraite queue
    public void deleteCard()
    {
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
    }

    //Converts the information into a string to be inserted into the CardFileFactory
    public void ToCSON()
    {
        String CSON = this.commissionerName + ","
            + this.pieceName + ","
            + this.imgRootDir + ","
            + this.note + ","
            + this.price.ToString() + ","
            + this.priority.ToString() + ","
            + this.initialPriority.ToString() + ","
            + this.queuePosition.ToString() + ","
            + this.completionCounter.ToString() + ","
            + this.maxCompletionCounter.ToString();

        CardFileFactory.append(CSON);
    }
}