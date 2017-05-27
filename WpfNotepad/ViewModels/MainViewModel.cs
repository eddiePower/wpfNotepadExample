using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNotepad.Models;

namespace WpfNotepad.ViewModels
{
    public class MainViewModel
    {
        //both the file and document model share this single model
        private DocumentModel _document;

        public EditorViewModel Editor { get; set; }

        public FileViewModel File { get; set; }

        public HelpViewModel Help { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            Help = new HelpViewModel();
            Editor = new EditorViewModel(_document);
            File = new FileViewModel(_document);
        }

    }
}
