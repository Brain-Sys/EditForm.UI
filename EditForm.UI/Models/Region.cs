using GalaSoft.MvvmLight;

namespace EditForm.UI.Models
{
    public class Region : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                base.RaisePropertyChanged();
            }
        }

        public Region(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}