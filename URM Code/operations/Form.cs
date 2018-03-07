using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace URM_Code.operations
{
    class Formop
    {
        #region file
        //Name
        public static string path = @"C:\Users\Mohamed\Desktop";
        public static string fileName = "Untitled";
        //NewFile
        public static void New(RichTextBox target)
        {

            if (target.Text != (File.Exists(path) ? File.ReadAllText(path) : string.Empty))
            {
                string message = string.Format("Do you want to save changes to {0}", fileName);
                DialogResult mbox = MessageBox.Show(message, "Notepad", MessageBoxButtons.YesNoCancel);
                if (mbox == DialogResult.Yes)
                {
                    Save(target);
                    target.Text = string.Empty;
                    fileName = "Untitled";
                }
                else if (mbox == DialogResult.No)
                {
                    target.Text = string.Empty;
                    fileName = "Untitled";
                }
            }
            else
            {
                target.Text = string.Empty;
                fileName = "Untitled";
            }
        }
        //SaveFile
        public static void Save(RichTextBox target)
        {
            if (File.Exists(path) == false)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //Extensions
                //sfd.Filter = "Text File(*.txt)|*.txt|All Files (*.*)|*.*";
                sfd.Filter = "Urm(*.urm)|*.urm|All Files (*.*)|*.*";
                sfd.Title = "Save File";
                //Directory
                //Default
                sfd.InitialDirectory = @"C:\Users\Mohamed\Desktop";
                //Selected Directory Restore ?
                sfd.RestoreDirectory = false;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = sfd.FileName;
                    File.WriteAllText(path, target.Text);
                    fileName = Path.GetFileName(path);
                }
            }
            else
            {
                File.WriteAllText(path, target.Text);
            }
        }
        //Save As
        public static void SaveAs(RichTextBox target)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //Extensions
           // sfd.Filter = "Text File(*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.Filter = "Urm(*.urm)|*.urm|All Files (*.*)|*.*";
            sfd.Title = "Save File";
            //Directory
            //Default
            sfd.InitialDirectory = @"C:\Users\Mohamed\Desktop";
            //Selected Directory Restore ?
            sfd.RestoreDirectory = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                path = sfd.FileName;
                File.WriteAllText(path, target.Text);
                fileName = Path.GetFileName(path);
            }
        }
        //OpenFile
        public static void open(RichTextBox target)
        {
            New(target);
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter= "Urm(*.urm)|*.urm|All Files (*.*)|*.*";
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                path = openfiledialog.FileName;
                target.Text = File.ReadAllText(path);
                fileName = Path.GetFileName(path);
            }
        }
        
        #endregion
    }
}
