using System.ComponentModel;

namespace PdfMaker.Models
{
    public abstract class NotifyModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
