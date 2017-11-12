namespace WindowsFormsApp1
{
    //Class will be used to push information to the CradFlowLayoutPanel
    internal class CreateCard
    {
        private string pieceName, commissionerName, imgRootDir, note;
        private int priority;

        public CreateCard(string pieceName, string commissionerName, string imgRootDir, string note, int priority)
        {
            this.pieceName = pieceName;
            this.commissionerName = commissionerName;
            this.imgRootDir = imgRootDir;
            this.note = note;

            this.priority = priority;
        }
    }
}