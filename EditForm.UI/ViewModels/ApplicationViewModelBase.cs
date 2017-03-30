using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditForm.UI.ViewModels
{
    public class ApplicationViewModelBase : ViewModelBase
    {
        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                base.RaisePropertyChanged();
            }
        }
    }
}