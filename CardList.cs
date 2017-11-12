using WindowsFormApp1;

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
        for (int i = 0; i < queue.Count; i++)
        {
            queue.ElementAt(i).increment();
        }
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
