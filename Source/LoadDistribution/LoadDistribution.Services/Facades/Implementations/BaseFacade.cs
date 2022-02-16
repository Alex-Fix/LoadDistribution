using AutoMapper;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Core.DTO;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades.Implementations
{
    public abstract class BaseFacade<TEntity, TDTO> : IFacade<TDTO>
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        #region Fields
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public BaseFacade(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Methods
        public async virtual Task<IList<TDTO>> GetAll()
        {
            IList<TEntity> entities = await _repository.GetAll();
            return _mapper.Map<IList<TDTO>>(entities);
        }

        public async virtual Task<TDTO> Get(int id)
        {
            TEntity entity = await _repository.Get(id);
            return _mapper.Map<TDTO>(entity);
        }

        public async virtual Task<Paged<TDTO>> GetPaged(int pageNumber, int pageSize)
        {
            Paged<TEntity> entities = await _repository.GetPaged(pageNumber, pageSize);
            return _mapper.Map<Paged<TDTO>>(entities);
        }

        public async virtual Task<TDTO> Insert(TDTO entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            dbEntity = await _repository.Insert(dbEntity);
            return _mapper.Map<TDTO>(dbEntity);
        }

        public async virtual Task<TDTO> Update(TDTO entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            dbEntity = await _repository.Update(dbEntity);
            return _mapper.Map<TDTO>(dbEntity);
        }

        public async virtual Task<TDTO> Delete(int id)
        {
            TEntity entity = await _repository.Delete(id);
            return _mapper.Map<TDTO>(entity);
        }
        #endregion
    }
}
