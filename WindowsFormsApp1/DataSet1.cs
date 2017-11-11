using System;
using System.Collections.Generic;

namespace WindowsFormsApp1 {
    
    
    public partial class DataSet1
    {
        partial class CommissionDataTable
        {

        }
    }
        //the class that manages the cards within the queues, and each queue.
        //constructs them in UI as well
    public class CardList
    {
        //add, bindarySearch, removeAt, contains, insert; are possibly needed methods
        
        //when a card is removed, remove the bottom UI card and shift all info up.
        public List<Card> queue1 = new List<Card>(); //high queue priority
        public List<Card> queue2 = new List<Card>(); //medium queue priority
        public List<Card> queue3 = new List<Card>(); //low queue priority

        
    }
        //the class that creates and maintains the cards information.
    public class Card
    {
        //can change to have whatever we need to store. same as object and form for Card.
        private string artistName, commissionerName, note, pieceName;
        private int queuePriority, initialPriority, queuePosition, completionCounter, maxCompletionCounter, complexity;
        private decimal price;

        //image reference here for card

            //method that creates an object of class Card, with inputs from the Card Creation Form.
        public Card createCard(String name1, String name2, String note, decimal price) //can change taken values as necessary to what were storing.
        {
            this.artistName = name1;
            this.commissionerName = name2;
            this.note = note;

            this.queuePriority =
            this.queuePosition =
            this.complexity =
            this.completionCounter = 0;

            this.price = price;
            

            return this;
        }
            //pulls information from Card Update Form and sets the card objects values to those.
        public Card updateCard()
        {
            this.artistName =
            this.commissionerName =
            this.note =

            this.queuePriority =
            this.queuePosition =
            this.complexity =
            this.completionCounter =

            this.price = 

            return this;
        }
            //marks the card as completed 
        public void completeCard()
        {

        }
    }
}
