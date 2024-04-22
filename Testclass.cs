using Xunit;

public class TestClass
{
    [Fact]
    public void TestAdd()
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.Equal(11, Program.Add(5, 6));
    }

    [Fact]
    public void TestSubtract()
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.Equal(5, Program.Subtract(10, 5));
    }

    [Fact]
    public void TestIsEven()
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.True(Program.IsEven(6));
    }

    [Fact]
    public void TestIsOdd()
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.True(Program.IsOdd(5));
    }

    [Theory]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(10)]
    public void MyEvenTheory(int number)
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.True(Program.IsEven(number));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(9)]
    public void MyOddTheory(int number)
    {
        // Arrange - variables, classes, mocks

        // Act

        // Assert
        Assert.True(Program.IsOdd(number));
    }
   
}