using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace LightTraveller.Helpers;

public static class ExpressionExtensions
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> @this, Expression<Func<T, bool>> other)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(@this.Parameters[0], parameter);
        var left = leftVisitor.Visit(@this.Body);

        var rightVisitor = new ReplaceExpressionVisitor(other.Parameters[0], parameter);
        var right = rightVisitor.Visit(other.Body);

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
    }

    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> @this, Expression<Func<T, bool>> other)
    {
        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ReplaceExpressionVisitor(@this.Parameters[0], parameter);
        var left = leftVisitor.Visit(@this.Body);

        var rightVisitor = new ReplaceExpressionVisitor(other.Parameters[0], parameter);
        var right = rightVisitor.Visit(other.Body);

        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), parameter);
    }

    private class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _oldValue;
        private readonly Expression _newValue;

        public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        [return: NotNullIfNotNull("node")]
        public override Expression? Visit(Expression? node)
        {
            if (node == _oldValue)
                return _newValue;

            return base.Visit(node);
        }
    }
}
