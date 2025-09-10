using System.Linq.Expressions;

namespace FluentBuilder.Core
{
    public class IncludeOptions<T> where T : class
    {
        public PropertyList<T> PropertyList { get; }

        public IncludeOptions(PropertyList<T> propertyList)
        {
            this.PropertyList = propertyList;
        }

        public IncludeOptions(params Expression<Func<T, object>>[] propertyList)
        {
            this.PropertyList = [];
            this.PropertyList.AddRange(propertyList);
        }
    }
}
