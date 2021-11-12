using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace KeyPadQWERTY_Kiosk_BG
{
    /// <summary>
    /// Interaction logic for QwertyKeyboard.xaml
    /// </summary>
    public partial class QwertyKeyboard : Window, INotifyPropertyChanged
    {

        #region "Constants"
        private const string BINDING_RESULT_PROPERTY_QWERTY = "Result";


        #endregion
        #region Public Properties

        private bool _showNumericKeyboard;
        public bool ShowNumericKeyboard
        {
            get { return _showNumericKeyboard; }
            set
            {
                _showNumericKeyboard = value;
                OnPropertyChanged("ShowNumericKeyboard");
            }
        }

        private string _resultContent;
        public string ResultContent
        {
            get { return _resultContent; }
            private set
            {
                _resultContent = value;
                OnPropertyChanged(BINDING_RESULT_PROPERTY_QWERTY);
            }
        }


        private TextBox _resultTxt;
        public TextBox ResultTxt
        {
            get { return _resultTxt; }
            private set
            {
                _resultTxt = value; OnPropertyChanged("Result");
            }
        }

        #endregion

        #region Constructor

        public QwertyKeyboard(TextBox owner, Window wndOwner)
        {
            InitializeComponent();
            Owner = wndOwner;
            DataContext = this;
            ResultTxt = owner;
            ResultContent = "";
        }

        #endregion

        #region Callbacks

        private void closeKeyboard_Listener(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DialogResult = false;
        }
        private void Button_TouchLeave(object sender, RoutedEventArgs e)
        {
            //e.Handled = false;
            /*Button button = sender as Button;
            button.Background = Brushes.Azure;
            button.Focusable = false;
            e.Handled = true;*/
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                switch (button.CommandParameter.ToString())
                {
                    case "LSHIFT": // Cast Lowwer case | Upper case
                        Regex upperCaseRegex = new Regex("[A-Z\u00d1]");
                        Regex lowerCaseRegex = new Regex("[a-z\u00f1]");
                        Button btn;
                        foreach (UIElement elem in AlfaKeyboard.Children) //iterate the main grid
                        {
                            Grid grid = elem as Grid;
                            if (grid != null)
                            {
                                foreach (UIElement uiElement in grid.Children)  //iterate the single rows
                                {
                                    btn = uiElement as Button;
                                    if (btn != null) // if button contains only 1 character
                                    {
                                        if (btn.Content.ToString().Length == 1)
                                        {
                                            if (upperCaseRegex.Match(btn.Content.ToString()).Success)
                                            { // if the char is a letter and uppercase
                                                btn.Content = btn.Content.ToString().ToLower();
                                            }
                                            else if (lowerCaseRegex.Match(button.Content.ToString()).Success)
                                            { // if the char is a letter and lower case
                                                btn.Content = btn.Content.ToString().ToUpper();
                                            }// else if (btn.Content.ToString().Equals("ñ"))
                                        }

                                    }
                                }
                            }
                        }
                        break;

                    case "ALT":
                    case "CTRL":
                        break;

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
                    case "SPACE":
                        ResultContent += " ";
                        break;


                    default:
                        ResultContent += button.Content.ToString();
                        break;
                }
            }
            ResultTxt.Text = ResultContent;

            /*System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); //set the colour back after 2 seconds
            timer.Tick += (ss, ee) => { button.Background = Brushes.Red; timer.Stop(); };
            timer.Start();*/
        }

        #endregion

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void Button_TouchLeave(object sender, TouchEventArgs e)
        {

        }

        private void Keyboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
