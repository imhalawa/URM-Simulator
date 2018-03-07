using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace URM_Code.operations
{
    class StringOperations
    {
        static int startIndex = 0;
        public static string RemoveChars(string Text, params char[] CharsToDelete)
        {
            char[] temp = new char[Text.Length];
            //Assign the String named "Text" chars' to temp char array to modify the chars 
            //since the string type is readonly array of char
            for (int i = 0; i < Text.Length; i++)
                temp[i] = Text[i];
            //Comparing chars in Temp by passed chars to delete them if exist
            for (int i = 0; i < CharsToDelete.Length; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    if (CharsToDelete[i] == temp[j])
                        temp[j] = '\0';
                }
            }
            Text = ""; //preparing to hold the modified string
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != '\0')
                    Text += temp[i];
            }
            return Text;
        }
        public static void Highlight(RichTextBox myRtb,string Line,Color color)
        {
                myRtb.SelectionBackColor = Color.White;
                myRtb.Focus();
                startIndex = myRtb.Find(Line, startIndex, RichTextBoxFinds.None);//Returns the start index of specific Line
                if (startIndex > -1) 
                {
                    
                    myRtb.Select(startIndex, Line.Length);//Select a line using it's Length and its StartIndex
                    startIndex += Line.Length;
                }
                else if (startIndex < 0) // Fixes the Argument Exception
                {
                    startIndex = 0;
                    Highlight(myRtb, Line,color);//Call it again to highlight the Line 
                }
        }
    }
}
