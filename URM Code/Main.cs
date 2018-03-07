using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using URM_Code.operations;
namespace URM_Code
{
    public partial class frmMain : Form
    {

        internal Load loadData;
        Monitor_operations monitor; bool monitor_obj_IsCreated = false;
        Execution executeCode = new Execution();
        int findPos = 0; //Belongs to FindNext Function
        private string execute(string[] Lines)
        {
                for (int i = 0, n = Lines.Count(); i < n; i++)
                {
                    string values = executeCode.Manipulate_Code(this.loadData.Get_CodeArray(i));
                    this.executeCode.Execute(values, ref this.loadData, ref grpbxRegisters, ref i);
                    monitor.CurrentLineResult();
                }
                return this.loadData.Get_RegArray(1).ToString();//Get the final value for the applied URM Code
        }
        private void Load_Data()
        {
            loadData = new Load(richtxtCode.Lines.Length);
            loadData.STO_RegArray(txtR1.Text, txtR2.Text, txtR3.Text, txtR4.Text, txtR5.Text, txtR6.Text, txtR7.Text, txtR8.Text);
            loadData.STO_CodeArray(richtxtCode.Lines);
            //Enable executing buttons
            btnExecute.Enabled = true;
            btnNext.Enabled = true;
            btnStop.Enabled = false;
            if (monitor != null)
                monitor.Close();
        }

