using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLifeAppDesktop.Services
{
    public class HouseService
    {
        private EasyLifeEntities el = new EasyLifeEntities();

        public IEnumerable<House> GetAllHouses()
        {
            var houses = el.Houses.ToList();
            return houses;
        }

        public void CreateHouse(string name, string adress, byte[] photo, decimal state, string comments)
        {
            var house = new House(name, adress, photo, state, comments);
            el.Houses.Add(house);
            el.SaveChanges();
        }

        public House GetHouse(int id)
        {
            var house = el.Houses.SingleOrDefault(h => h.HouseId == id);
            return house;
        }

        public House GetHouseByName(string name)
        {
            var house = el.Houses.SingleOrDefault(h => h.Name == name);
            return house;
        }

        public void EditHouseName(string oldName, string newName)
        {
            var house = GetHouseByName(oldName);
            house.Name = newName;
            el.SaveChanges();
        }
    }
}
