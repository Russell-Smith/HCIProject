namespace WindowsFormsApp1
{   
    //Class will be used to push information to the CradFlowLayoutPanel
    internal class EditCard
    {
        private string imgRootDirIn, noteIn, pieceNameIn;
        private int positionIn, priorityIn;

        public EditCard(string pieceNameIn, string imgRootDirIn, string noteIn, int priorityIn, int positionIn)
        {
            this.pieceNameIn = pieceNameIn;
            this.imgRootDirIn = imgRootDirIn;
            this.noteIn = noteIn;

            this.priorityIn = priorityIn;
            this.positionIn = positionIn;
        }
    }
}