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
    public class QueueManager
    {
        //add, bindarySearch, removeAt are possibly needed methods
        
        //when a card is removed, remove the bottom UI card and shift all info up.
        List <QueueCard> queue1 = new List<QueueCard>(); //high queue priority
        List<QueueCard> queue2 = new List<QueueCard>(); //medium queue priority
        List<QueueCard> queue3 = new List<QueueCard>(); //low queue priority

        
    }
        //the class that creates and maintains the cards information.
    public class QueueCard
    {
        public string artistName, comissionerName, note;
        public int queuePriority, queuePoisition, complexity;
        public float price;

        //image reference here
        public QueueCard createCard()
        {
            this.artistName =
            this.commissionerName =
            this.note =

            this.queuePriority = 
            this.queuePosition = 
            this.complexity = 
            this.price =

            return this;
        }

    }
}
