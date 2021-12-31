using KeyPadNumeric_Kiosk_BG;
using KeyPadQWERTY_Kiosk_BG;
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
using static KeyPadQWERTY_Kiosk_BG.QwertyKeyboard;
using static KeyPadNumeric_Kiosk_BG.NumericKeyboard;
using System.Threading;

namespace TestKeyPads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NumericKeyboard numericKeyboard_t1;
        public int lastIndexCharacterNumericKeyboard_t1;

        public QwertyKeyboard qwertyKeyboard_t2;
        public int lastIndexCharacterQwertyKeyboard_t2;


        // other controls
        public NumericKeyboard numericKeyboard_Password;
        public int lastIndexCharacterNumericKeyboard_Password;

        private const int INDEX_T1_TEXT_CONTROL = 1;
        private const int INDEX_T2_TEXT_CONTROL = 2;

        private const int INDEX_OTRO_COTROL = -1;

        //private bool isCapLock = false;



        public MainWindow()
        {
            InitializeComponent();

            initCustomKeyboards();

        }

        private void initCustomKeyboards()
        {
            numericKeyboard_t1 = new NumericKeyboard();
            lastIndexCharacterNumericKeyboard_t1 = 0;

            qwertyKeyboard_t2 = new QwertyKeyboard();
            lastIndexCharacterQwertyKeyboard_t2 = 0;



            numericKeyboard_Password = new NumericKeyboard();
            lastIndexCharacterNumericKeyboard_Password = 0;
        }

        /*public delegate void testDelegate();

        public Action<TextBox , Window>x = (TextBox textbox, Window window) =<
        {
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            keypadWindow.ShowDialog();

        };*/

        private void hideVisibilityKeyboardExcept(int focusInputTextIndex)
        {
            switch (focusInputTextIndex)
            {
                case INDEX_T1_TEXT_CONTROL: // T1

                    qwertyKeyboard_t2.closeKeyboard();

                    /*qwertyKeyboard_t2.Hide();
                    qwertyKeyboard_t2.windowVisible = false;*/

                    break;

                case INDEX_T2_TEXT_CONTROL: // T2

                    numericKeyboard_t1.closeKeyboard();

                    /*numericKeyboard_t1.Hide();
                    numericKeyboard_t1.windowVisible = false;*/

                    break;

                default: // any other point of window

                    qwertyKeyboard_t2.closeKeyboard();
                    numericKeyboard_t1.closeKeyboard();

                    /*numericKeyboard_t1.Hide();
                    numericKeyboard_t1.windowVisible = false;

                    qwertyKeyboard_t2.Hide();
                    qwertyKeyboard_t2.windowVisible = false;*/

                    break;
            }
        }

        private void t1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            restartSelectionStartOnTextBox();

            if (!numericKeyboard_t1.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TextBox currentTextBox = sender as TextBox;
                    string initValue = currentTextBox.Text;
                    numericKeyboard_t1 = new NumericKeyboard(currentTextBox, this, initValue) { indexCharacterToInsert = lastIndexCharacterNumericKeyboard_t1 };
                    numericKeyboard_t1.Show();

                    t1.SelectionStart = lastIndexCharacterNumericKeyboard_t1;
                    t1.Focus();

                    hideVisibilityKeyboardExcept(INDEX_T1_TEXT_CONTROL);

                }));
            }
            /*var t = new Thread(_ =>
            {
                TextBox textbox = sender as TextBox;

                textbox.Dispatcher.Invoke(delegate()
                {

                });
            });
            t.SetApartmentState(ApartmentState.MTA);
            t.Start();*/

            /*TextBox textbox = sender as TextBox;
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            //textbox.Text = keypadWindow.Result;
            if (keypadWindow.ShowDialog() == true)
            {
                textbox.Text = keypadWindow.ResultContent;
            }*/
        }

        private void restartSelectionStartOnTextBox()
        {
            t1.SelectionStart = lastIndexCharacterNumericKeyboard_t1;
            t2.SelectionStart = lastIndexCharacterQwertyKeyboard_t2;
        }


        private void t2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            restartSelectionStartOnTextBox();

            if (!qwertyKeyboard_t2.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TextBox currentTextBox = sender as TextBox;
                    string initValue = currentTextBox.Text;
                    qwertyKeyboard_t2 = new QwertyKeyboard(currentTextBox, this, initValue) { indexCharacterToInsert = lastIndexCharacterQwertyKeyboard_t2 };
                    qwertyKeyboard_t2.Show();

                    t2.Focus();
                    t2.SelectionStart = lastIndexCharacterQwertyKeyboard_t2;

                    hideVisibilityKeyboardExcept(INDEX_T2_TEXT_CONTROL);
                }));
            }
        }

        private void passwordBox_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            restartSelectionStartOnTextBox();

            if (!numericKeyboard_Password.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    PasswordBox currentTextBox = sender as PasswordBox;
                    string initValue = currentTextBox.Password;
                    numericKeyboard_Password = new NumericKeyboard(null, this, initValue, currentTextBox) { indexCharacterToInsert = lastIndexCharacterNumericKeyboard_Password };
                    numericKeyboard_Password.Show();
                }));
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void t1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (numericKeyboard_t1.enabledSelectionChange)
            {
                numericKeyboard_t1.indexCharacterToInsert = currentTextBox.SelectionStart;
                lastIndexCharacterNumericKeyboard_t1 = numericKeyboard_t1.indexCharacterToInsert;
            }
            else
            {
                numericKeyboard_t1.enabledSelectionChange = true;
            }
        }

        private void t2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (qwertyKeyboard_t2.enabledSelectionChange)
            {
                qwertyKeyboard_t2.indexCharacterToInsert = currentTextBox.SelectionStart;
                lastIndexCharacterQwertyKeyboard_t2 = qwertyKeyboard_t2.indexCharacterToInsert;
            }
            else
            {
                qwertyKeyboard_t2.enabledSelectionChange = true;
            }
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            hideVisibilityKeyboardExcept(INDEX_OTRO_COTROL);
        }

        private void t1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (currentTextBox.Text.Length > 4)
            {
                numericKeyboard_t1.applyValidations(false);
            }
            currentTextBox.SelectionStart = numericKeyboard_t1.indexCharacterToInsert;
            lastIndexCharacterNumericKeyboard_t1 = currentTextBox.SelectionStart;
            currentTextBox.Focus();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox p = sender as PasswordBox;
            if (p.Password.Length > 10)
            {
                numericKeyboard_Password.applyValidations(backPressed: false);
            }
            p.Focus();
        }

        private void t1_LostFocus(object sender, RoutedEventArgs e)
        {
            hideOnlyKeyboard(INDEX_T1_TEXT_CONTROL);
        }

        private void t2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            
            if (currentTextBox.Text.Length > 20)
            {
                qwertyKeyboard_t2.applyValidations(false);
            }
            currentTextBox.SelectionStart = qwertyKeyboard_t2.indexCharacterToInsert;
            lastIndexCharacterQwertyKeyboard_t2 = currentTextBox.SelectionStart;
            currentTextBox.Focus();
        }

        private void Window_GotMouseCapture(object sender, MouseEventArgs e)
        {
            TextBox textBox = Keyboard.FocusedElement as TextBox;
            if (textBox == null)
            {
                hideVisibilityKeyboardExcept(INDEX_OTRO_COTROL);
            }
        }

        private void t2_LostFocus(object sender, RoutedEventArgs e)
        {
            hideOnlyKeyboard(INDEX_T2_TEXT_CONTROL);
        }

        private void hideOnlyKeyboard(int focusInputTextIndex)
        {
            switch (focusInputTextIndex)
            {
                case INDEX_T1_TEXT_CONTROL: // CI 

                    numericKeyboard_t1.closeKeyboard();
                    break;

                case INDEX_T2_TEXT_CONTROL: // Complemento

                    qwertyKeyboard_t2.closeKeyboard();
                    break;

                default: // any other point of window
                    numericKeyboard_t1.closeKeyboard();
                    qwertyKeyboard_t2.closeKeyboard();
                    break;
            }

        }
        bool isCapsLock = false;
        bool isShift = false;

        private void t1_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            /*if ((Keyboard.GetKeyStates(Key.CapsLock) & KeyStates.Toggled) == KeyStates.Toggled)
            {
                MessageBox.Show("Key CapsLock Activate");
            }
            else
            {
                MessageBox.Show("Key CapsLock Desactivate");

            }*/

            /*bool isCapLock = e.Key == Key.CapsLock;
            bool isCapital = e.Key == Key.Capital;
            bool isShift = Keyboard.Modifiers == ModifierKeys.Shift;

            bool x = Keyboard.IsKeyDown(Key.Capital);

            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.A)
            {
                string foo = "test value";

            }*/
            // numeric
            /*int keyValue = (int)e.Key;
            char foo = default;


            // Letter
            if (e.Key == Key.CapsLock)
            {
                isCapsLock = !isCapsLock;
            }

            string content = e.Key.ToString();


            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                bool shift = isShift;
                if (isCapsLock)
                {
                    shift = !shift;
                }
                int s = e.Key.ToString()[0];
                if (!shift)
                {
                    s += 32;
                }
                content = ((char)s).ToString();
            }

            string ch = ((char)e.Key).ToString();
            int i;

            if (int.TryParse(e.Key.ToString(), out i))
            {
                MessageBox.Show("Number");
            }*/

            /*string aa = e.Key.ToString();
            string xd = e.Key.ToString();

            int pos = t1.SelectionStart;*/
            numericKeyboard_t1.pressKeyOfPhysicalKeyboard(e.Key);
            e.Handled = true;
        }


        private void t2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Dictionary<string, bool> result = qwertyKeyboard_t2.pressKeyOfPhysicalKeyboard(selectedKey: e.Key);
            bool tabSelected;
            if (result.TryGetValue("TabSelected", out tabSelected) && tabSelected)
            {
                e.Handled = tabSelected;
            } else
            {
                e.Handled = result["CommitPreviewKeyDown"];

            }

            /*if (!e.Handled)
            {
                t2.Text = x;
            }-*/
        }

        private void t2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Dictionary<string, bool> result = qwertyKeyboard_t2.pressKeyOfPhysicalKeyboard(keyContent: e.Text);
            e.Handled = result["CommitPreviewTextInput"];
        }


        private void t1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        



        /*private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            int index = textbox.SelectionStart;
            
           
        }*/



    }
}
