using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfNotepad.Models
{
    public class DocumentModel : ObservableObject
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                //onproperty will set the value for us rather then 2 steps
                OnPropertyChanged(ref _filePath, value);
            }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                //onproperty will set the value for us rather then 2 steps
                OnPropertyChanged(ref _fileName, value);
            }
        }

        /*  This flag will be used to check the fileName and FilePath is empty
         *   or has not been saved 
         */
        public bool isEmpty
        {
            get
            {
                if(string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))               
                    return true;
                

                return false;
            }
        }
   }
}
