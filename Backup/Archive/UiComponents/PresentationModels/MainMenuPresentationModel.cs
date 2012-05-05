using System;
using System.ComponentModel;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Unity;
using UiComponents.Views;
using UiComponents.Views.UserControls;

namespace UiComponents.Modules
{
    public class MainMenuPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand<object> ImportFitsImageCommand { get; private set; }
        public DelegateCommand<object> ExitApplicationCommand { get; private set; }

        public MainMenuPresentationModel(IUnityContainer container)
        {
            UnityContainer = container;
            ImportFitsImageCommand = new DelegateCommand<object>(ImportFitsImage);
            ExitApplicationCommand = new DelegateCommand<object>(ExitApplication);
        }

        private IUnityContainer UnityContainer { get; set; }

        private void ImportFitsImage(object obj)
        {
            var pw = new PopupWindow();
            var uc = UnityContainer.Resolve<FitsImporterView>();
            pw.ShowDialog(uc);
        }

        private static void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
