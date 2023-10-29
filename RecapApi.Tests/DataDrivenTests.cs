namespace RecapApi.Tests;

[TestFixture(10)]
[TestFixture(42)]
public class Tests
{
    private int _x;

    public Tests(int x)
    {
        _x = x;
    }

    [Test]
    public void Test1()
    {
        Assert.Pass($"X is {_x}");
    }
}