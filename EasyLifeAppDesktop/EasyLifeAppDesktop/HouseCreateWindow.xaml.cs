using EasyLifeAppDesktop.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace EasyLifeAppDesktop
{
    /// <summary>
    /// Interaction logic for HouseCreateWindow.xaml
    /// </summary>
    public partial class HouseCreateWindow : Window
    {
        private byte[] photo;
        HouseService hs = new HouseService();

        public HouseCreateWindow()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            var of = new OpenFileDialog();
            of.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            var res = of.ShowDialog();
            if (res.HasValue && of.FileName != null)
            {
                var img = new BitmapImage(new Uri(of.FileName));

                photo = ImageService.ConvertBitmapSourceToByteArray(img as BitmapSource);
                //var d = ImageService.ConvertBitmapSourceToByteArray(new BitmapImage(new Uri(of.FileName)));
                //var s = ImageService.ConvertBitmapSourceToByteArray(img);
                //var enc = ImageService.ConvertBitmapSourceToByteArray(new PngBitmapEncoder(), img);
                //imgPreview2.Source = Utils.ConvertByteArrayToBitmapImage(enc);
                //imgPreview2.Source = ImageService.ConvertByteArrayToBitmapImage2(enc);
                //var i = 0;
            }
            else
            {
                MessageBox.Show("Select a currect file...");
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(nameTb.Text != "" && adressTb.Text != "" && stateTb.Text != "")
            {
                hs.CreateHouse(nameTb.Text, adressTb.Text, photo, decimal.Parse(stateTb.Text), commentsTb.Text);
                MessageBox.Show("Added successfully !");
                var hw = new HousesWindow();
                hw.Show();
                Close();
            }
        }

        public static bool IsValid(string str)
        {
            double i;
            return double.TryParse(str, out i) && i >= 0 && i <= 10;
        }

        private void StateTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(((TextBox)sender).Text + e.Text);
        }
    }
}
