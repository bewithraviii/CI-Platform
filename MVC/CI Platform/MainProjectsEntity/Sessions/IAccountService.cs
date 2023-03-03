using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProjectsEntity.Models2;



namespace MainProjectsEntity.Sessions
{
    public interface IAccountService
    {
        public Account Login(string Email, string Password);
    }
}
