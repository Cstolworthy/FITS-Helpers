using System.Windows;
using UiComponents.PresentationModels;

namespace FitsDisplay
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(ShellPresentationModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
