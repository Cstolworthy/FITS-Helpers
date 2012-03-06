using System.Windows;
using System.Windows.Controls;

namespace UiComponents.Views
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public PopupWindow()
        {
            InitializeComponent();
        }

        public void ShowDialog(UserControl uc)
        {
            Height = uc.Height + 25;
            Width = uc.Width + 25;
            theGrid.Children.Add(uc);
            base.ShowDialog();
        }
    }
}
