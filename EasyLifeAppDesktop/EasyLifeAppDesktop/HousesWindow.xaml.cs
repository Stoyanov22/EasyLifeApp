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
using System.Windows.Shapes;

namespace EasyLifeAppDesktop
{
    /// <summary>
    /// Interaction logic for HousesWindow.xaml
    /// </summary>
    public partial class HousesWindow : Window
    {
        public HousesWindow()
        {
            InitializeComponent();
            IEnumerable<House> houses = GetAllHouses();
            
            foreach(House house in houses)
            {
                housesList.Items.Add(house.Name);
            }
        }

        private IEnumerable<House> GetAllHouses()
        {
            var el = new EasyLifeEntities();
            var houses = el.Houses.ToList();
            return houses;
        }
    }
}
