using System.Linq.Expressions;

namespace LightTraveller.Helpers.UnitTests;

public class ExpressionExtensionTests
{
    [Fact]
    public void And()
    {
        Expression<Func<int, bool>> _false = i => false;
        Expression<Func<int, bool>> _true = i => true;
        
        Assert.False(_false.And(_false).Compile().Invoke(1));
        Assert.False(_false.And(_true).Compile().Invoke(1));
        Assert.False(_true.And(_false).Compile().Invoke(1));
        Assert.True(_true.And(_true).Compile().Invoke(1));
    }

    [Fact]
    public void Or()
    {
        Expression<Func<int, bool>> _false = i => false;
        Expression<Func<int, bool>> _true = i => true;

        Assert.False(_false.Or(_false).Compile().Invoke(1));
        Assert.True(_false.Or(_true).Compile().Invoke(1));
        Assert.True(_true.Or(_false).Compile().Invoke(1));
        Assert.True(_true.Or(_true).Compile().Invoke(1));
    }
}
