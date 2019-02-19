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
            IEnumerable<House> houses = hs.GetAllHouses();
            //Dictionary<int, string> houses = hs.GetAllHousesBinded();
            Resources["Houses"] = houses;
            InitializeComponent();

        }

        private void CreateLbl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hcw = new HouseCreateWindow();
            hcw.Show();
            Close();
        }

        private void HouseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameLbl.Content = "Name : ";
            adressLbl.Content = "Adress : ";
            stateLbl.Content = "State : ";
            commentsLbl.Content = "Comments : ";
            nameTb.Visibility = Visibility.Hidden;
            adressTb.Visibility = Visibility.Hidden;
            stateTb.Visibility = Visibility.Hidden;
            commentsTb.Visibility = Visibility.Hidden;
            nameLbl.Visibility = Visibility.Visible;
            adressLbl.Visibility = Visibility.Visible;
            stateLbl.Visibility = Visibility.Visible;
            commentsLbl.Visibility = Visibility.Visible;
            nameBtn.Visibility = Visibility.Visible;
            adressBtn.Visibility = Visibility.Visible;
            stateBtn.Visibility = Visibility.Visible;
            commentsBtn.Visibility = Visibility.Visible;
            var house = (houseList.SelectedItem as House);
            nameLbl.Content = "Name: " + house.Name;
            adressLbl.Content = "Adress: " + house.Adress;
            stateLbl.Content = "State: "+ house.State.ToString() + " / 10";
            commentsLbl.Content = "Comments : " + house.Comments;
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            nameTb.Visibility = Visibility.Hidden;
            nameLbl.Visibility = Visibility.Visible;
            nameBtn.Content = "Edit";
            adressTb.Visibility = Visibility.Hidden;
            adressLbl.Visibility = Visibility.Visible;
            adressBtn.Content = "Edit";
            stateTb.Visibility = Visibility.Hidden;
            stateLbl.Visibility = Visibility.Visible;
            stateBtn.Content = "Edit";
            commentsTb.Visibility = Visibility.Hidden;
            commentsLbl.Visibility = Visibility.Visible;
            commentsBtn.Content = "Edit";
        }

        private void CommentsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (commentsBtn.Content.ToString() == "Submit")
            {
                var house = houseList.SelectedItem as House;
                hs.EditHouseComments(house.HouseId, commentsTb.Text);
                commentsTb.Visibility = Visibility.Hidden;
                commentsLbl.Content = "Comments: " + commentsTb.Text;
                commentsLbl.Visibility = Visibility.Visible;
                commentsBtn.Content = "Edit";
            }
            else
            {
                commentsTb.Visibility = Visibility.Visible;
                commentsTb.Focus();
                commentsLbl.Visibility = Visibility.Hidden;
                commentsBtn.Content = "Submit";
            }
        }

        private void AdressBtn_Click(object sender, RoutedEventArgs e)
        {
            if (adressBtn.Content.ToString() == "Submit")
            {
                var house = houseList.SelectedItem as House;
                hs.EditHouseAdress(house.HouseId, adressTb.Text);
                adressTb.Visibility = Visibility.Hidden;
                adressLbl.Content = "Adress: " + adressTb.Text;
                adressLbl.Visibility = Visibility.Visible;
                adressBtn.Content = "Edit";
            }
            else
            {
                adressTb.Visibility = Visibility.Visible;
                adressTb.Focus();
                adressLbl.Visibility = Visibility.Hidden;
                adressBtn.Content = "Submit";
            }
        }

        private void StateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (stateBtn.Content.ToString() == "Submit")
            {
                if(stateTb.Text=="" || decimal.Parse(stateTb.Text)<0 || decimal.Parse(stateTb.Text)>10)
                {
                    MessageBox.Show("Incorrect Data!");
                }
                else
                {
                    var house = houseList.SelectedItem as House;
                    hs.EditHouseState(house.HouseId, decimal.Parse(stateTb.Text));
                    stateTb.Visibility = Visibility.Hidden;
                    stateLbl.Content = "State: " + stateTb.Text;
                    stateLbl.Visibility = Visibility.Visible;
                    stateBtn.Content = "Edit";
                }
            }
            else
            {
                stateTb.Visibility = Visibility.Visible;
                stateTb.Focus();
                stateLbl.Visibility = Visibility.Hidden;
                stateBtn.Content = "Submit";
            }
        }

        private void NameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameBtn.Content.ToString() == "Submit")
            {
                if (nameTb.Text == "")
                {
                    MessageBox.Show("Incorrect Data!");
                }
                else
                {
                    var house = houseList.SelectedItem as House;
                    hs.EditHouseName(house.HouseId, nameTb.Text);
                    nameTb.Visibility = Visibility.Hidden;
                    nameLbl.Content = "Name: " + nameTb.Text;
                    nameLbl.Visibility = Visibility.Visible;
                    nameBtn.Content = "Edit";
                    //houseList.SelectedItem = house;
                    houseList.Items.Refresh();
                }
            }
            else
            {
                nameTb.Visibility = Visibility.Visible;
                nameTb.Focus();
                nameLbl.Visibility = Visibility.Hidden;
                nameBtn.Content = "Submit";
            }
        }
    }
}
