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
        public NumericKeyboard numericKeyboard;
        public int lastIndexCharacterNumericKeyboard;
        
        public QwertyKeyboard qwertyKeyboard;
        public int lastIndexCharacterQwertyKeyboard;

        public MainWindow()
        {
            InitializeComponent();

            numericKeyboard = new NumericKeyboard();
            lastIndexCharacterNumericKeyboard = 0;

            qwertyKeyboard = new QwertyKeyboard();
            lastIndexCharacterQwertyKeyboard = 0;


        }

        /*public delegate void testDelegate();

        public Action<TextBox , Window>x = (TextBox textbox, Window window) =<
        {
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            keypadWindow.ShowDialog();

        };*/

       
        private void t1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            restartSelectionStartOnTextBox();

            if (!numericKeyboard.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TextBox currentTextBox = sender as TextBox;
                    //int index = textBox.SelectionStart;
                    string initValue = currentTextBox.Text;
                    numericKeyboard = new NumericKeyboard(currentTextBox, this, initValue) { indexCharacterToInsert = lastIndexCharacterNumericKeyboard };
                    numericKeyboard.Show();
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
            t1.SelectionStart = lastIndexCharacterNumericKeyboard;
            t2.SelectionStart = lastIndexCharacterQwertyKeyboard;
        }


        private void t2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            restartSelectionStartOnTextBox();

            if (!qwertyKeyboard.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TextBox currentTextBox = sender as TextBox;
                    //int index = textBox.SelectionStart;
                    string initValue = currentTextBox.Text;
                    qwertyKeyboard = new QwertyKeyboard(currentTextBox, this, initValue) { indexCharacterToInsert = lastIndexCharacterQwertyKeyboard };
                    qwertyKeyboard.Show();
                }));
            }

            /* TextBox textbox = sender as TextBox;
             string initValue = textbox.Text;
             QwertyKeyboard keyboardWindow = new QwertyKeyboard(textbox, this, initValue);
             //textbox.Text = keyboardWindow.Result;
             keyboardWindow.ShowDialog();*/
        }


        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /*TextBox textbox = sender as TextBox;
            textbox.Text = string.Concat(Enumerable.Repeat("•", textBox.Text.Length));*/
        }

        private void passwordBox_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            // init value 
            PasswordBox passwordTextbox = sender as PasswordBox;
            string initValue = passwordTextbox.Password;
            NumericKeyboard keypadWindow = new NumericKeyboard(null, this, initValue, passwordTextbox);
            keypadWindow.ShowDialog();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void t1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (numericKeyboard.enabledSelectionChange)
            {
                numericKeyboard.indexCharacterToInsert = currentTextBox.SelectionStart;
                lastIndexCharacterNumericKeyboard = numericKeyboard.indexCharacterToInsert;
            }
            else
            {
                numericKeyboard.enabledSelectionChange = true;
            }
        }

        private void t2_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;

            if (qwertyKeyboard.enabledSelectionChange)
            {
                qwertyKeyboard.indexCharacterToInsert = currentTextBox.SelectionStart;
                lastIndexCharacterQwertyKeyboard = qwertyKeyboard.indexCharacterToInsert;
            }
            else
            {
                qwertyKeyboard.enabledSelectionChange = true;
            }
        }


        private void TextBox_LostMouseCapture(object sender, MouseEventArgs e)
        {
            int a = 1;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int a = 1;
        }

        private void TextBox_LostTouchCapture(object sender, TouchEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = Keyboard.FocusedElement as TextBox;
            if (textBox != null)
            {
                restartSelectionStartOnTextBox();
                //t1.SelectionStart = lastIndexCharacterNumericKeyboard;
                //t2.SelectionStart = lastIndexCharacterNumericKeyboard;

                /*TraversalRequest tRequest = new TraversalRequest(FocusNavigationDirection.Right);
                textBox.MoveFocus(tRequest);*/
                
            }
        }

       
        /*private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            int index = textbox.SelectionStart;
            
           
        }*/



    }
}
