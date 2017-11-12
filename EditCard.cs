namespace WindowsFormsApp1
{
    internal class EditCard
    {
        private String pieceName, imgRootDir, note;
        private int priority, position;

        public EditCard(String pieceName, String imgRootDir, String note, int priority, int position)
        {
            this.pieceName = pieceName;
            this.imgRootDir = imgRootDir;
            this.note = note;

            this.priority = priority;
            this.position = position;
        }
    }
}
