using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace web_basics.business.Domains
{
    public class Dog
    {
        data.Repositories.Dog repository;
        IMapper mapper;

        public Dog(IConfiguration configuration)
        {
            this.repository = new data.Repositories.Dog(configuration);
           
        }

        public IEnumerable<ViewModels.Dog> Get()
        {
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<data.Entities.Dog, ViewModels.Dog>();
            }).CreateMapper();

            var dogs = repository.Get();
            return dogs.Select(dog => mapper.Map<data.Entities.Dog, ViewModels.Dog>(dog));
        }

        public void Post(ViewModels.Dog dog)
        {
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ViewModels.Dog, data.Entities.Dog>();
            }).CreateMapper();
            
            data.Entities.Dog dogEntity = mapper.Map<ViewModels.Dog, data.Entities.Dog>(dog);
            repository.Post(dogEntity);
        }
    }
}
