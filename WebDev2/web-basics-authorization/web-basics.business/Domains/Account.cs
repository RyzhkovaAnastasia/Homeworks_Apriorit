using AutoMapper;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Linq;

namespace web_basics.business.Domains
{
    public class Account
    {
        IMapper mapper;
        data.Repositories.Account repository;

        public IMapper Mapper { get => mapper; set => mapper = value; }
        public data.Repositories.Account Repository { get => repository; set => repository = value; }

        public Account(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Account(configuration);
        }

        public IEnumerable<ViewModels.Account> Get()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Account, ViewModels.Account>();
            }).CreateMapper();

            var accounts = repository.Get();
            return accounts.Select(account => mapper.Map<data.Entities.Account, ViewModels.Account>(account));
        }

        public void Post(ViewModels.Account account)
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ViewModels.Account, data.Entities.Account>();
            }).CreateMapper();

            var newAccount = mapper.Map<ViewModels.Account, data.Entities.Account>(account);
            repository.Post(newAccount);
        }

        public void Put(ViewModels.Account account)
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ViewModels.Account, data.Entities.Account>();
            }).CreateMapper();

            var editedAccount = mapper.Map<ViewModels.Account, data.Entities.Account>(account);
            repository.Put(editedAccount);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
