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


        #region additional properties

        private string lastResultContent { get; set; }
        public bool windowVisible { get; set; }
        public int indexCharacterToInsert { get; set; }
        public bool enabledSelectionChange { get; set; }
        public bool keyPressedAccepted { get; set; }



        #endregion


        public NumericKeyboard()
        {
            windowVisible = false;
            indexCharacterToInsert = 0;
            enabledSelectionChange = true;
            keyPressedAccepted = true;
        }

        public NumericKeyboard(TextBox owner, Window wndOwner, string resultContent, PasswordBox secondControl = null)
        {
            InitializeComponent();
            Owner = wndOwner;
            DataContext = this;
            ResultTxt = owner;
            ResultContent = resultContent;
            lastResultContent = "";
            if (secondControl != null)
            {
                ResultPasswordTxt = secondControl;
            }

            Left = (wndOwner.Width / 2) - (Width / 2);
            Top = wndOwner.Height - Height;

            windowVisible = true;
            indexCharacterToInsert = 0;
            enabledSelectionChange = true;
            keyPressedAccepted = true;
        }



        private void closeKeyboard_Listener(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            windowVisible = false;
            Hide();
            //Close();
            //DialogResult = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            switch (button.CommandParameter.ToString())
            {
                case "ESC":
                    windowVisible = false;
                    Hide();
                    //Close();
                    //DialogResult = false;
                    break;

                case "RETURN":
                    windowVisible = false;
                    Hide();
                    //Close();
                    //DialogResult = true;
                    break;

                case "BACK":
                    lastResultContent = ResultContent;
                    if (ResultContent.Length > 0 && indexCharacterToInsert > 0)
                    {
                        ResultContent = ResultContent.Remove(indexCharacterToInsert - 1, 1);
                        indexCharacterToInsert--;
                    }
                    enabledSelectionChange = false;
                    //ResultContent = ResultContent.Remove(ResultContent.Length - 1

                    if (keyPressedAccepted)
                    {
                    }
                    break;

                default:
                    lastResultContent = ResultContent;
                    ResultContent = ResultContent.Insert(indexCharacterToInsert++, button.Content.ToString());
                    enabledSelectionChange = false;

                    if (keyPressedAccepted)
                    {
                    }
                    //ResultContent += button.Content.ToString();
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

        public void applyValidations(bool backPressed)
        {
            if (backPressed)
            {
                indexCharacterToInsert++;
            }
            else
            {
                indexCharacterToInsert--;
            }
            ResultContent = lastResultContent;

            if (ResultPasswordTxt == null)
            {
                ResultTxt.Text = ResultContent;
            }
            else
            {
                ResultPasswordTxt.Password = ResultContent;
            }


        }
    }
}
