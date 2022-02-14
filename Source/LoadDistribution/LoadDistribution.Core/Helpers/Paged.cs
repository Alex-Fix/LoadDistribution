using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadDistribution.Core.Helpers
{
    public class Paged<TEntity>
    {
        #region Constants
        public const int MIN_PAGE_NUMBER = 1;
        public const int DEFAULT_PAGE_SIZE = 20;
        public const int MIN_PAGE_SIZE = 1;
        #endregion

        #region Constructors
        private Paged(int pageSize, int pageNumber, int pageCount, IList<TEntity> list)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = pageCount;
            List = list;
        }
        #endregion

        #region Properties
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int PageCount { get; private set; }
        public IList<TEntity> List { get; private set; }
        #endregion

        #region Methods
        public static async Task<Paged<TEntity>> Build(IQueryable<TEntity> collection, int pageNumber, int pageSize)
        {
            if(collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if(pageNumber < MIN_PAGE_NUMBER)
            {
                pageNumber = MIN_PAGE_NUMBER;
            }
            if(pageSize <= MIN_PAGE_SIZE)
            {
                pageSize = DEFAULT_PAGE_SIZE;
            }

            int entitiesCount = await collection.CountAsync();
            int pageCount = (int)Math.Ceiling((decimal)entitiesCount / pageSize);
            List<TEntity> list = await collection.Skip((pageNumber - MIN_PAGE_NUMBER) * pageSize).Take(pageSize).ToListAsync();

            return new Paged<TEntity>(pageSize, pageNumber, pageCount, list);
        }
        #endregion
    }
}
