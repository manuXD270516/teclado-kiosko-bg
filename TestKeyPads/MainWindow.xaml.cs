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
        public NumericKeyboard keypadWindow;
        public int lastIndexCharacterNumericKeyboard;

        public MainWindow()
        {
            InitializeComponent();
            keypadWindow = new NumericKeyboard();
            lastIndexCharacterNumericKeyboard = 0;
        }

        /*public delegate void testDelegate();

        public Action<TextBox , Window>x = (TextBox textbox, Window window) =<
        {
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            keypadWindow.ShowDialog();

        };*/

       
        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!keypadWindow.windowVisible)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    TextBox textbox = sender as TextBox;
                    //int index = textBox.SelectionStart;
                    string initValue = textbox.Text;
                    keypadWindow = new NumericKeyboard(textbox, this, initValue) { indexCharacterToInsert = lastIndexCharacterNumericKeyboard };
                    keypadWindow.Show();
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

        private void textBox2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            t1.SelectionStart = lastIndexCharacterNumericKeyboard;


            TextBox textbox = sender as TextBox;
            string initValue = textbox.Text;
            QwertyKeyboard keyboardWindow = new QwertyKeyboard(textbox, this, initValue);
            //textbox.Text = keyboardWindow.Result;
            keyboardWindow.ShowDialog();
        }

        private void passwordBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            keypadWindow.ShowDialog();
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

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textbox = sender as TextBox;

            if (keypadWindow.enabledSelectionChange)
            {
                keypadWindow.indexCharacterToInsert = textbox.SelectionStart;
                lastIndexCharacterNumericKeyboard = keypadWindow.indexCharacterToInsert;
            }
            else
            {
                keypadWindow.enabledSelectionChange = true;
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
                t1.SelectionStart = lastIndexCharacterNumericKeyboard;
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
