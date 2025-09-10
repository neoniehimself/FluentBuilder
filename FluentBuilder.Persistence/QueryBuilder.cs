using FluentBuilder.Core;
using Microsoft.EntityFrameworkCore;

namespace FluentBuilder.Persistence
{
    public static class QueryBuilder
    {
        /// <summary>
        /// Builds the EF Core query with the related properties of T
        /// </summary>
        /// <typeparam name="T">The T class</typeparam>
        /// <param name="query">The DbSet of T</param>
        /// <param name="includeOptions">The IncludeOptions instance that contains the configured properties of T</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<T> Build<T>(IQueryable<T> query, IncludeOptions<T>? includeOptions = null) where T : class
        {
            if (includeOptions?.PropertyList != null && includeOptions?.PropertyList.Count > 0)
            {
                foreach (var property in includeOptions.PropertyList)
                {
                    query = query.Include(property);
                }
            }

            return query;
        }
    }
}
