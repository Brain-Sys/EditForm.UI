using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditForm.UI.Controls
{
    public partial class EditField : UserControl
    {
        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        // Control to be used when the value is shown on the UI
        // Example : Label, TextBlock
        private FrameworkElement view;
        public FrameworkElement View
        {
            get { return view; }
            set { view = value; buildControl(value); }
        }

        // Control to be used when the value can be modified on the UI
        // Example : TextBox, CheckBox, ComboBox
        private FrameworkElement edit;
        public FrameworkElement Edit
        {
            get { return edit; }
            set { edit = value; buildControl(value, true); }
        }

        public EditField()
        {
            this.Flag = "IsEditing";
            InitializeComponent();
        }

        void buildControl(FrameworkElement ctl, bool forEdit = false)
        {
            if (forEdit == false)
            {
                Binding bnd = new Binding(this.Flag)
                {
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Converter = Application.Current.Resources["blnVis"] as IValueConverter,
                    ConverterParameter = "inv",
                    Mode = BindingMode.OneWay
                };

                ctl.SetBinding(FrameworkElement.VisibilityProperty, bnd);
            }
            else
            {
                Binding bnd = new Binding(this.Flag)
                {
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Converter = Application.Current.Resources["blnVis"] as IValueConverter,
                    Mode = BindingMode.TwoWay
                };

                ctl.SetBinding(FrameworkElement.VisibilityProperty, bnd);
            }

            if (ctl != null)
            {
                this.MainPanel.Children.Add(ctl);
            }
        }
    }
}