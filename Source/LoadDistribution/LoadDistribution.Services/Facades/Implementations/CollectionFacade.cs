using AutoMapper;
using LoadDistribution.Core.Domain.Interfaces;
using LoadDistribution.Core.DTO.Interfaces;
using LoadDistribution.Core.Helpers;
using LoadDistribution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Facades.Implementations
{
    public class CollectionFacade<TEntity, TDTO> : Facade<TEntity, TDTO>, ICollectionFacade<TEntity, TDTO>
        where TEntity : class, IEntity
        where TDTO : class, IDTO
    {
        #region Fields
        private readonly ICollectionRepository<TEntity> _collectionRepository;
        #endregion

        #region Constructors
        public CollectionFacade(ICollectionRepository<TEntity> collectionRepository, IMapper mapper) : base(collectionRepository, mapper)
        {
            _collectionRepository = collectionRepository ?? throw new ArgumentNullException(nameof(collectionRepository));
        }
        #endregion

        #region Methods
        public async virtual Task<IList<TDTO>> GetAll()
        {
            IList<TEntity> entities = await _collectionRepository.GetAll();
            return _mapper.Map<IList<TDTO>>(entities);
        }

        public async virtual Task<Paged<TDTO>> GetPaged(int pageNumber, int pageSize)
        {
            Paged<TEntity> entities = await _collectionRepository.GetPaged(pageNumber, pageSize);
            return _mapper.Map<Paged<TDTO>>(entities);
        }
        #endregion
    }
}
