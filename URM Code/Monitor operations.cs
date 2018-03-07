using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URM_Code.operations;
namespace URM_Code
{
    public partial class Monitor_operations : Form
    {
        frmMain obj;
        public Monitor_operations(frmMain obj)
        {
            InitializeComponent();
            this.obj= obj;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            if (obj.thread != null)
                obj.thread.Abort();
            Load_Data();
            this.Close();
        }
        private void Load_Data()
        {
           obj.loadData = new Load(obj.richtxtCode.Lines.Length);
           obj.loadData.STO_RegArray(obj.txtR1.Text, obj.txtR2.Text, obj.txtR3.Text, obj.txtR4.Text, obj.txtR5.Text, obj.txtR6.Text, obj.txtR7.Text, obj.txtR8.Text);
           obj.loadData.STO_CodeArray(obj.richtxtCode.Lines);
            //Enable buttons
           obj.btnExecute.Enabled = true;
           obj.btnNext.Enabled = true;
           obj.btnStop.Enabled = false;
        }
         
        public void CurrentLineResult()
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);
                for (int i = 1, n = obj.loadData.GetAll_RegArray().Length; i < n; i++)
                {
                    row.Cells[i - 1].Value = obj.loadData.Get_RegArray(i);
                } 
                if(dataGridView1.IsDisposed == false)
                if(dataGridView1.Parent.IsHandleCreated == true)
                dataGridView1.Invoke((MethodInvoker)delegate {  
                    dataGridView1.Rows.Add(row);
                });
            }
            catch(ArgumentOutOfRangeException)
            { 
                MessageBox.Show("Please Erase and load again"); 
            }
        }

  
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
        }
        public void ClearDataGrid()
        {
            this.dataGridView1.Rows.Clear();
        }
        public void Numberheaders()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            } 
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
     
        
        }

    }
}
