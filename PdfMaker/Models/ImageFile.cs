using System.IO;

namespace PdfMaker.Models
{
    public class ImageFile : NotifyModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }

        }

        private Stream _stream;
        public Stream Stream
        {
            get { return _stream; }
            set
            {
                _stream = value;
                OnPropertyChanged("Stream");
            }
        }


    }
}
