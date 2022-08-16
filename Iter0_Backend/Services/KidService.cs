﻿using AutoMapper;
using Iter0_Backend.Data.Entities;
using Iter0_Backend.Data.Repository;
using Iter0_Backend.Models;

namespace Iter0_Backend.Services
{
    public class KidService : IKidService
    {
        private IAppRepository _repository;
        private IMapper _mapper;
        private IList<KidEntity> _kids;
        public KidService(IAppRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _kids = new List<KidEntity>();
            _kids.Add(new KidEntity { Id = 1, Name = "Checo", LastName = "Perez", CI = "111111", Birthdate = new DateTime(2001, 1, 1) });
            _kids.Add(new KidEntity { Id = 2, Name = "Juan", LastName = "Perez", CI = "2222222", Birthdate = new DateTime(2002, 2, 2) });
            _kids.Add(new KidEntity { Id = 3, Name = "Pedro", LastName = "Perez", CI = "3333333", Birthdate = new DateTime(2003, 3, 3) });
        }
        public async Task<IEnumerable<KidModel>> GetKidsAsync()
        {
            var kidsEntityList = await _repository.GetKidsAsync();
            //var kidsEntityList = _kids;
            return _mapper.Map<IEnumerable<KidModel>>(kidsEntityList);
        }
    }
}
