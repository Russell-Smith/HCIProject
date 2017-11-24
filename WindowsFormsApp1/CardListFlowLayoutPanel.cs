using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CardListFlowLayoutPanel : Panel
    {
        private List<CardFlowLayoutPanel> cardList;
        private int windowXSize, windowYSize, priority;


        public CardListFlowLayoutPanel(int priority)
        {
            this.Size = new System.Drawing.Size(360, 800);
            this.Location = new System.Drawing.Point((priority * 370), 0);
            this.priority = priority;
            if(this.priority > 0){
                this.Visible = false;
            }
            this.cardList = new List<CardFlowLayoutPanel>();
            this.BackColor = System.Drawing.Color.White;
        }

        public void OnParentResize(int newXSize, int newYSize){
            newXSize = newXSize - 20;
            newYSize = newYSize - 20;
            foreach(CardFlowLayoutPanel card in cardList){
                card.OnParentResize(newXSize);
            }
        }

        public List<CardFlowLayoutPanel> CardIncrement(){

            if (cardList.Count == 0){
                return cardList;
            }

            List<CardFlowLayoutPanel> outputList = new List<CardFlowLayoutPanel>();


            foreach(CardFlowLayoutPanel card in cardList){
                if (card.IncrementCommissionsFinished()){
                    outputList.Add(card);
                    this.cardList.Remove(card);
                }
            }

            return outputList;
        }

        //  When we add a range, we will set the position of everything, make sure they're all accurate.
        //  We also ensure that priority is set correctly. A code review will determine the necessity of this.
        public void AddRange(List<CardFlowLayoutPanel> inputCardList){
            this.cardList.AddRange(inputCardList);

            for (int i = 0; i < cardList.Count; ++i)
            {
                cardList.ElementAt(i).SetPosition(i);
                cardList.ElementAt(i).SetPriority(i);
            }
        }

        public void Add(CardFlowLayoutPanel inputCard) {
            this.cardList.Add(inputCard);
            inputCard.SetPosition(this.cardList.Count);
        }

        public void Insert(CardFlowLayoutPanel inputCard, int index) {

        }

        //Usage for Form-Based deletion method.
        public void DeleteCardAtPosition(int position) {
            this.cardList.RemoveAt(position);
            for (int i = position; i < this.cardList.Count; ++i) {
                cardList.ElementAt(i).ReducePosition();
            }
        }
    }
}

