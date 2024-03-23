using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ISilverJewelryRepository
    {
        public IEnumerable<SilverJewelry> GetSilverJewelries();
        public IEnumerable<SilverJewelry> GetSilverJewelriesByName(string name);
        public IEnumerable<SilverJewelry> GetSilverJewelriesByWeight(int weight);
        public SilverJewelry GetSilverJewelryById(string id);
        public bool AddSilverJewelry(SilverJewelry silverJewelry);


    }
}
