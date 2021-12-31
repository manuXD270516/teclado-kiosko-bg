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

        public int CurrentLengthText
        {
            get
            {
                return _resultContent.Length;
            }
        }

        #endregion

        #region additional properties

        public bool windowVisible { get; set; }
        public int indexCharacterToInsert { get; set; }
        public bool enabledSelectionChange { get; set; }
        private string lastResultContent { get; set; }

        // physical keyboard
        public bool isCapsLock { get; set; }
        //private bool isShift = false;

        #endregion


        #region Constructor


        public QwertyKeyboard()
        {
            windowVisible = false;
            indexCharacterToInsert = 0;
            enabledSelectionChange = true;

            isCapsLock = activateCapsLock();
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

            isCapsLock = activateCapsLock();
        }

        #endregion

        #region Callbacks

        private void closeKeyboard_Listener(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            windowVisible = false;
            Hide();
        }

        public void syncPressed(string commandParameter, string content)
        {
            switch (commandParameter.ToUpper())
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
                                        else if (lowerCaseRegex.Match(btn.Content.ToString()).Success)
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
                    closeKeyboard();
                    //DialogResult = false;
                    break;
                case "RETURN":
                    closeKeyboard();
                    //DialogResult = true;
                    break;

                case "DELETE":
                    // Text: A  B   C   D,  DELETE: B, Result: A    C   D   
                    lastResultContent = ResultContent;
                    if (ResultContent.Length > 0 && indexCharacterToInsert < ResultContent.Length)
                    {
                        ResultContent = ResultContent.Remove(indexCharacterToInsert, 1);
                    }
                    enabledSelectionChange = false;
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


                case "ESCAPE":
                    closeKeyboard();
                    break;
                case "LEFT":
                    if (indexCharacterToInsert > 0)
                    {
                        indexCharacterToInsert--;

                    }
                    applySelectionStart();
                    break;
                case "RIGHT":
                    if (indexCharacterToInsert < CurrentLengthText)
                    {
                        indexCharacterToInsert++;
                    }
                    applySelectionStart();
                    break;

                default:
                    lastResultContent = ResultContent;
                    ResultContent = ResultContent.Insert(indexCharacterToInsert++, content);
                    enabledSelectionChange = false;
                    break;
            }
            applyContentText();
        }

        public void closeKeyboard()
        {
            windowVisible = false;
            Hide();
        }

        private void applySelectionStart()
        {
            ResultTxt.SelectionStart = indexCharacterToInsert;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                syncPressed(button.CommandParameter.ToString(), button.Content.ToString());
                /*switch (button.CommandParameter.ToString())
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
                applyContentText();*/
            }


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

            // cambios parciales

        }

        private void applyContentText()
        {
            ResultTxt.Text = ResultContent;
        }

        #region "Other methods"
        public bool keyIsCapsLock(Key selectedKey) => new Key[] { Key.CapsLock, Key.Capital }.Contains(selectedKey);
        public bool keyIsNumeric(Key selectedKey) => (selectedKey >= Key.NumPad0 && selectedKey <= Key.NumPad9) || (selectedKey >= Key.D0 && selectedKey <= Key.D9);
        public bool keyIsLetter(Key selectedKey) => selectedKey >= Key.A && selectedKey <= Key.Z;
        public bool keyIsSpace(Key selectedKey) => selectedKey == Key.Space;
        public bool keyIsLetterOrSpace(Key selectedKey) => keyIsLetter(selectedKey) || keyIsSpace(selectedKey);
        public bool keyIsArrowsNavigationPermitted(Key selectedKey) => new Key[] { Key.Left, Key.Right }.Contains(selectedKey);
        public bool keyIsAnyArrowsNavigation(Key selectedKey) => new Key[] { Key.Up, Key.Down }.Contains(selectedKey) || keyIsArrowsNavigationPermitted(selectedKey);
        public bool keyIsClosedWindow(Key selectedKey) => new Key[] { Key.Return, Key.Escape }.Contains(selectedKey);
        public bool keyIsBack(Key selectedKey) => selectedKey == Key.Back;
        public bool keyIsTab(Key selectedKey) => selectedKey == Key.Tab;

        public bool keyIsDelete(Key selectedKey) => selectedKey == Key.Delete;
        public bool keyIsNavigationOrClose(Key selectedKey) => keyIsArrowsNavigationPermitted(selectedKey) || keyIsClosedWindow(selectedKey) || keyIsBack(selectedKey) || keyIsDelete(selectedKey);
        public bool keyIsShiftWithLetter(Key selectedKey) => System.Windows.Input.Keyboard.Modifiers == ModifierKeys.Shift && keyIsLetter(selectedKey);
        public bool keyIsShiftWithOtherCharacter(Key selectedKey) => System.Windows.Input.Keyboard.Modifiers == ModifierKeys.Shift && keyIsOtherCharacter(selectedKey);
        public bool keyIsFunction(Key selectedKey) => selectedKey >= Key.F1 && selectedKey <= Key.F24;
        public bool activateCapsLock() => (System.Windows.Input.Keyboard.GetKeyStates(Key.CapsLock) & KeyStates.Toggled) == KeyStates.Toggled;
        public bool keyIsModifier(Key selectedKey) => new Key[] { Key.LeftShift, Key.RightShift, Key.Tab, Key.LeftCtrl, Key.RightCtrl, Key.LeftAlt, Key.RightAlt }.Contains(selectedKey);
        public bool keyIsNumericWithAlt(Key selectedKey) => System.Windows.Input.Keyboard.Modifiers == ModifierKeys.Alt;//&& keyIsNumeric(selectedKey);

        // only preview input text 
        public bool KeyTextIsSpecialCharacter(string keyContent)
        {
            if (keyContent.Length > 0)
            {
                int asciiCode = keyContent[0];
                return asciiCode >= 32 && asciiCode <= 127;
            }
            return false;
        }
        //new string[] { ".", "_", "@", "-", "/", ":", ";", "(", ")", "$", "&", ",", "?", "=", "+", @"\", "[", "]" }.Contains(keyContent);


        public bool keyIsOtherCharacter(Key selectedKey) =>
            !keyIsNumeric(selectedKey) &&
            !keyIsLetterOrSpace(selectedKey) &&
            //!keyIsArrowsNavigationPermitted(selectedKey) &&
            !keyIsAnyArrowsNavigation(selectedKey) &&
            !keyIsNavigationOrClose(selectedKey) &&
            !keyIsBack(selectedKey) &&
            !keyIsCapsLock(selectedKey) &&
            !keyIsFunction(selectedKey);

        /*public bool keyIsCapsLockOrShift(Key selectedKey)
        {
            var keysForMayus = new Key[] { Key.LeftShift, Key.RightShift, Key.CapsLock };
            bool appliedCasting = keysForMayus.Contains(selectedKey);
            if (appliedCasting)
            {
                if (selectedKey == Key.CapsLock) // MAYUS
                {
                    isCapsLock = !isCapsLock;
                }
                else // SHIFT
                {
                    isShift = !isShift;
                }
            }
            return appliedCasting;

        }*/


        public Dictionary<string, bool> pressKeyOfPhysicalKeyboard(Key selectedKey = default, string keyContent = null)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            string contentResult = "";

            if (keyContent != null)
            {
                bool executeKeyPressTextInput = KeyTextIsSpecialCharacter(keyContent);
                if (executeKeyPressTextInput)
                {
                    syncPressed(keyContent, keyContent);
                }
                result.Add("CommitPreviewTextInput", true);
                return result;
            }
            if (keyIsTab(selectedKey))
            {
                result.Add("TabSelected", true);
            }
            else if (keyIsNumeric(selectedKey))
            {
                contentResult = Convert.ToString(selectedKey.ToString().Last());
            }
            else if (keyIsArrowsNavigationPermitted(selectedKey) || keyIsClosedWindow(selectedKey) || keyIsSpace(selectedKey) || keyIsBack(selectedKey) || keyIsDelete(selectedKey))
            {
                contentResult = selectedKey.ToString();
            }
            else if (keyIsLetter(selectedKey) /*|| keyIsOtherCharacter(selectedKey))*/ && !keyIsModifier(selectedKey))
            {
                contentResult = generateLetter(selectedKey);
            }
            bool commitKeyPressed = !contentResult.Equals(string.Empty);
            if (commitKeyPressed)
            {
                syncPressed(contentResult, contentResult);
            }

            result.Add("CommitPreviewKeyDown", commitKeyPressed);
            return result;
        }

        public string generateLetter(Key selectedKey)
        {
            string content = selectedKey.ToString();
            bool toggleShift = keyIsShiftWithLetter(selectedKey) || keyIsShiftWithOtherCharacter(selectedKey);
            if (activateCapsLock())
            {
                if (toggleShift)
                {
                    content = content.ToLower();
                }
                else
                {
                    content = content.ToUpper();
                }
            }
            else
            {
                if (toggleShift)
                {
                    content = content.ToUpper();
                }
                else
                {
                    content = content.ToLower();
                }
            }
            return content;
            /*if (selectedKey == Key.CapsLock)
            {
                isCapsLock = !isCapsLock;
            }
            bool shift = isShift;
            if (isCapsLock)
            {
                shift = !shift;
            }
            //int s = selectedKey.ToString()[0];
            if (!shift)
            {
                //s += 32;
                content = content.ToLower();
            }*/
            /*if (isCapsLock)
            {
                content = content.ToUpper();
            }
            else
            {
                if (isShift)
                {
                    content = content.ToUpper();
                }
                else
                {
                    content = content.ToLower();
                }
            }*

            return content;*/
            //return ((char)s).ToString();
        }

        #endregion

    }
}
