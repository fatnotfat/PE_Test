using BusinessObject;
using DAO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SilverJewelryRepository : ISilverJewelryRepository
    {
        public bool AddSilverJewelry(SilverJewelry silverJewelry)
        {
            return SilverJewelryDAO.Instance.AddSilverJewelry(silverJewelry);
        }

        public IEnumerable<SilverJewelry> GetSilverJewelries()
        {
            return SilverJewelryDAO.Instance.GetSilverJewelries();
        }

        public IEnumerable<SilverJewelry> GetSilverJewelriesByName(string name)
        {
            return SilverJewelryDAO.Instance.GetSilverJewelriesByName(name);
        }

        public IEnumerable<SilverJewelry> GetSilverJewelriesByWeight(int weight)
        {
            return SilverJewelryDAO.Instance.GetSilverJewelriesByWeight(weight);
        }

        public SilverJewelry GetSilverJewelryById(string id)
        {
            return SilverJewelryDAO.Instance.GetSilverJewelryById(id);
        }
    }
}
