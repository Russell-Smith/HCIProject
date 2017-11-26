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
        private int priority;


        public CardListFlowLayoutPanel(int priority)
        {
            this.Size = new System.Drawing.Size(360, 800);
            this.Location = new System.Drawing.Point((priority * 370), 0);
            this.priority = priority;
            if(this.priority > 0){
                this.Visible = false;
            }
            this.cardList = new List<CardFlowLayoutPanel>();
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutoScroll = true;
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
            this.Controls.AddRange(inputCardList.ToArray());

            for (int i = 0; i < cardList.Count; ++i)
            {
                this.cardList.ElementAt(i).SetPosition(i);
                this.cardList.ElementAt(i).SetPriority(priority);
                this.cardList.ElementAt(i).Location = new System.Drawing.Point(20, 20 + (i * 160));
            }
        }

        public void Add(CardFlowLayoutPanel inputCard) {
            this.cardList.Add(inputCard);
            this.Controls.Add(inputCard);
            inputCard.SetPosition(this.cardList.Count - 1);
            inputCard.Location = new System.Drawing.Point(20, 20 + (inputCard.GetPosition() * 160));
            inputCard.BackColor = System.Drawing.Color.Black;
            inputCard.Visible = true;
            
        }

        public CardFlowLayoutPanel ElementAt(int index) {
            return this.cardList.ElementAt(index);
        }

        //  Insert a card, then increment every card behind it's location.
        public void Insert(CardFlowLayoutPanel inputCard, int index) {
            if (index < cardList.Count)
            {
                Console.WriteLine("Index was within cardListCount.");
                this.cardList.Insert(index, inputCard);
                this.Controls.Add(inputCard);
                int i = 0;
                foreach (CardFlowLayoutPanel card in cardList)
                {
                    card.Location = new System.Drawing.Point(20, 20 + (i * 160));
                    i += 1;
                }
            }
            else
            {
                Console.WriteLine("Index was outside of cardListCount.");
                cardList.Add(inputCard);
                this.Controls.Add(inputCard);
                inputCard.SetPosition(cardList.Count - 1);
                inputCard.Location = new System.Drawing.Point(20, 20 + (inputCard.GetPosition() * 160));
                inputCard.Visible = true;
            }
        }

        //  Move a card that already exists, then increment every card behind it's location.
        public void MoveCard(int oldIndex, int newIndex) {
            CardFlowLayoutPanel tempCard = cardList.ElementAt(oldIndex);
            if (newIndex > cardList.Count)
            {
                cardList.RemoveAt(oldIndex);
                cardList.Add(tempCard);
            }
            else
            {
                cardList.RemoveAt(oldIndex);
                cardList.Insert(newIndex, tempCard);
            }
            //  This currently increases positions of all cards behind a card. Let's just index them all to the list.
            //  It's slow. It's literally n. Fuck it.
            for (int i = 0; i < cardList.Count; ++i)
            {
                this.cardList.ElementAt(i).SetPosition(i);
                this.cardList.ElementAt(i).Location = new System.Drawing.Point(20, 20 + (i * 160));
            }
        }

        //  Usage for Form-Based deletion method.
        //  Remove from Controls list as well.
        public void DeleteCardAtPosition(int position) {
            try
            {
                this.Controls.Remove(this.cardList.ElementAt(position));
                this.cardList.RemoveAt(position);
                for (int i = position; i < this.cardList.Count; ++i)
                {
                    cardList.ElementAt(i).ReducePosition();
                    this.cardList.ElementAt(i).Location = new System.Drawing.Point(20, 20 + (i * 160));
                }
                
            } catch (Exception ex) {
                Console.WriteLine("Apparently we had an issue. " + position + " was probably out of bounds.\n" + ex.Message);
            }
        }
    }
}

