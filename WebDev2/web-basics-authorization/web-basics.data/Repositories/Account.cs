using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using web_basics.data.Entities;

namespace web_basics.data.Repositories
{
    public class Account
    {
        WebBasicsDBContext context;

        public Account(IConfiguration configuration)
        {
            this.context = new WebBasicsDBContext(configuration);
        }

        public IEnumerable<Entities.Account> Get()
        {
            var accounts = context.Accounts.ToList();
            return accounts;
        }

        public void Post(data.Entities.Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void Put(data.Entities.Account account)
        {
            var currentUser = context.Accounts.Where(x => x.Id == account.Id).FirstOrDefault();

            currentUser.Email = account.Email;
            currentUser.Password = account.Password;
            currentUser.Role = account.Role;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            data.Entities.Account account = new data.Entities.Account() { Id = id };
            context.Accounts.Attach(account);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }
    }
}
