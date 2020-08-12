using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using PdfMaker.Models;
using PdfMaker.Models.Commands;

namespace PdfMaker.ViewModels
{
    class MainWindowViewModel
    {
        public ObservableCollection<ImageFile> ListImageFiles { get; set; }
        public ImportFileCommand ImportFilesCommand { get; private set; }

        public MainWindowViewModel()
        {
            ImportFilesCommand = new ImportFileCommand(ImportFiles);
        }

        public void ImportFiles()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                var fileStreams = openFileDialog.OpenFiles();

                foreach (var stream in fileStreams)
                {
                    using (StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        var imageFile = new ImageFile();
                        
                        imageFile.Data = reader.ReadToEnd();
                        imageFile.Name = openFileDialog.SafeFileName + Path.GetExtension(openFileDialog.FileName);

                        ListImageFiles.Add(imageFile);
                    }
                }
            }
        }
    }
}
