using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;

namespace WpfApp3
{
    public partial class Window1 : Window
    {

        StringDataSource _dataSource;
        public StringDataSource DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                listBox.ItemsSource = value.data;
            }
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Window1()
        {
            InitializeComponent();

            saveFileDialog.DefaultExt = ".xml";
            openFileDialog.DefaultExt = ".xml";
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            openFileDialog.Filter = "XML Files|*.xml|All Files|*.*";

            DataSource = new StringDataSource();
            //DataSource.data.Add(new Student("Borisov Michael Denisovich"));
            //DataSource.data.Add(new Student("Matyash Daniil Denisovich"));

        }
       

        private void AddButton_Click(object sender, RoutedEventArgs e)
        { 
            NewStudent newStudentDialog = new NewStudent();
              
            if (newStudentDialog.ShowDialog() == true)
            {
                DataSource.data.Add(newStudentDialog.Student);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            DataSource.data.Remove(listBox.SelectedItem as Student);
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

            if (saveFileDialog.ShowDialog() == true)
            {

                var serializer = new XmlSerializer(typeof(StringDataSource));

                using (XmlWriter fs = XmlWriter.Create(saveFileDialog.FileName))
                {

                    serializer.Serialize(fs, DataSource);

                    Debug.WriteLine("Объект сериализован");
                }
            }
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                var serializer = new XmlSerializer(typeof(StringDataSource));
                using (XmlReader fs = XmlReader.Create(openFileDialog.FileName))
                {
                    
                    DataSource = serializer.Deserialize(fs) as StringDataSource;
                }
            }
        }

        private void NewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataSource = new StringDataSource();
        }
    }
}
