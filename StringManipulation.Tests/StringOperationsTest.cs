using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace StringManipulation.Tests;

public class StringOperationsTest
{
    [Fact (Skip = "Not valid at the moment due to an update, Tiket-001")]
    public void ConcatenateStrings()
    {
        // Arrange
        var stringOperations = new StringOperations();

        // Act
        var result = stringOperations.ConcatenateStrings("Hello", "World");
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("Hello World", result);

    }

    [Theory]
    [InlineData("ama", true)]
    [InlineData("anona", true)]
    [InlineData("perro", false)]
    public void IsPalindrome_True(string palindrome, bool expected)
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.IsPalindrome(palindrome);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void IsPalindrome_False()
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.IsPalindrome("Hello");
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void RemoveWhitespace()
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.RemoveWhitespace("Hello World");
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("HelloWorld", result);
    }
    
    [Fact]
    public void QuantintyInWords()
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.QuantintyInWords("cat", 100);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.StartsWith("one", result);
        Assert.Contains("cat", result);
    }
    
    [Fact]
    public void GetStringLength()
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.GetStringLength("Hello Worlod!");

        // Assert
        Assert.Equal(13, result);
    }
    
    [Fact]
    public void GetStringLength_Exception()
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act

        // Assert
        Assert.ThrowsAny<ArgumentNullException>(() => stringOperations.GetStringLength(null));
    }

    [Theory]
    [InlineData ("V", 5)]
    [InlineData ("X", 10)]
    [InlineData ("III", 3)]
    [InlineData ("I", 1)]
    public void FromRomanToNumber(string romanNumber, int expected)
    {
        // Arrange
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.FromRomanToNumber(romanNumber);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CountOccurrences()
    {
        
        var moqLoger = new Mock<ILogger<StringOperations>>();
        var stringOperations = new StringOperations(moqLoger.Object);
        
        var result = stringOperations.CountOccurrences("Hello World", 'o');
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void CountOccurrences_Exception()
    {
        var stringOperations = new StringOperations();
        var mockFileReader = new Mock<IFileReaderConector>();

        mockFileReader.Setup(x => x.ReadString(It.IsAny<string>())).Returns("Reading File");
        
        var result = stringOperations.ReadFile(mockFileReader.Object, "file.txt");
        
        Assert.Equal("Reading File", result);
    }

    [Theory]
    [InlineData("car", "cars")]
    [InlineData("dog", "dogs")]
    [InlineData("child", "children")]
    public void Pluralize(string palabraAPluralizar, string expected)
    {
        // Arrange 
        var stringOperations = new StringOperations();
        
        // Act
        var result = stringOperations.Pluralize(palabraAPluralizar);
        
        //Assert
        Assert.Equal(expected, result);
    }
}

