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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for FormatWindow.xaml
    /// </summary>
    public partial class FormatWindow : Window
    {
        public FormatWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        
        //Fonttivalodointi regexpin avulla (jäi turhaksi fonttilistan takia)

        /*
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
        */
        

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = (sender as ListBox).SelectedItem as ListBoxItem;
            textBlock1.Text = lbi.Content.ToString();
        }
    }
}
