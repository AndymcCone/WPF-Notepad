using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;


namespace Notepad
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            //Kieliasetus ruotsiksi testausta varten
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sv-SE");
            InitializeComponent();
            
        }

        public void SetWindowTitle(string fileName)
        {
            this.Title = string.Format("{0} - Antin Notepad", System.IO.Path.GetFileName(fileName));
        }

        private void MenuItem_OpenClick(object sender, RoutedEventArgs e)
        {
             var dialog = new OpenFileDialog();
             dialog.FileName = "Document"; // Default file name
             dialog.DefaultExt = ".txt"; // Default file extension
             dialog.Filter = "Text documents (.txt)|*.txt|All Files(*.*)|*.*"; // Filter files by extension
             
             bool? result = dialog.ShowDialog();

             if (result == true)
             {
                string filename = dialog.FileName;
                SetWindowTitle(filename);
            }
            try
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
            }
            catch (Exception ex)
            {
                // Napataan exception jos painetaan cancel tiedoston avausikkunassa
                
            }
            
        }

        private void MenuItem_SaveClick(object sender, RoutedEventArgs e)
        {
            string fileText = textBox1.Text;

            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, fileText);
            }
        }

        private void MenuItem_PrintClick(object sender, RoutedEventArgs e)
        {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {   
                // korjaa viittaamaan textboxiin
                printDialog.PrintVisual(textBox1, "Printing TextBox");
            }
        }

        private void MenuItem_ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void format_click(object sender, RoutedEventArgs e)
        {
            
            FormatWindow win2 = new FormatWindow();
            win2.Owner = this;
            win2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //win2.textBoxFontti.Text = textBox1.FontSize.ToString();
            win2.ShowDialog();
            if (win2.DialogResult == true)
            {
                var fontti = win2.textBlock1.Text;

                if (fontti != "")
                {
                    textBox1.FontSize = Convert.ToDouble(fontti);
                }
                
            }
            
        }

        
    }
}
