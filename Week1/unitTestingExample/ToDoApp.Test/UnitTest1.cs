using ToDoApp;

namespace ToDoApp.Test;

public class MathServiceTests
{
    // Arange
    private readonly IMathService _mathService;

    public MathServiceTests()
    {
        _mathService = new MathService();
    }

    [Fact]
    public void Test1()
    {
        // Act
        var result = _mathService.Square(2);

        // Assert
        Assert.Equal(4, result);
    }
}
