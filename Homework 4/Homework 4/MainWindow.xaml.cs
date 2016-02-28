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

namespace Homework_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int w;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> disp_select = new List<string>();
            disp_select.Add("Tab Manager");
            disp_select.Add("Stack Panel");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = disp_select;
        }

        private void comboBox1_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> output_select = new List<string>();
            output_select.Add("Message Box");
            output_select.Add("File Dialog");

            var comboBox1 = sender as ComboBox;
            comboBox1.ItemsSource = output_select;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            int sel_value = comboBox.SelectedIndex;

            if(sel_value == 0)
            {
                tabControl.IsEnabled = true;
                stack.IsEnabled = false;
            }
            else if (sel_value == 1)
            {
                tabControl.IsEnabled = false;
                stack.IsEnabled = true;
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox1 = sender as ComboBox;
            int sel_value1 = comboBox1.SelectedIndex;

            if(sel_value1 == 0)
            {
                w = 1;
            }
            else if (sel_value1 == 1)
            {
                w = 2;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            if (tabControl.IsEnabled == true)
            {
                TabItem t = new TabItem();

                ScrollViewer view = new ScrollViewer();
                view.Content = new TextBox();

                t.Header = "New Header";
                t.Content = view;
                tabControl.Items.Add(t);
             }
            else if (stack.IsEnabled == true)
            {
                Label l = new Label();
                l.Content = "New Label";
                stack.Children.Add(l);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (w == 1)
            {
                MessageBoxResult result = MessageBox.Show("New Message Box","New Box",MessageBoxButton.OKCancel);
                Console.WriteLine(result.ToString());
            }
            else if (w == 2)
            {
                Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();

                bool? picked = sfd.ShowDialog();

                if(picked == true)
                {
                    MessageBox.Show("You Picked: " + sfd.FileName, "File", MessageBoxButton.OK);
                }
               
            }
        }
    }
}
