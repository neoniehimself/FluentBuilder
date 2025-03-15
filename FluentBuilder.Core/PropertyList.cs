using System.Linq.Expressions;

namespace FluentBuilder.Core
{
    public class PropertyList<TEntity> : List<Expression<Func<TEntity, object>>> where TEntity : class
    {
    }
}
