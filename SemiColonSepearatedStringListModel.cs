using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiColonSeparatedStringEditor
{
    public class SemiColonSepearatedStringListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        private string separatedString;
        public string SeparatedString
        {
            get
            {
                return separatedString;
            }
            set
            {
                separatedString = value;
                Notify("SeparatedString");
            }
        }

        public ObservableCollection<ItemModel> SeparatedList { get; set; } = new ObservableCollection<ItemModel>();

        public void SetString(string strval)
        {
            SeparatedList.Clear();
            foreach (var str in strval.Split(new char[] { ';' }))
            {
                SeparatedList.Add(new ItemModel { ItemValue = str });
            }
        }
        public void MergeString()
        {
            string sep = "";
            StringBuilder builder = new StringBuilder();
            foreach (var item in SeparatedList)
            {
                builder.Append(sep + item.ItemValue);
                sep = ";";
            }
            SeparatedString = builder.ToString();
        }
    }
}
