using System.Windows.Controls;
using UiComponents.PresentationModels;

namespace UiComponents.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FITSImporterView.xaml
    /// </summary>
    public partial class FitsImporterView : UserControl
    {
        public FitsImporterView(FitsImporterViewPresentationModel model)
        {
            InitializeComponent();

            DataContext = model;
        }
    }
}
