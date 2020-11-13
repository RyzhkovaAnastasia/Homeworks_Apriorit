using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringUnitTest
{
  [TestClass]
  public class Substring
  {
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
    [DataRow(-1, 3)]
    [DataRow(5, 3)]
    [DataRow(0, -1)]
    [DataRow(4, 3)]
    public void Substring_InvalidBounds_ArgumentOutOfRangeException(int startIndex, int length)
    {
      // Act => Assert
      Assert.ThrowsException<ArgumentOutOfRangeException>(() => "string".Substring(startIndex, length));
    }

    [TestMethod]
    public void Substring_LengthIsNull()
    {
      // Arrange 
      int startIndex = 0;
      int length = 0;
      string expected = string.Empty;
      // Act
      string actual = "string".Substring(startIndex, length);
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Substring_GetWholeString()
    {
      // Arrange 
      string @string = "string";
      int startIndex = 0;
      int length = @string.Length;

      string expected = @string;
      // Act
      string actual = @string.Substring(startIndex, length);
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Substring_GetSubstring()
    {
      // Arrange 
      string @string = "string";
      int startIndex = 1;
      int length = 3;

      string expected = "tri";
      // Act
      string actual = @string.Substring(startIndex, length);
      // Assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Substring_SubstringOfNull_ShouldThrowNullReferenceException()
    {
      string @string = null;
      Assert.ThrowsException<NullReferenceException>(() => @string.Substring(1, 2));
    }
  }
}
