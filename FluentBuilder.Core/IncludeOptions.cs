using System.Linq.Expressions;

namespace FluentBuilder.Core
{
    public class IncludeOptions<TEntity> where TEntity : class
    {
        public PropertyList<TEntity> PropertyList { get; }

        public IncludeOptions(PropertyList<TEntity> propertyList)
        {
            this.PropertyList = propertyList;
        }

        public IncludeOptions(params Expression<Func<TEntity, object>>[] propertyList)
        {
            this.PropertyList = [];
            this.PropertyList.AddRange(propertyList);
        }
    }
}