        public frmMain()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (monitor != null)
                monitor = null;
             if (richtxtCode.Text == string.Empty)
                MessageBox.Show("There is nothing to Load !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
             {
                lblStat.Text = "Loading...";
                Load_Data();//Load Data
                lblStat.Text = "Ready";
                statusStrip1.BackColor = Color.Orange;
            }
        }
       public Thread thread;
        private void btnExecute_Click(object sender, EventArgs e)
        {
            monitor = new Monitor_operations(this);
            string Value = "";
            string[] lines = richtxtCode.Lines;

            thread = new Thread(() =>
            {
                if (loadData != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnExecute.Enabled = false;
                        btnStop.Enabled = true;
                        statusStrip1.BackColor = Color.Orange;
                        lblStat.Text = "Processing...";
                        this.monitor.Show();
                    });
                    Value = execute(lines);
                    this.Invoke((MethodInvoker)delegate
                    {
                        monitor.Numberheaders();
                        lblStat.Text = "Done";
                        statusStrip1.BackColor = Color.Green;
                        monitor.txtOutput.Text = loadData.Get_RegArray(1).ToString();
                    });

                }
                else
                MessageBox.Show("You must Load a Code First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
                thread.Start();       
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            
          if(loadData!=null)
          {
                if (monitor == null || monitor.txtOutput.Text == string.Empty)
                {
                    if (!monitor_obj_IsCreated)
                    {
                        if (monitor != null)
                            monitor = null;
                        if (monitor == null)
                        {
                            monitor = new Monitor_operations(this);
                            this.btnExecute.Enabled = false;
                            this.btnStop.Enabled = false;
                            monitor.Show();
                            monitor.BringToFront();
                        }
                        monitor_obj_IsCreated = true;
                    }
                    //richtxtCode.Enabled = false;
                    if (loadData.next < this.richtxtCode.Lines.Length)
                    {
                        StringOperations.Highlight(richtxtCode, richtxtCode.Lines[this.loadData.next], Color.Green);

                        string values = executeCode.Manipulate_Code(this.loadData.Get_CodeArray(this.loadData.next));
                        this.executeCode.Execute(values, ref this.loadData, ref grpbxRegisters, ref this.loadData.next);

                        monitor.CurrentLineResult();

                    }
                    else
                    {
                        // richtxtCode.Enabled = true;
                        this.monitor.txtOutput.Text = this.loadData.Get_RegArray(1).ToString();//Get the final value for the applied URM Code
                    }
                    loadData.next++;
                }
                else
                {
                    MessageBox.Show("Operation is done , Close the monitor window to be able to execute again !", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    monitor_obj_IsCreated = false;
                }
          }
          else 
          {
                MessageBox.Show("You must load a code first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
        #region numberOflines
        //Main Function of this block is to show how many lines in the Richtextbox
        //not an operational(Doesn't belong to the main 4 Functions Executions) code
        private void updateNumberLabel()
        {
            //we get index of first visible char and number of first visible line
            Point pos = new Point(0, 0);
            int firstIndex = richtxtCode.GetCharIndexFromPosition(pos);
            int firstLine = richtxtCode.GetLineFromCharIndex(firstIndex);

            //now we get index of last visible char and number of last visible line
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = richtxtCode.GetCharIndexFromPosition(pos);
            int lastLine = richtxtCode.GetLineFromCharIndex(lastIndex);

            //this is point position of last visible char, we'll use its Y value for calculating numberLabel size
            pos = richtxtCode.GetPositionFromCharIndex(lastIndex);


            //finally, renumber label
            numberLabel.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                numberLabel.Text += i + 1 + "\n";
            }

        }

        //TextChanged Event
        private void richtxtCode_TextChanged(object sender, EventArgs e)
        {
            updateNumberLabel();
            upadteCoordinates();
        }
        /****************************************
         * this function upadates the number of
         * Line and Column
         * **************************************/
        private void upadteCoordinates()
        {
            this.lblLn.Text = "Ln" + (richtxtCode.GetLineFromCharIndex(richtxtCode.SelectionStart) + 1);
            this.lblCol.Text = "Col" + ((richtxtCode.SelectionStart - richtxtCode.GetFirstCharIndexFromLine(richtxtCode.GetLineFromCharIndex(richtxtCode.SelectionStart))) + 1);
        }
        private void richtxtCode_VScroll(object sender, EventArgs e)
        {
            //move location of numberLabel for amount of pixels caused by scrollbar
            int d = richtxtCode.GetPositionFromCharIndex(0).Y % (richtxtCode.Font.Height + 1);
            numberLabel.Location = new Point(0, d);

            updateNumberLabel();
        }

        private void richtxtCode_Resize(object sender, EventArgs e)
        {
            richtxtCode_VScroll(null, null);
        }

        private void richtxtCode_FontChanged(object sender, EventArgs e)
        {
            updateNumberLabel();
            richtxtCode_VScroll(null, null);
        }
        //Updating Coordinates
        private void richtxtCode_MouseClick(object sender, MouseEventArgs e)
        {
            upadteCoordinates();
        }

        private void richtxtCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Right || e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                upadteCoordinates();
            }
        }
        #endregion
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formop.New(richtxtCode);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formop.open(richtxtCode);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formop.Save(richtxtCode);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formop.SaveAs(richtxtCode);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.SelectedText = "";
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = true;
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlReplace.Visible = true;
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richtxtCode.Text == string.Empty)
                MessageBox.Show("There is nothing to Load !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                loadData = new Load(richtxtCode.Lines.Length);
                Load_Data();
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            monitor = new Monitor_operations(this);
            string Value = "";
            string[] lines = richtxtCode.Lines;

            thread = new Thread(() =>
            {
                if (loadData != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        btnExecute.Enabled = false;
                        btnStop.Enabled = true;
                        statusStrip1.BackColor = Color.Orange;
                        lblStat.Text = "Processing...";
                        this.monitor.Show();
                    });
                    Value = execute(lines);
                    this.Invoke((MethodInvoker)delegate
                    {
                        monitor.Numberheaders();
                        lblStat.Text = "Done";
                        statusStrip1.BackColor = Color.Green;
                        monitor.txtOutput.Text = loadData.Get_RegArray(1).ToString();
                    });

                }
                else
                    MessageBox.Show("You must Load a Code First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
            thread.Start();
        }
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = true;
            }
            else
                statusStrip1.Visible = false;
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\Resources\User-Manual.chm");
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text != string.Empty)
            {
                FindNext(txtFind.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlFind.Visible = false;
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            pnlReplace.Visible = false;
        }


        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (txtReplaceTxt1.Text != string.Empty && txtReplaceTxt2.Text != string.Empty)
            {
                richtxtCode.Find(txtReplaceTxt1.Text);
                richtxtCode.Select();
                richtxtCode.SelectedText = richtxtCode.SelectedText.Replace(richtxtCode.SelectedText, txtReplaceTxt2.Text);
            }
        }
        

