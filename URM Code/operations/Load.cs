using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URM_Code.operations
{
    public class Load : IDisposable
    {

        /****************************************************************
        *this class is Responsible for loading URM Code into storages   *
        *Arrays Excatly since it's a fixed Storage which acts like a    *
        *Memory                                                         *  
        *****************************************************************/
        #region fields
        //Registers Array
        /*********************************************************
        * Act like a Register , used to store values in Regsiters*
        * and Do operations on them                              *
        *********************************************************/
        int[] regArray;
        //Code Array
        /*****************************************************
        * used to store the Code Lines                       *
        ******************************************************/
        public string[] codeArray;
        /* this var Represents the line number when using the Next btn*/
        public int next;
        #endregion
        #region Properties
        #region RegArray
        //Properties
        /*************************************************************************************
        *this Condition make sure that passed index is not exceeds the limits of the RegArray*
        *************************************************************************************/
        public int Get_RegArray(int index)
        { 
            if (index < regArray.Length && index > -1)
            {
                return regArray[index];
            }
            else
                return -1;
        }
        /* This Property Return the whole values of the Reg Array 
         * used to view values in DataGrid View */
        public int[] GetAll_RegArray()
        {
                return regArray;
        }
        public void Set_RegArray(int index, string value)
        {
            if (index < regArray.Length && index > -1)
            {
                if (value != String.Empty)
                {
                    regArray[index] = int.Parse(value);
                }
            }

        }

        #endregion
        #region CodeArray;
        /**********************************************************
        * Condition must make sure that Dimension or the Length of * 
        * Dimension is not exceeding the limits                    *
        **********************************************************/
        public string Get_CodeArray( int Index)
        {
                if (Index < codeArray.Length && Index > -1)
                {
                    return codeArray[Index];
                }
                else
                    return null;
        }
        //Set
        public void Set_CodeArray(int Index, string value)
        {
                if (Index <= codeArray.Length && Index > -1)
                {
                    codeArray[Index] = value;
                }
        }
        #endregion
        #endregion
        #region Constructor
        public Load(int SizeOfArray)
        {
            regArray = new int[9];
            codeArray = new string[SizeOfArray];
            next = 0;
        }
        #endregion
        #region Functions
        /**************************************************************
        * Storing Values in the Arrays to Start opertation on them    *
        * STO_RegArray(txtR1,txtR2,........txtRn)                     *
        * its parameter Array to pass All Registers
        ***************************************************************/
        public void STO_RegArray(params string[] txtReg)
        {
            for (int i = 0; i < txtReg.Length; i++)
            {
                Set_RegArray(i+1,txtReg[i]);
            }
        }
        /**********************************************************************
        *storing values in CodeArray to be Ready For manipulating in next Step*
        *STO_CodeArray(Text Contains Number of line, rich Textbox contains    *
        *the Code);
        ***************************************************************/
        public void STO_CodeArray(string[] Code)
        {
            for (int i = 0 , m=codeArray.Length; i < m; i++)
            {
                Set_CodeArray(i, Code[i]);
            }
        }
        #endregion



        public void Dispose()
        {
            regArray = null;
            codeArray = null;
        }
    }
}

