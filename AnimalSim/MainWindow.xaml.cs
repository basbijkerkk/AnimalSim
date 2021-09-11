using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AnimalSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AnimalHandler anHandle;
        public MainWindow()
        {
            InitializeComponent();
            anHandle = new AnimalHandler();
            listView.ItemsSource = AnimalHandler.Animals;
            PopulateComboBoxes();
        }
        private void PopulateComboBoxes()
        {
            comboBox.ItemsSource = new List<string>() { "Ape's", "Lion's", "Elephant's", "Feed All"};
            comboBox1.ItemsSource = new List<string>() { "Ape", "Lion", "Elephant" };
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await anHandle.FeedAnimal(comboBox.Text);
            }
            catch(InvalidOperationException)
            {

            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                switch (comboBox1.Text.ToLower())
                {
                    case "ape":
                        anHandle.GenerateApe("Jangles" + new Random().Next(0, 158));
                        break;
                    case "lion":
                        anHandle.GenerateLion("Simba" + new Random().Next(0, 158));
                        break;
                    case "elephant":
                        anHandle.GenerateElephant("Dumbo" + new Random().Next(0, 158));
                        break;

                }
            }
        }
    }
}
