using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URM_Code.operations;
namespace URM_Code.operations
{
    class Execution
    {
        /**********************************************************************************
        *this class is Responsible for Executing the Code in the "Load class" Array named *
        *"CodeArray" operations Summerized in:                                            *
        *1-(Successor-Jump-Transfer-Zero) occurs on Registers Data                        *
        *2-(Analyse the Code-choose which Function to operate)                            *
        ***********************************************************************************/
        #region PublicFunctions
        /**********************Manipulate**********************************
        * Manipulate_Code(string CodeLine)                                *
        * is used to splite the current(passed) line code and store into  *
        * char array named "codeLine"                                     *
        ******************************************************************/

        public string Manipulate_Code(string CodeLine)
        {
                char[] trimchars = new char[] { ' ', '(', ')', ';', ',' };
                CodeLine = StringOperations.RemoveChars(CodeLine, trimchars);
                return CodeLine;
        }
        public void Execute(string CharSummary, ref Load obj, ref GroupBox gb, ref int iterat)
        {
            if (CharSummary[0] == 'Z' || CharSummary[0] == 'z')
            {
                Zero(CharSummary[1], ref obj, ref gb);
            }
            else if (CharSummary[0] == 'S' || CharSummary[0] == 's')
            {
                Successor(CharSummary[1], ref obj, ref gb);
            }
            else if (CharSummary[0] == 'T' || CharSummary[0] == 't')
            {
                Trans(CharSummary[1], CharSummary[2], ref obj, ref gb);
            }
            else if (CharSummary[0] == 'J' || CharSummary[0] == 'j')
            {
                jumb(CharSummary[1], CharSummary[2], CharSummary[3], ref obj, ref iterat);
            }
            else
                return;
        }
        #endregion
        #region PrivateFunctions
        /******************* Funcitions-Documentation ***********************
        *- obj: is where the Function get or set the Data of Register       *
        * and is passed by Ref to apply the modification to the original    *
        * Load object.                                                      *
        *-gb: is the group box that contain the textbox controls            *
        * that Represent the Registers(set Data or Show its Contained Value *
        * passed by Ref to apply changes to the original controls(textbox's)*
        *********************************************************************/
        /******************************Zero**********************************
        * Zero(char RegNumber,,ref Load obj,ref GroupBox gb) Function is    *
        * used to convert the Register Value Form n to zero                 *
        *- RegNumber: Represent the Index of Register place in memory       *
        ********************************************************************/
        private void Zero(char RegNumber, ref Load obj, ref GroupBox gb)
        {
            int index = int.Parse(RegNumber.ToString());
            obj.Set_RegArray(index, "0"); 
        }
        /***************************Successor***********************************
        * Successor(char RegNumber, ref Load obj, ref GroupBox gb) Function is *
        * used to increase the current value in Register by 1                  *
        *- RegNumber: Represent the Index of Register place in memory          *
        ************************************************************************/
        private void Successor(char RegNumber, ref Load obj, ref GroupBox gb)
        {
            int index = int.Parse(RegNumber.ToString());
            int Regvalue = obj.Get_RegArray(index);
            Regvalue++;
            obj.Set_RegArray(index, Regvalue.ToString()); 
        }
        /********************************* Trans *********************************************
        *Trans(char Reg1_Number, char Reg2_Number, ref Load obj, ref GroupBox gb) Function is*
        *used to Transfere the value from Reg1_number and place it Reg2_Number               *
        *RegNumber: Represent the Index of Register place in memory                          *
        *************************************************************************************/
        private void Trans(char Reg1_Number, char Reg2_Number, ref Load obj, ref GroupBox gb)
        {
            int Reg1_index = int.Parse(Reg1_Number.ToString());
            int Reg2_index = int.Parse(Reg2_Number.ToString());
            int temp = obj.Get_RegArray(Reg1_index);
            obj.Set_RegArray(Reg2_index, temp.ToString()); 
        }
        /**************************************** Jumb *********************************************
        * jumb(char Reg1_Number, char Reg2_Number, char GotoLineN, ref Load obj, ref int iterat)   *
        * this Function is used to act like if so if(Reg1_Number's values==Reg2_Number's values)   *
        *  it will execute the line with index (GotoLineN) and keep executing the Sequence again   *
        *-Regn_Number: Represent the Index of Register place in memory     n=(1 or 2)              *
        *-GotoLineN: Represent the number of line that it will be executed if the Condition is True*
        *-iterat:Represent the current value of execution iterator, is passed by ref to be able to *
        *  Modify it's value to the "GotoLineN" value which Represent the Line number that will be *
        *  executed if the Condition is true                                                       *
        *******************************************************************************************/
        private void jumb(char Reg1_Number, char Reg2_Number, char GotoLineN, ref Load obj, ref int iterat)
        {
            int Reg1_index = int.Parse(Reg1_Number.ToString());
            int Reg2_index = int.Parse(Reg2_Number.ToString());
            int temp1 = obj.Get_RegArray(Reg1_index);
            int temp2 = obj.Get_RegArray(Reg2_index);
            if (temp1 == temp2)
            {
                iterat = int.Parse(GotoLineN.ToString()) - 2;
            }
        }
        #endregion
    }
}
