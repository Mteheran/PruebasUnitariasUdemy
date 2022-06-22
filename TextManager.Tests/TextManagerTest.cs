using Xunit;
using TextManager;
namespace TextManager.Tests;

public class TextManagerTest
{
    [Fact]
    public void CountWords()
    {
        //Arrange
        var textManager = new TextManager("Texto Prueba");

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.Equal(2, result);

    }

    [Fact]
    public void CountWords_NotZero()
    {
        //Arrange
        var textManager = new TextManager("Texto");

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.NotEqual(0, result);

    }
    
}