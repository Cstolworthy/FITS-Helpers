using System.Windows.Controls;
using UiComponents.Modules;

namespace UiComponents.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView(MainMenuPresentationModel model)
        {
            InitializeComponent();

            DataContext = model;
        }


    }
}
