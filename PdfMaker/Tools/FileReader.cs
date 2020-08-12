namespace PdfMaker.Tools
{
    class FileReader
    {
        public string ImportedFile { get; private set; }

        public bool ImportFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == true)
            {
                var fileStream = openFileDialog.OpenFile();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    ImportedFile = reader.ReadToEnd();
                }

                return true;
            }
            return false;
        }
    }
}
