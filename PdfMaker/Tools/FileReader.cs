namespace PdfMaker.Tools
{
    class FileReader
    {
        public System.Collections.Generic.List<string> ImportedFiles { get; private set; }

        public bool ImportFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                var fileStreams = openFileDialog.OpenFiles();
                ImportedFiles = new System.Collections.Generic.List<string>();

                foreach (var stream in fileStreams)
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        ImportedFiles.Add(reader.ReadToEnd());
                    }
                }

                return true;
            }

            return false;
        }
    }
}
