using Xunit;
using TextManager;
using System.Text.RegularExpressions;

namespace TextManager.Tests;

public class TextManagerTest
{
    TextManager TextManagerGlobal;

    public TextManagerTest()
    {
        TextManagerGlobal = new TextManager("hola hola desde xunit");
    }

    [Theory]
    [InlineData("Hola Mundo", 2)]
    [InlineData("", 0)]
    [InlineData("Saludos a todos desde el curso de xunit", 8)]
    public void CountWords(string text, int expected)
    {
        //Arrange
        var textManager = new TextManager(text);

        //Act
        var result = textManager.CountWords();

        //Assert       
        Assert.Equal(expected, result);

    }

    [Theory]
    [ClassData(typeof(TextManagerClassData))]
    public void CountWords_ClassData(string text, int expected)
    {
        //Arrange
        var textManager = new TextManager(text);

        //Act
        var result = textManager.CountWords();

        //Assert       
        Assert.Equal(expected, result);

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
        var result = TextManagerGlobal.FindWord("mundo", true);

        Assert.Empty(result);
    }
    
    [Fact(Skip="This test is not valid for the current code")]
    public void FindExactWord()
    {
        var result = TextManagerGlobal.FindExactWord("mundo", true);

        Assert.IsType<List<Match>>(result);
    } 

    [Fact]
    public void FindExactWord_Exception()
    {
        Assert.ThrowsAny<Exception>(() => TextManagerGlobal.FindExactWord(null, true));
    } 
}