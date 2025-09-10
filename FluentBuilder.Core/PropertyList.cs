using System.Linq.Expressions;

namespace FluentBuilder.Core
{
    public class PropertyList<T> : List<Expression<Func<T, object>>> where T : class
    {
    }
}
