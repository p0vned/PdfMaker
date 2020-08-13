using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using PdfMaker.Models;
using PdfMaker.Models.Commands;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PdfMaker.ViewModels
{
    class MainWindowViewModel
    {
        public ObservableCollection<ImageFile> ListImageFiles { get; set; }
        public ImportFileCommand ImportFilesCommand { get; private set; }
        public SaveFilesToPdfCommand SaveFilesPdfCommand { get; private set; }

        public MainWindowViewModel()
        {
            ListImageFiles = new ObservableCollection<ImageFile>();

            ImportFilesCommand = new ImportFileCommand(ImportFiles);
            SaveFilesPdfCommand = new SaveFilesToPdfCommand(CreatePdf);
        }

        public void ImportFiles()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                var fileStreams = openFileDialog.OpenFiles();

                for (int i = 0; i < fileStreams.Length; i++)
                {
                    var imageFile = new ImageFile();

                    imageFile.Name = openFileDialog.SafeFileNames[i];
                    imageFile.Stream = fileStreams[i];

                    ListImageFiles.Add(imageFile);
                }
            }
        }

        public void CreatePdf()
        {
            var document = new PdfDocument();
            document.Info.Title = "Created with PdfMaker 1.0";

            foreach (var imageFile in ListImageFiles)
            {
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var image = XImage.FromStream(imageFile.Stream);
                gfx.DrawImage(image, 0, 0, (int)page.Width, (int)page.Height);
            }

            if (document.PageCount > 0)
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Document";
                saveFileDialog.DefaultExt = ".pdf";
                saveFileDialog.Filter = "PDF documents (.pdf)|*.pdf";

                var filePath = string.Empty;

                if (saveFileDialog.ShowDialog() == true)
                    filePath = saveFileDialog.FileName;

                document.Save(filePath);
            }
        }
    }
}
