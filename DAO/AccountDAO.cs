using BusinessObject;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO? instance = null;
        private readonly SilverJewelry2024DbContext dbContext;

        public AccountDAO()
        {
            dbContext = new SilverJewelry2024DbContext();
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }



        public BranchAccount CheckLogin(string email, string password)
        {
            var branchAccount = dbContext.BranchAccounts.FirstOrDefault(b => b.EmailAddress!.Equals(email.Trim()) && b.AccountPassword!.Equals(password.Trim()));
            return branchAccount;
        }
    }
}
