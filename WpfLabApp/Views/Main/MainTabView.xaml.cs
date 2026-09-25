using System.Windows;
using System.Windows.Controls;

namespace WpfLabApp.Views
{
    public partial class MainTabView : UserControl
    {
        public MainTabView()
        {
            InitializeComponent();
        }

        private void PresetButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && double.TryParse(btn.Tag?.ToString(), out double size))
            {
                FontSizeSlider.Value = size;
            }
        }
    }
}
