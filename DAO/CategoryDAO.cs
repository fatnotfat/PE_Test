using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO? instance = null;
        private readonly SilverJewelry2024DbContext dbContext;

        public CategoryDAO()
        {
            dbContext = new SilverJewelry2024DbContext();
        }

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }



        public IEnumerable<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }
    }
}
