using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditForm.UI.Models
{
    public class Person : ObservableObject
    {
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; base.RaisePropertyChanged(); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; base.RaisePropertyChanged(); }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; base.RaisePropertyChanged(); }
        }

        private bool married;
        public bool Married
        {
            get { return married; }
            set { married = value; base.RaisePropertyChanged(); }
        }

        private Region region;
        public Region Region
        {
            get { return region; }
            set { region = value; base.RaisePropertyChanged(); }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Surname}";
        }
    }
}