using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiColonSeparatedStringEditor
{
    public class ItemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        private string itemValue;
        public string ItemValue
        {
            get
            {
                return itemValue;
            }
            set
            {
                itemValue = value;
                Notify("ItemValue");
            }
        }
    }
}
