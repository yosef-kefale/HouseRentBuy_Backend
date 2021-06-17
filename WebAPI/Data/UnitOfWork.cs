﻿using System.Threading.Tasks;
using WebAPI.Data.Repo;
using WebAPI.Interfaces;

namespace WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public iCityRepository CityRepository => 
            new CityRepository(dc);

        public IUserRepository UserRepository => 
            new UserRepository(dc);

        public IPropertyRepository PropertyRepository =>
            new PropertyRepository(dc);

        public IPropertyTypeRepository PropertyTypeRespository =>
            new PropertyTypeRespository(dc);

        public IFurnishingTypeRepository FurnishingTypeRepository =>
            new FurnishingTypeRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}