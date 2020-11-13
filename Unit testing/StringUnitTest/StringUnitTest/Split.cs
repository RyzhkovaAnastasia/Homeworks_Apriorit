using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StringUnitTest
{
  [TestClass]
  public class Split
  {
    [TestMethod]
    public void Split_SplitByOneSeparator()
    {
      // Arrange
      string[] expected = { "123", "qwe" };
      // Act
      string[] actual = "123 qwe".Split(new char[] { ' ' });
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitByFewSeparator()
    {
      // Arrange
      string[] expected = { "123", "qwe", "per" };
      // Act
      string[] actual = "123 qwe,per".Split(new char[] { ' ', ',' });
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitStringWithSeparatorsOnly()
    {
      // Arrange
      string[] expected = { "", "", "", "" };
      // Act
      string[] actual = ",,,".Split(new char[] { ',' });
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitStringStartsSeparator()
    {
      // Arrange
      string[] expected = { "", "qwe", "" };
      // Act
      string[] actual = ",qwe,".Split(new char[] { ',' });
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitStringStartsSpace()
    {
      // Arrange
      string[] expected = { " ", "qwe", " " };
      // Act
      string[] actual = " ,qwe, ".Split(new char[] { ',' });
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitStringByStringSeparator()
    {
      // Arrange
      string[] expected = { "123", "456", ""};
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "qwe" }, System.StringSplitOptions.None);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_GetOneStringBySplit()
    {
      // Arrange
      string[] expected = { "123qwe456qwe" };
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "qwe" }, 1, System.StringSplitOptions.None);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_GetTwoStringsBySplit()
    {
      // Arrange
      string[] expected = { "123", "456qwe" };
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "qwe" }, 2, System.StringSplitOptions.None);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_GetMoreThanExistStringsBySplit()
    {
      // Arrange
      string[] expected = { "123", "456", "" };
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "qwe" }, 10, System.StringSplitOptions.None);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_GetNegativeQuantityStringsBySplit_ShouldThrowArgumentOutOfRangeException()
    {
      string @string = "qwerty";
      Assert.ThrowsException<ArgumentOutOfRangeException>(() => @string.Split(new string[] { "qwe" }, -10, StringSplitOptions.None));
    }

    [TestMethod]
    public void Split_SplitByNullSeparator()
    {
      // Arrange
      string[] expected = { "123qwe456qwe" };
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { null }, System.StringSplitOptions.RemoveEmptyEntries);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Split_SplitStringByStringSeparatorIgnoreEmptyEntries()
    {
      // Arrange
      string[] expected = { "123", "456"};
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "qwe" }, System.StringSplitOptions.RemoveEmptyEntries);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Substring_SubstringOfNull_ShouldThrowNullReferenceException()
    {
      string @string = null;
      Assert.ThrowsException<NullReferenceException>(() => @string.Split(new string[] { "qwe" }, System.StringSplitOptions.RemoveEmptyEntries));
    }

    [TestMethod]
    public void Split_SplitStringByNotExistingSeparator()
    {
      // Arrange
      string[] expected = { "123qwe456qwe" };
      // Act
      string[] actual = "123qwe456qwe".Split(new string[] { "asd" }, System.StringSplitOptions.RemoveEmptyEntries);
      // Assert
      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
