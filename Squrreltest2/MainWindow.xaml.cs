using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Squrreltest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager manager;
        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var updateInfo = await manager.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                update_btn.IsEnabled = true;
            }
            else
            {
                update_btn.IsEnabled = false;
            }

        }

        private async  void Window_Loaded(object sender, RoutedEventArgs e)
        {
            manager = await UpdateManager
                .GitHubUpdateManager(@"https://github.com/meJevin/WPFFrameworkTest");

            version_tbck.Text = manager.CurrentlyInstalledVersion().ToString();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                await manager.UpdateApp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Updated succesfuly!");

        }
    }
}
