using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfNotepad
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        /* Using a generic <T> not always the same 
         * data type so using a generic.
         * CallerMember will get the name of the calling member like method name
         */    
        public void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string PropertyName = "")
        {
            property = value;
            var handler = PropertyChanged;
            if(handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
