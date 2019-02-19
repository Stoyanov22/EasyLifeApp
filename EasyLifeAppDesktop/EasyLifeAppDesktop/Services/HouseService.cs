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

        public void EditHouseName(int id, string name)
        {
            var house = GetHouse(id);
            house.Name = name;
            el.SaveChanges();
        }

        public void EditHouseAdress(int id, string adress)
        {
            var house = GetHouse(id);
            house.Adress = adress;
            el.SaveChanges();
        }

        public void EditHouseState(int id, decimal state)
        {
            var house = GetHouse(id);
            house.State = state;
            el.SaveChanges();
        }
               
        public void EditHousePhoto(int id, byte[] photo)
        {
            var house = GetHouse(id);
            house.Photo = photo;
            el.SaveChanges();
        }

        public void EditHouseComments(int id, string comments)
        {
            var house = GetHouse(id);
            house.Comments = comments;
            el.SaveChanges();
        }

        public void DeleteHouseByName(string name)
        {
            var house = el.Houses.SingleOrDefault(h => h.Name == name);
            el.Houses.Remove(house);
            el.SaveChanges();
        }
    }
}
