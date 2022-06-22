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

    [Fact]
    public void FindWord()
    {
        var textManager = new TextManager("hola hola desde xunit");

        var result = textManager.FindWord("hola", true);

        Assert.NotEmpty(result);
        Assert.Contains(0, result);
        Assert.Contains(5, result);
    }

    
    [Fact]
    public void FindWord_Empty()
    {
        var textManager = new TextManager("hola hola desde xunit");

        var result = textManager.FindWord("mundo", true);

        Assert.Empty(result);
    }
    
}