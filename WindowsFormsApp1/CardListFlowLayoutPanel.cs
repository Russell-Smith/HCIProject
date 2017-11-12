﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class CardListFlowLayoutPanel : Panel
    {
        private List<CardFlowLayoutPanel> cardList;
        private int windowXSize, windowYSize;


        public CardListFlowLayoutPanel()
        {
            this.Size = new System.Drawing.Size(320, 320);
            this.Location = new System.Drawing.Point(10, 10);
        }

        public void OnParentResize(int newXSize, int newYSize){
            newXSize = newXSize - 20;
            newYSize = newYSize - 20;
        }
    }
}

