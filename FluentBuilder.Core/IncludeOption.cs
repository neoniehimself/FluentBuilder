using System.Linq.Expressions;

namespace FluentBuilder.Core
{
    public class IncludeOption<TEntity> where TEntity : class
    {
        public PropertyList<TEntity> PropertyList { get; }

        public IncludeOption(PropertyList<TEntity> propertyList)
        {
            this.PropertyList = propertyList;
        }

        public IncludeOption(params Expression<Func<TEntity, object>>[] propertyList)
        {
            this.PropertyList = [];
            this.PropertyList.AddRange(propertyList);
        }
    }
}
