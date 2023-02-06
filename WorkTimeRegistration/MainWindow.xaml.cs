using System.Windows;
using WorkTimeRegistration.Interfaces.ViewModels;

namespace WorkTimeRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IMainWindowsViewModel mainWindowsViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowsViewModel;
        }
    }
}
