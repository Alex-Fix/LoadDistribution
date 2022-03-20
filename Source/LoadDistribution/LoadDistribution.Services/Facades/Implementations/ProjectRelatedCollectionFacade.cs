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
    public abstract class ProjectRelatedCollectionFacade<TEntity, TDTO> : Facade<TEntity, TDTO>, IProjectRelatedCollectionFacade<TDTO>
        where TEntity : class, IProjectRelatedEntity
        where TDTO : class, IProjectRelatedDTO
    {
        #region Fields
        private readonly IProjectRelatedCollectionRepository<TEntity> _projectRelatedCollectionRepository;
        #endregion

        #region Constructors
        public ProjectRelatedCollectionFacade(IProjectRelatedCollectionRepository<TEntity> projectRelatedCollectionRepository, IMapper mapper) : base(projectRelatedCollectionRepository, mapper)
        {
            _projectRelatedCollectionRepository = projectRelatedCollectionRepository ?? throw new ArgumentNullException(nameof(projectRelatedCollectionRepository));
        }
        #endregion

        #region Methods
        public async virtual Task<IList<TDTO>> GetAll(int projectId)
        {
            IList<TEntity> entities = await _projectRelatedCollectionRepository.GetAll(projectId);
            return _mapper.Map<IList<TDTO>>(entities);
        }

        public async virtual Task<Paged<TDTO>> GetPaged(int projectId, int pageNumber, int pageSize)
        {
            Paged<TEntity> entities = await _projectRelatedCollectionRepository.GetPaged(projectId, pageNumber, pageSize);
            return _mapper.Map<Paged<TDTO>>(entities);
        }
        #endregion
    }
}
