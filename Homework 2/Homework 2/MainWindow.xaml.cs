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

namespace Homework_2
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

        String selection1 = null;
        String selection2 = null;

        //Callback is attached to checkbox when it is checked
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = true;
        }

        //Callback is attached to checkbox when it is unchecked
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
        }

        //Callback is attached to selection of specific radio button
        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            selection1 = "Radio Button 1 Selected";
        }

        //Callback is attached to selection of radio button
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            selection1 = "Radio Button 2 Selected";
        }

        //Callback is attached to selection of radio button
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            selection1 = "Radio Button 3 Selected";
        }

        //Callback is attached to selection of radio button
        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            selection2 = "Radio Button 4 Selected\r\n";
        }

        //Callback is attached to selection of radio button
        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            selection2 = "Radio Button 5 Selected\r\n";
        }
        
        //Callback is attached to selection of radio button
        private void radioButton5_Checked(object sender, RoutedEventArgs e)
        {
            selection2 = "Radio Button 6 Selected\r\n";
        }

        //Callback is attached to button click
        private void button_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine(selection1);
            System.Console.WriteLine(selection2);
            
        }
    }
}
