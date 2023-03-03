using MainProjectsEntity.Models2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProjectsEntity.Sessions
{
    public class AccountService : IAccountService
    {
        private List<Account> accounts;

        public AccountService()
        {
            accounts = new List<Account>();
            {
                new Account()
                {
                    Email = "ravi@123",
                    Password = "thefinalrun"
                };
            }
        }

        public Account Login(string Email, string Password)
        {
            return accounts.SingleOrDefault(x => x.Email == Email && x.Password == Password);            
        }
    }
}
