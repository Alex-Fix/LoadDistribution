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
        public const int MIN_PAGE_NUMBER = 0;
        public const int DEFAULT_PAGE_SIZE = 10 ;
        public const int MIN_PAGE_SIZE = 1;
        #endregion

        #region Constructors
        private Paged(int pageSize, int pageNumber, int pageCount, int totalCount, IList<TEntity> list)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            PageCount = pageCount;
            TotalCount = totalCount;
            List = list;
        }
        #endregion

        #region Properties
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int PageCount { get; private set; }
        public int TotalCount { get; private set; }
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

            int totalCount = await collection.CountAsync();
            int pageCount = (int)Math.Ceiling((decimal)totalCount / pageSize);
            List<TEntity> list = await collection.Skip((pageNumber - MIN_PAGE_NUMBER) * pageSize).Take(pageSize).ToListAsync();

            return new Paged<TEntity>(pageSize, pageNumber, pageCount, totalCount, list);
        }
        #endregion
    }
}
