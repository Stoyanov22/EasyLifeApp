using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace EasyLifeAppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            welcomeLbl.Content += Environment.UserName;
        }

        private void HousesLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hw = new HousesWindow();
            //this will open your child window
            hw.Show();
            //this will close parent window. windowOne in this case
            Close();
        }
    }
}
