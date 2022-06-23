using Xunit;
using TextManager;
using System.Text.RegularExpressions;

namespace TextManager.Tests;

public class TextManagerTest
{
    [Fact]
    public void CountWords()
    {
        //Arrange
        var textManager = new TextManager("Texto Prueba hola mundo");

        //Act
        var result = textManager.CountWords();

        //Assert
        Assert.True(result > 1);
        Assert.Equal(4, result);

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
    
    [Fact]
    public void FindExactWord()
    {
        var textManager = new TextManager("hola hola desde xunit");

        var result = textManager.FindExactWord("mundo", true);

        Assert.IsType<List<Match>>(result);
    } 

    [Fact]
    public void FindExactWord_Exception()
    {
        var textManager = new TextManager("hola hola desde xunit");

        Assert.ThrowsAny<Exception>(() => textManager.FindExactWord(null, true));
    } 
}