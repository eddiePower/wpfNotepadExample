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
        }

        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {
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

        //
        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }

       /* private void DockFile(FileDialog fileDialogue)
        {
            Document.FilePath = fileDialogue.FileName;
            Document.FileName = fileDialogue.SafeFileName;          
        }*/

    }
}
