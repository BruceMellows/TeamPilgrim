using System.ComponentModel;
using System.Windows.Threading;

namespace JustAProgrammer.TeamPilgrim.VisualStudio.Model
{
    public class BaseModel : INotifyPropertyChanged
    {
        private PropertyChangedEventHandler _propertyChangedEvent;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                _propertyChangedEvent += value;
            }
            remove
            {
                _propertyChangedEvent -= value;
            }
        }

        protected void SendPropertyChanged(string propertyName)
        {
            if (_propertyChangedEvent != null)
            {
                _propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}