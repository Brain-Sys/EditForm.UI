using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EditForm.UI.Controls
{
    public partial class OldEditField : UserControl
    {
        private static char[] splitter = new char[] { ',' };

        private string view;
        public string View
        {
            get { return view; }
            set { view = value; buildControl(); }
        }

        private string edit;
        public string Edit
        {
            get { return edit; }
            set { edit = value; buildControl(true); }
        }

        public OldEditField()
        {
            InitializeComponent();
        }

        void buildControl(bool forEdit = false)
        {
            FrameworkElement ctl = null;

            if (forEdit == false)
            {
                Binding bnd = new Binding("IsNotEditing")
                {
                    Converter = Application.Current.Resources["blnVis"] as IValueConverter
                };

                string[] parts = this.View.Split(splitter);

                switch (parts[1].ToLower())
                {
                    case "textblock":
                        {
                            ctl = new TextBlock();
                            ctl.SetBinding(TextBlock.TextProperty, parts[0]);
                            ctl.SetBinding(TextBlock.VisibilityProperty, bnd);
                            break;
                        }
                }
            }
            else
            {
                Binding bnd = new Binding("IsEditing")
                {
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Converter = Application.Current.Resources["blnVis"] as IValueConverter,
                    Mode = BindingMode.TwoWay
                };

                string[] parts = this.Edit.Split(splitter);

                switch (parts[1].ToLower())
                {
                    case "textbox":
                        {
                            ctl = new TextBox();
                            ctl.SetBinding(TextBox.TextProperty, parts[0]);
                            ctl.SetBinding(TextBox.VisibilityProperty, bnd);
                            break;
                        }
                    case "datepicker":
                        {
                            ctl = new DatePicker();
                            ctl.SetBinding(DatePicker.SelectedDateProperty, parts[0]);
                            ctl.SetBinding(TextBox.VisibilityProperty, bnd);
                            break;
                        }
                    case "checkbox":
                        {
                            ctl = new CheckBox();
                            ctl.SetBinding(CheckBox.IsCheckedProperty, parts[0]);
                            ctl.SetBinding(CheckBox.VisibilityProperty, bnd);
                            break;
                        }
                    case "combobox":
                        {
                            ctl = new ComboBox();
                            ctl.SetBinding(ComboBox.SelectedItemProperty, parts[0]);
                            ctl.SetBinding(ComboBox.ItemsSourceProperty, parts[2]);
                            ctl.SetBinding(ComboBox.VisibilityProperty, bnd);
                            break;
                        }
                }
            }

            if (ctl != null)
            {
                this.MainPanel.Children.Add(ctl);
            }
        }
    }
}