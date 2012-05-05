using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Prism.Commands;


namespace UiComponents.PresentationModels
{
    public class ShellPresentationModel : INotifyPropertyChanged
    {
       

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ShellPresentationModel()
        {
        
        }

      


    }
}
