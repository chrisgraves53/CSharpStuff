using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using WinForms = System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using System.Windows.Controls;

namespace Project_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Collection to hold all objects
        ObservableCollection<Game> alldaGames = new ObservableCollection<Game>();
        public ObservableCollection<Game> gettingGames { get { return alldaGames; } }


        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = gettingGames;
            
    
        }

        string exe_path;
        string name_exe;
        string set_path;
        string home_path;
        bool? loaded;
        int i = 1;
        



        //Class for Games
        public class Game
        {           
            public string exeName{ get ;  set;}
            public string exePath { get; set; }
            public string homePath { get; set; }
            public string settingPath { get; set; }

            public Game(string exename, string exepath, string homepath, string settingpath)
            {
                
                exeName = exename;
                exePath = exepath;
                homePath = homepath;
                settingPath = settingpath;
            }

            public override string ToString()
            {
                return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}",exeName,exePath,homePath,settingPath); 
            }
        }

        //Method to add class object to collection
        
        public void loadGames()
        {
            alldaGames.Add(new Game(name_exe, exe_path, home_path, set_path));
        }


        //Opens file dialog for selection exe file in PopupBox       
        public void exeBut_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Executable files (*.exe)|*.exe";
            if (openFile.ShowDialog() == true)
            {
                //full game exe path
                 exe_path = System.IO.Path.GetFullPath(openFile.FileName);

                //just game name
                string getName = System.IO.Path.GetFileName(openFile.FileName);
                string theTrim = getName.Trim(new Char[] { '.', 'e','x','e' });
                name_exe = theTrim;
                
                //full exe path for PopupBox Textbox
                string toString = exe_path.ToString();
                exebox.Text = exe_path;
                             
            }
        }

        //Folder dialog for Settings Directory in PopupBox
        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            var dialog_Set = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog_Set.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                set_path = dialog_Set.SelectedPath;
                setbox.Text = set_path;
                
            }
        }

        //Folder dialog for Home Directory in PopupBox
        private void homeSet_Click(object sender, RoutedEventArgs e)
        {
            var dialog_Set = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog_Set.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                home_path = dialog_Set.SelectedPath;
                homebox.Text = home_path;
               
            }
        }

        //Shows PopupBox for paths from file menu 
        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            GamePath.IsOpen = true;
        }


        //Saving game and paths
        private void saveBut_Click(object sender, RoutedEventArgs e)
        {
            loadGames();
            loaded = true;
            savePaths();
           
        }


        //Hides Popup Box
        private void closeBut_Click(object sender, RoutedEventArgs e)
        {
            GamePath.IsOpen = false;


            if (loaded != true && exebox.Text != null && homebox.Text != null)
            {
                loadGames();
            }
            exebox.Clear();
            setbox.Clear();
            homebox.Clear();
        }

        //Launch game on click
        private void launch_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null && exe_path != null)
            {

                var text = listBox.SelectedItem as Game;
                var paths = text.exePath;
                Process.Start(paths);
                toNext();
            }
            
        }

        //Delete game from Listbox on click
        private void DeleteGame_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                //var selec_in = listBox.SelectedIndex;
                alldaGames.Remove((Game)listBox.SelectedItem);
            }
        }

         //Open Home Directory of selected game
         private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null && home_path != null)
            {
                var text = listBox.SelectedItem as Game;
                var homes = text.homePath;


                openDirects(homes);
            }
            
        }
        
        //Open Settings Directory of selected game
        private void Setting_Click(object sender, RoutedEventArgs e)
        {

            if (listBox.SelectedItem != null && set_path != null)
            {
                var text = listBox.SelectedItem as Game;
                var settings = text.settingPath;

                openDirects(settings);
            }
        }
        
        //Open Directory method
        private void openDirects(string path)
        {
            Process.Start(path);
        }

        //Save game info method
        private void savePaths()
        {
            string savingIt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter sw = new StreamWriter(savingIt + @"\SavedGamesList.txt"))
            {
                foreach (Game thing in alldaGames)
                    sw.WriteLine(thing.ToString());
            }
        }

        //Exit program from file menu
        private void Exitprog_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void toNext()
        {
            
            var text = listBox.SelectedItem as Game;
            var namez = text.exeName;
            Label l = new Label();
            l.Content = i+". " + namez;
            theStack.Children.Add(l);
            i++;
        }
    }
}