        /*****************************************************************
         *this Function is used to Find the specified Text in RichTextBox*
         *which exits in a Form(this)                                    *
         * FindNext(string searchText)                                   *
         * searchText is the text that want to find                      *
         * ***************************************************************/
        public void FindNext(string searchText)
        {

            try
            {
                this.Focus();
                this.richtxtCode.Focus();
                findPos = richtxtCode.Find(searchText, findPos, RichTextBoxFinds.None);
                richtxtCode.Select(findPos, searchText.Length);
                findPos += searchText.Length;
            }
            catch
            {
                findPos = 0;
            }
        }
        private void btnExecute_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Execute", btnExecute);
        }

        private void btnLoad_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Load", btnLoad);
        }

        private void btnScNew_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("New File", btnScNew);
        }

        private void btnScOpen_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Open File", btnScOpen);
        }

        private void btnScSave_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Save File", btnScSave);
        }

        private void btnScExit_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Exit :(", btnExit);
        }
        private void btnScPaste_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Paste", btnScPaste);
        }

        private void btnScCopy_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Copy", btnScCopy);
        }

        private void btnScCut_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Cut", btnScCut);
        }
        private void btnClearAll_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Clear All", btnClearAll);
        }

        private void btnNext_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Next Step", btnNext);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (richtxtCode.Text != string.Empty)
            {
                if (richtxtCode.Text != string.Empty)
                {
                    DialogResult dr = MessageBox.Show("Do you want to Exit", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }

            }
            else
                Application.Exit();

        }
        private void btnScCut_Click(object sender, EventArgs e)
        {
            richtxtCode.Cut();
        }

        private void btnScCopy_Click(object sender, EventArgs e)
        {
            richtxtCode.Copy();
        }

        private void btnScPaste_Click(object sender, EventArgs e)
        {
            richtxtCode.Paste();
        }
        private void btnScNew_Click(object sender, EventArgs e)
        {
            Formop.New(richtxtCode);
            lblStat.Text = "Project Created";
            statusStrip1.BackColor = Color.DodgerBlue;
        }

        private void btnScOpen_Click(object sender, EventArgs e)
        {
            Formop.open(richtxtCode);
            lblStat.Text = "File opened";
            statusStrip1.BackColor = Color.DodgerBlue;
        }

        private void btnScSave_Click(object sender, EventArgs e)
        {
            Formop.Save(richtxtCode);
            lblStat.Text = "Saved";
            statusStrip1.BackColor = Color.DodgerBlue;
        }
        private void btnMonitor_Click(object sender, EventArgs e)
        {


        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                grpbxRegisters.Controls["txtR" + (i).ToString()].Text = string.Empty;
            }
            richtxtCode.Text = string.Empty;
            loadData = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.monitor.ClearDataGrid();
            lblStat.Text = "Cleared";
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richtxtCode.SelectAll();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnExecute.Enabled = true;
            btnStop.Enabled = false;
            btnNext.Enabled = true;
            if (thread != null)
                thread.Abort();
            this.monitor.Close();
            Load_Data();
        }
        private void btnStop_MouseHover(object sender, EventArgs e)
        {
            ToolTipDx.Show("Stop", btnStop);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExecute.Enabled = true;
            btnStop.Enabled = false;
            btnNext.Enabled = true;
            if (thread != null)
                thread.Abort();
            this.monitor.Close();
            Load_Data();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new about()).Show();
        }

    }
}
