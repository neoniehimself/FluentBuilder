using FluentBuilder.Core;
using Microsoft.EntityFrameworkCore;

namespace FluentBuilder.Persistence
{
    public static class QueryBuilder
    {
        /// <summary>
        /// Builds the EF Core query with the related properties of TEntity
        /// </summary>
        /// <typeparam name="TEntity">The TEntity class</typeparam>
        /// <param name="query">The DbSet of TEntity</param>
        /// <param name="includeOption">The IncludeOption instance that contains the configured properties of TEntity</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<TEntity> Build<TEntity>(IQueryable<TEntity> query, IncludeOption<TEntity>? includeOption = null) where TEntity : class
        {
            if (includeOption?.PropertyList != null || includeOption?.PropertyList.Count > 0)
            {
                foreach (var property in includeOption.PropertyList)
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
