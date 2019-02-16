using EasyLifeAppDesktop.Services;
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
    public partial class HousesWindow : Window
    {
        HouseService hs = new HouseService();
        ImageService imgService = new ImageService();

        public HousesWindow()
        {
            InitializeComponent();
            IEnumerable<House> houses = hs.GetAllHouses();
            
            foreach(House house in houses)
            {
                housesLb.Items.Add(house.Name);
            }
        }

        private void CreateLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hcw = new HouseCreateWindow();
            hcw.Show();
            Close();
        }

        private void HousesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameLbl.Content = "Name : ";
            adressLbl.Content = "Adress : ";
            stateLbl.Content = "State : ";
            commentsLbl.Content = "Comments : ";
            actionLbl.Content = housesLb.SelectedItem;
            actionLbl.Visibility = Visibility.Visible;
            nameLbl.Visibility = Visibility.Visible;
            adressLbl.Visibility = Visibility.Visible;
            stateLbl.Visibility = Visibility.Visible;
            commentsLbl.Visibility = Visibility.Visible;
            nameTb.Visibility = Visibility.Hidden;
            adressTb.Visibility = Visibility.Hidden;
            stateTb.Visibility = Visibility.Hidden;
            commentsTb.Visibility = Visibility.Hidden;
            var house = hs.GetHouseByName(housesLb.SelectedItem.ToString());
            nameLbl.Content += house.Name;
            adressLbl.Content += house.Adress;
            stateLbl.Content += house.State.ToString() + " / 10";
            commentsLbl.Content += house.Comments;
            if (house.Photo != null && house.Photo.Count() != 0)
            {
                grid.Background = new ImageBrush(imgService.LoadImage(house.Photo));
            }
            else
            {
                grid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/EasyLifeAppDesktop;component/Files/houses.jpg")));
            }
            grid.Background.Opacity = 0.5;
        }
    }
}
