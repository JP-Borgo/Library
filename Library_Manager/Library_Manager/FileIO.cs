using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Library_Manager
{
    /// <summary>
    /// purpose:FileIO class read and write
    /// </summary>
    class FileIO : Object, IFileAccess
    {
        private static SortedDictionary<uint, User> _user;
        private static SortedDictionary<string, Media> _media;
        private SaveFileDialog _saveFileDlg;
        private OpenFileDialog _openFileDlg;
        private FileStream _fs;
        private StreamWriter _sw;
        private long _StreamWriter_File_Pointer;
        private StreamReader _sr;
        private long _BinaryWriter_File_Pointer;
        private string _FileName;
        /// <summary>
        /// purpose:default constructor
        /// </summary>
        public FileIO()
        {
            _fs = null;
            _sw = null;
            _sr = null;
            _FileName = null;
            DB = new SortedDictionary<uint, User>();
        }
        /// <summary>
        /// Purpose: if empty throw exception
        /// </summary>
        public bool IsEmpty
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>
        /// purpose: use sortedDictionary User
        /// </summary>
        public SortedDictionary<uint, User> DB
        {
            get
            {
                //throw new NotImplementedException();
                return _user;
            }

            set
            {
                //throw new NotImplementedException();
                _user = value;
            }
        }        
        /// <summary>
        /// purpose: Open and write
        /// </summary>
        /// <param name="rto">Rtb_outPut</param>
        public void OpenFileStreamWrite(RichTextBox rto)
        {
            _saveFileDlg = new SaveFileDialog();
            _saveFileDlg.Filter = "All Files *.*|*.*|Text Files *.txt|*.txt|Binary Files *.bin|*.bin|Serialized Files *.ser|*.ser|Special Type *.spc|*.spc";
            _saveFileDlg.FilterIndex = 1;
            DialogResult result = _saveFileDlg.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            _FileName = _saveFileDlg.FileName;
            _fs = new FileStream(_FileName, FileMode.Create, FileAccess.ReadWrite);
        }
        /// <summary>
        /// purpose:open and read
        /// </summary>
        /// <param name="rtw">Rtb_outPut</param>
        public void OpenFileStreamRead(RichTextBox rto)
        {
            _openFileDlg = new OpenFileDialog();
            _openFileDlg.Filter = "All Files *.*|*.*|Text Files *.txt|*.txt|Binary Files *.bin|*.bin|Serialized Files *.ser|*.ser|Special Type *.spc|*.spc";
            _openFileDlg.FilterIndex = 1;
            DialogResult result = _openFileDlg.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            _FileName = _openFileDlg.FileName;
            _fs = new FileStream(_FileName, FileMode.Open, FileAccess.Read);
        }
        /// <summary>
        /// Purpose:Writ eContract To TextFile
        /// </summary>
        /// <param name="contr">Contract</param>
        public void WriteBookToTextFile(Media medi)
        {
            _sw = new StreamWriter(_fs);
            //rtw.AppendText("-------- StreamWriter Open -----------\r\n");
            //rtw.AppendText("Open File Pointer -> " + _fs.Position + "\r\n");
            _sw.WriteLine(medi.MediaType);
            _sw.WriteLine(medi.MediaID);
            _sw.WriteLine(medi.MediaName);
            _sw.WriteLine(medi.CheckOutDate);
            _sw.Flush();
            _fs.Flush();
            _StreamWriter_File_Pointer = _fs.Position;
        }        
        public void ReadBookTextFile(RichTextBox rtr)
        {
            _fs.Seek(_BinaryWriter_File_Pointer, SeekOrigin.Begin);
            _sr = new StreamReader(_fs);
            rtr.AppendText("-------- StreamReader Open -----------\r\n");
            rtr.AppendText("Open File Pointer -> " + _fs.Position + "\r\n");
            bool status = _fs.CanSeek;
            _fs.Seek(0, SeekOrigin.Begin);
            rtr.AppendText("After Seek File Pointer -> " + _fs.Position + "\r\n");
            string stgKind = _sr.ReadLine();
            int ival = int.Parse(_sr.ReadLine());
            string stgName = _sr.ReadLine();
            string stgLastName = _sr.ReadLine();
            double dval = double.Parse(_sr.ReadLine());
            char cval = char.Parse(_sr.ReadLine());
            bool bval = bool.Parse(_sr.ReadLine());
            rtr.AppendText(stgKind + "\r\n");
            rtr.AppendText("" + ival + "\r\n");
            rtr.AppendText(stgName + " " + stgLastName + "\r\n");
            rtr.AppendText("" + dval + "\r\n");
            rtr.AppendText("" + cval + "\r\n");
            rtr.AppendText("" + bval + "\r\n");
            rtr.AppendText("After Write File Pointer -> " + _fs.Position + "\r\n");
        }        
        /// <summary>
        /// purpose:closeTextFile
        /// </summary>
        public void closeTextFile()
        {
            _fs.Close();
        }
        /// <summary>
        /// purpose: open dialog box and save data
        /// </summary>
        public void writeDB()
        {
            //ask user for name of file
            _saveFileDlg = new SaveFileDialog();
            _saveFileDlg.Filter = "All Files *.*|*.*|Text Files *.txt|*.txt|Binary Files *.bin|*.bin|Serialized Files *.ser|*.ser|Special Type *.spc|*.spc";
            _saveFileDlg.FilterIndex = 1;
            DialogResult result = _saveFileDlg.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            _FileName = _saveFileDlg.FileName;
            _fs = new FileStream(_FileName, FileMode.Create, FileAccess.ReadWrite);

            //loop through the SortedDictionary
            foreach (User u in DB.Values)
            {
               /* if (u.UserType == UserType.ADULT)
                {
                    WriteUserToTextFile((ADULT)u);
                }
                else if (u.UserType == UserType.CHILDREN)
                {
                    WriteHourlyToTextFile((Hourly)emp);
                }*/
            }
            _fs.Close();
        }
        /// <summary>
        /// purpose:open dialog box and open file
        /// </summary>
        public void readDB()
        {
            //ask user for the file name

            _openFileDlg = new OpenFileDialog();
            _openFileDlg.Filter = "All Files *.*|*.*|Text Files *.txt|*.txt|Binary Files *.bin|*.bin|Serialized Files *.ser|*.ser|Special Type *.spc|*.spc";
            _openFileDlg.FilterIndex = 1;
            DialogResult result = _openFileDlg.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            _FileName = _openFileDlg.FileName;
            _fs = new FileStream(_FileName, FileMode.Open, FileAccess.Read);
            _sr = new StreamReader(_fs);
            string line = _sr.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
               /* if (line == "CONTRACT")
                {
                    newContract.EmpID newContract = new Contract();
                    newContract.EmpID = uint.Parse(_sr.ReadLine());
                    newContract.EmpFirstName = _sr.ReadLine();
                    newContract.EmpLastName = _sr.ReadLine();
                    newContract.ConstractSalary = double.Parse(_sr.ReadLine());
                    DB[newContract.EmpID] = newContract;
                }
                 if (line == "CONTRACT")
                {
                    newContract.EmpID newContract = new Contract();
                    newContract.EmpID = uint.Parse(_sr.ReadLine());
                    newContract.EmpFirstName = _sr.ReadLine();
                    newContract.EmpLastName = _sr.ReadLine();
                    newContract.ConstractSalary = double.Parse(_sr.ReadLine());
                    DB[newContract.EmpID] = newContract;
                }*/
                
                line = _sr.ReadLine();
            }

            //close the file
            _fs.Close();
        }
        /// <summary>
        /// purpose: open DB throw new NotImplementedException();
        /// </summary>
        public void OpenDB()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// purpose: closeDB throw new NotImplementedException();
        /// </summary>
        public void closeDB()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// purpose: through interface IFileAccess to SortedDictionary
    /// </summary>
    interface IFileAccess
    {
        void writeDB();
        void readDB();
        void OpenDB();
        void closeDB();
        SortedDictionary<uint, User> DB { get; set; }
    }//end interface IFileAccess
}
