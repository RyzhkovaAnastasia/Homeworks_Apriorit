using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringUnitTest
{
  [TestClass]
  public class Replace
  {
    [TestMethod]
    [DataRow("String", "Strini", 'g', 'i')]
    [DataRow(" ", "q", ' ', 'q')]
    [DataRow("zzz", "xxx", 'z', 'x')]
    [DataRow(";-)(#", ";-)(%", '#', '%')]
    public void Replace_ReplaceSymbol(string act, string expected, char oldValue, char newValue)
    {
      // Act
      string actual = act.Replace(oldValue, newValue);
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceOnlyUppercaseSymbols()
    {
      // Arrange
      string expected = "ptripngs";
      // Act
      string actual = "StriSngs".Replace('S', 'p');
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceEscapeCharacter()
    {
      // Arrange
      string expected = "qwe!qwe";
      // Act
      string actual = "qwe\tqwe".Replace('\t', '!');
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceNotExistingSymbol()
    {
      // Arrange
      string expected = "String";
      // Act
      string actual = "String".Replace('q', 'w');
      // Assert
      Assert.AreEqual(expected, actual);
    }

      [TestMethod]
    public void Replace_ReplaceSubstring()
    {
      // Arrange
      string expected = "Stred";
      // Act
      string actual = "String".Replace("ing", "ed");
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceNotExistingSubstring()
    {
      // Arrange
      string expected = "String";
      // Act
      string actual = "String".Replace("abc", "cba");
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceSymbolInInterpolationString()
    {
      // Arrange
      int insertion = 123;
      string expected = "!23";
      // Act
      string actual = $"{insertion}".Replace('1', '!');
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceSubstringInInterpolationString()
    {
      // Arrange
      int insertion = 123;
      string expected = "!";
      // Act
      string actual = $"{insertion}".Replace("123", "!");
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceEmptyString_ShouldThrowArgumentException()
    {  
      // Act => Assert
      Assert.ThrowsException<ArgumentException>(() => "".Replace("", "123"));
    }

    [TestMethod]
    public void Replace_ReplaceNullString_ShouldThrowNullReferenceException()
    {
      // Arrange
      string nullVariable = null;
      // Act => Assert
      Assert.ThrowsException<NullReferenceException>(() => nullVariable.Replace("1", "123"));
    }

    [TestMethod]
    public void Replace_ReplaceSpaceCharacter()
    {
      // Arrange
      string expected = "123";
      // Act
      string actual = "   ".Replace("   ", "123");
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_FewReplaces()
    {
      // Arrange
      string expected = "123";
      // Act
      string actual = "123".Replace("1", "4").Replace('2', '5').Replace("45", "12");
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceWholeStringToNull()
    {
      // Arrange
      string expected = string.Empty;
      // Act
      string actual = "string".Replace("string", null);
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Replace_ReplaceSubstringToNull()
    {
      // Arrange
      string expected = "String";
      // Act
      string actual = "Stringstring".Replace("string", null);
      // Assert
      Assert.AreEqual(expected, actual);
    }
  }
}
