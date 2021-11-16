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

namespace TestKeyPads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string initValue = textbox.Text;
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this, initValue);
            //textbox.Text = keypadWindow.Result;
            if (keypadWindow.ShowDialog() == true)
            {
                textbox.Text = keypadWindow.ResultContent;
            }
        }

        private void textBox2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
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
    }
}
