using System;

//Cards will always follow the following format from the file:
//[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
//  [queuePosition] [completionCounter] [maxCompeltionCounter] \t\n
public class CardFactory
{
    Card card = new Card();

    public String cardCollection;
    public char[] cardDelims = { '\t', '\n' };
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
        }
        else if (priority == 2)
        {
            mainForm.queue2.addCard(card.recreateCard(commissionerName, pieceName, imgRootDir, note,
                price, priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter));
        }
        else
        {
            mainForm.queue3.addCard(card.recreateCard(commissionerName, pieceName, imgRootDir, note,
                price, priority, initialPriority, queuePosition, completionCounter, maxCompletionCounter));
        }
    }

}
