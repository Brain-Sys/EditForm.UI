using EditForm.UI.Models;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditForm.UI.ViewModels
{
    public class MainViewModel : ApplicationViewModelBase
    {
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Region> Regions { get; set; } = new ObservableCollection<Region>();

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                base.RaisePropertyChanged();
            }
        }

        public RelayCommand StartEditCommand { get; set; }

        public MainViewModel()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            this.StartEditCommand = new RelayCommand(startEditCommandExecute, startEditCommandCanExecute);

            this.Regions.Add(new Region("Lombardia"));
            this.Regions.Add(new Region("Piemonte"));
            this.Regions.Add(new Region("Veneto"));
            this.Regions.Add(new Region("Trentino Alto Adige"));
            this.Regions.Add(new Region("Valle d'Aosta"));
            this.Regions.Add(new Region("Friuli Venezia Giulia"));

            this.People.Add(new Person() { Name = "Matteo", Surname = "Rossi", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
            this.People.Add(new Person() { Name = "Mario", Surname = "Bianchi", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
            this.People.Add(new Person() { Name = "Francesca", Surname = "Verdini", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
            this.People.Add(new Person() { Name = "Tiziana", Surname = "Callegari", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
            this.People.Add(new Person() { Name = "Mauro", Surname = "Stefalli", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
            this.People.Add(new Person() { Name = "Roberta", Surname = "Mauro", BirthDate = DateTime.Now.AddDays(rnd.Next(-60, +60)) });
        }

        private bool startEditCommandCanExecute()
        {
            return this.SelectedPerson != null;
        }

        private void startEditCommandExecute()
        {
            this.IsEditing = !this.IsEditing;
        }
    }
}