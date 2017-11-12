using System;

//used to create a file that stores all of the information held by the cards
//Cards will always follow the following format:
//[commissionerName] [pieceName] [imgRootDir] [note] [price] [priority] [initialPriority] 
//  [queuePosition] [completionCounter] [maxCompeltionCounter] \t\n
public class CardFileFactory
{
    static String CSONFile;
    public static void append(String card)
    {
        //The \t is so that the file will still be somewhat readable in notepad
        //\n is for notepad++
        CSONFile += card + "\t\n";
    }
}