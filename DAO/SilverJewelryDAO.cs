using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SilverJewelryDAO
    {
        private static SilverJewelryDAO? instance = null;
        private readonly SilverJewelry2024DbContext dbContext;

        public SilverJewelryDAO()
        {
            dbContext = new SilverJewelry2024DbContext();
        }

        public static SilverJewelryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SilverJewelryDAO();
                }
                return instance;
            }
        }



        public IEnumerable<SilverJewelry> GetSilverJewelries()
        {
            return dbContext.SilverJewelries.Include(a => a.Category).ToList();
        }

        public IEnumerable<SilverJewelry> GetSilverJewelriesByName(string name)
        {
            return dbContext.SilverJewelries.Include(a => a.Category).Where(a => a.SilverJewelryName.Contains(name.Trim())).ToList();
        }

        public IEnumerable<SilverJewelry> GetSilverJewelriesByWeight(int weight)
        {
            return dbContext.SilverJewelries.Include(a => a.Category).Where(a => a.MetalWeight == weight).ToList();
        }


        public SilverJewelry GetSilverJewelryById(string id)
        {
            return dbContext.SilverJewelries.Include(a => a.Category).FirstOrDefault(a => a.SilverJewelryId.Equals(id.Trim()));
        }


        public bool AddSilverJewelry(SilverJewelry silverJewelry)
        {
            try
            {
                dbContext.Add(silverJewelry);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
