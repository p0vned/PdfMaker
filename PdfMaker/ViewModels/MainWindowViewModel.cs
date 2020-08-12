using System.Collections.ObjectModel;
using PdfMaker.Models;

namespace PdfMaker.ViewModels
{
    class MainWindowViewModel
    {
        public ObservableCollection<ImageFile> ListImageFiles { get; set; }
    }
}
