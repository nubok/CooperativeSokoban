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

namespace CooperativeSokoban
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas box;

        public MainWindow()
        {
            InitializeComponent();

            Canvas planetCute = (from c in (levelRoot.FindResource("tiles") as Canvas)
                                  .Children.OfType<Canvas>()
                                 where c.Name == "PlanetCute_design"
                                 select c).First();

            /*box = (from c in planetCute.Children.OfType<Canvas>()
                   where c.Name == */
        }

        private void FileOpenLevel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = "*.xsb";
            dlg.Filter = //"Hexoban level|*.hsb|"+
                "XSokoban/SokoMind Plus level|*.xsb|Txt levels|*.txt"
                + "|All files|*.*";
            bool? dlgResult = dlg.ShowDialog();

            if (dlgResult == true)
            {
                string filename = dlg.FileName;
                LevelLoadingResult llr = LevelLoader.loadLevel(filename);

                if (llr == LevelLoadingResult.FileNotFound)
                {
                    MessageBox.Show("The file '" + filename + "' could not be found.");
                }
                else if (llr == LevelLoadingResult.InvalidLevel)
                {
                    MessageBox.Show("The file '" + filename + "' either is an invalid file or contains invalid level data.");
                }
            }
        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
