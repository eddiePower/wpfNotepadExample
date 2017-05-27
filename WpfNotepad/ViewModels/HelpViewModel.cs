using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfNotepad.ViewModels
{
    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayAbout);
        }

        private void DisplayAbout()
        {
            //open help dialog
            const string message = "EddiesNotePad is a wordProcesser made by Eddie Power as a learing exorcise into WPF the C# visual mark up language. this is a minimal wp and not ment for main stream useage.";
            const string heading = "About Eddies WordProcessor - EddiesNotePad Version 0.1.1";
            var result = MessageBox.Show(message, heading, MessageBoxButton.OK); 
        }
    }
}
