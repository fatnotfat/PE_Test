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
    public class CategoryRepsitory : ICategoryRepsitory
    {
        public IEnumerable<Category> GetCategories()
        {
            return CategoryDAO.Instance.GetCategories();
        }
    }
}
