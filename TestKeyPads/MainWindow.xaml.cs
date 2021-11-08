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
            NumericKeyboard keypadWindow = new NumericKeyboard(textbox, this);
            //textbox.Text = keypadWindow.Result;
            if (keypadWindow.ShowDialog() == true)
            {
                textbox.Text = keypadWindow.ResultContent;
            }
        }

        private void textBox2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            QwertyKeyboard keyboardWindow = new QwertyKeyboard(textbox, this);
            //textbox.Text = keyboardWindow.Result;
            if (keyboardWindow.ShowDialog() == true)
            {

                textbox.Text = keyboardWindow.ResultContent;
            }
        }
    }
}
