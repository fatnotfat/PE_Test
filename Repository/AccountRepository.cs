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
    public class AccountRepository : IAccountRepository
    {
        public BranchAccount CheckLogin(string email, string password)
        {
            return AccountDAO.Instance.CheckLogin(email, password); 
        }


    }
}
