using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfNotepad.Models;

namespace WpfNotepad.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        //Toolbar Commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        public void NewFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path2 = $"{path}\\EddiesNotePad\\";
            if(!Directory.Exists(path2)) Directory.CreateDirectory(path2);
            Document.FileName = "NewDocument.txt";
            Document.FilePath = path2;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {
            if (Document.Text == "") Document.Text = " ";
            File.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialogue = new SaveFileDialog();
            //shows only txt files in the save file dialog
            saveFileDialogue.Filter = "Text File (*.txt)|*.txt";

            if(saveFileDialogue.ShowDialog() == true)
            {
                DockFile(saveFileDialogue);
                File.WriteAllText(saveFileDialogue.FileName, Document.Text);
            }
        }

        private void OpenFile()
        {
            var openFileDialogue = new OpenFileDialog();
            if (openFileDialogue.ShowDialog() == true)
            {
                DockFile(openFileDialogue);
                Document.Text = File.ReadAllText(openFileDialogue.FileName);
            }
        }

        //Generic FileDialog for the 4 different ones needed.
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
