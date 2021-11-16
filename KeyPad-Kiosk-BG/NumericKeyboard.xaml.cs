using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace KeyPadNumeric_Kiosk_BG
{
    /// <summary>
    /// Interaction logic for NumericKeyboard.xaml
    /// </summary>
    public partial class NumericKeyboard : Window, INotifyPropertyChanged
    {

        #region Constants
        private const string BINDING_RESULT_PROPERTY_NUMERIC = "Result";

        #endregion



        #region Public Properties

        private string _resultContent;
        public string ResultContent
        {
            get { return _resultContent; }
            private set
            {
                _resultContent = value;
                OnPropertyChanged(BINDING_RESULT_PROPERTY_NUMERIC);
            }
        }


        private TextBox _resultTxt;

        public TextBox ResultTxt
        {
            get { return _resultTxt; }
            private set
            {
                _resultTxt = value; OnPropertyChanged(BINDING_RESULT_PROPERTY_NUMERIC);
            }
        }

        private PasswordBox _resultPasswordTxt;
        public PasswordBox ResultPasswordTxt
        {
            get { return _resultPasswordTxt; }
            private set
            {
                _resultPasswordTxt = value; OnPropertyChanged(BINDING_RESULT_PROPERTY_NUMERIC);
            }
        }
        #endregion

        public NumericKeyboard(TextBox owner, Window wndOwner, string resultContent,PasswordBox secondControl = null)
        {
            InitializeComponent();
            Owner = wndOwner;
            DataContext = this;
            ResultTxt = owner;
            ResultContent = resultContent;
            if (secondControl != null)
            {
                ResultPasswordTxt = secondControl;
            }

            Left = (wndOwner.Width / 2) - (Width / 2);
            Top = wndOwner.Height - Height;
        }



        private void closeKeyboard_Listener(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DialogResult = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.CommandParameter.ToString())
            {
                case "ESC":
                    DialogResult = false;
                    break;

                case "RETURN":
                    DialogResult = true;
                    break;

                case "BACK":
                    if (ResultContent.Length > 0)
                        ResultContent = ResultContent.Remove(ResultContent.Length - 1);
                    break;

                default:
                    ResultContent += button.Content.ToString();
                    break;
            }
            if (ResultPasswordTxt != null)
            {
                ResultPasswordTxt.Password = ResultContent;
            }
            else
            {
                ResultTxt.Text = ResultContent;
            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        private void Button_TouchLeave(object sender, TouchEventArgs e)
        {
            //•
        }

        private void buttonEsc_TouchLeave(object sender, TouchEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
