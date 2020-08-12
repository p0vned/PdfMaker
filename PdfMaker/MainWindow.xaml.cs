using System.Windows;

namespace PdfMaker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonImportFiles_Click(object sender, RoutedEventArgs e)
        {
            var fileReader = new Tools.FileReader();
            var isFileImported = fileReader.ImportFile();
            if (isFileImported == true)
                MessageBox.Show("File imported properly!");
            else
            {
                MessageBox.Show("Error! File has not been imported properly!");
            }
        }
    }
}
