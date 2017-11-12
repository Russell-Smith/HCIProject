using System;

namespace WindowsFormsApp1
{
    internal class CreateCard
    {
        private string pieceName, commissionerName, imgRootDir, note;
        private int priority;

        public CreateCard(String pieceName, String commissionerName, String imgRootdir, String note, int priority)
        {
            this.pieceName = pieceName;
            this.commissionerName = commissionerName;
            this.imgRootDir = imgRootDir;
            this.note = note;

            this.priority = priority;
        }
    }
}
