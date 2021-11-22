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

        #region additional properties

        public bool windowVisible { get; set; }
        public int indexCharacterToInsert { get; set; }
        public bool enabledSelectionChange { get; set; }
        private string lastResultContent { get; set; }

        #endregion


        #region Constructor


        public QwertyKeyboard()
        {
            windowVisible = false;
            indexCharacterToInsert = 0;
            enabledSelectionChange = true;
        }

        public QwertyKeyboard(TextBox owner, Window wndOwner, string resultContent)
        {
            InitializeComponent();
            Owner = wndOwner;
            DataContext = this;
            ResultTxt = owner;
            ResultContent = resultContent;
            lastResultContent = "";
            Left = (wndOwner.Width / 2) - (Width / 2);
            Top = wndOwner.Height - Height;

            windowVisible = true;
            indexCharacterToInsert = 0;
            enabledSelectionChange = true;
        }

        #endregion

        #region Callbacks

        private void closeKeyboard_Listener(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            windowVisible = false;
            Hide();
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
                        enabledSelectionChange = false;
                        break;

                    case "ALT":
                    case "CTRL":
                        break;

                    case "ESC":
                        windowVisible = false;
                        Hide();
                        //DialogResult = false;
                        break;
                    case "RETURN":
                        windowVisible = false;
                        Hide();
                        //DialogResult = true;
                        break;

                    case "BACK":
                        lastResultContent = ResultContent;
                        if (ResultContent.Length > 0 && indexCharacterToInsert > 0)
                        {
                            ResultContent = ResultContent.Remove(indexCharacterToInsert - 1, 1);
                            indexCharacterToInsert--;
                            enabledSelectionChange = false;
                        }
                        break;
                    case "SPACE":
                        lastResultContent = ResultContent;
                        ResultContent = ResultContent.Insert(indexCharacterToInsert++, " ");
                        enabledSelectionChange = false;
                        break;


                    default:
                        lastResultContent = ResultContent;
                        ResultContent = ResultContent.Insert(indexCharacterToInsert++, button.Content.ToString());
                        enabledSelectionChange = false;
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
            ResultTxt.Text = ResultContent;


        }
    }
}
