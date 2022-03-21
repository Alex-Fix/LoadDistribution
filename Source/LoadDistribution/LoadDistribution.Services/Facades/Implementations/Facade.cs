using AutoMapper;
using LoadDistribution.Core.Domain.Interfaces;  
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Repositories;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades.Implementations
{
    public abstract class Facade<TEntity, TDTO> : IFacade<TDTO>
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        #region Fields
        private readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        public Facade(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #endregion

        #region Methods
        public async virtual Task<TDTO> Get(int id)
        {
            TEntity entity = await _repository.Get(id);
            return _mapper.Map<TDTO>(entity);
        }

        public async virtual Task<InsertResult> Insert(TDTO entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            InsertResult result = await _repository.Insert(dbEntity);
            return result; 
        }

        public async virtual Task<bool> Update(TDTO entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            bool updated = await _repository.Update(dbEntity);
            return updated;
        }

        public async virtual Task<bool> Delete(int id)
        {
            bool deleted = await _repository.Delete(id);
            return deleted;
        }
        #endregion
    }
}
