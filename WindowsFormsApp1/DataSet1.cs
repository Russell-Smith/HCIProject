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

        
        //when a card is removed, remove the bottom UI card and shift all info up.
        List <QueueCard> queue1 = new List<QueueCard>(); //high queue priority
        List<QueueCard> queue2 = new List<QueueCard>(); //medium queue priority
        List<QueueCard> queue3 = new List<QueueCard>(); //low queue priority

        
    }
        //the class that creates and maintains the cards information.
    public class QueueCard
    {
        string artistName, comissionerName, note;
        int queuePriority, queuePoisition, complexity;
        float price;

    }
}
