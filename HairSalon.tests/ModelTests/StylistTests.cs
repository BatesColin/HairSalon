using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nick_rogers_test;";
    }
    [TestMethod]
   public void Save_Test()
   {
     //Arrange
     Stylist testStylist = new Stylist("Jain");
     testStylist.Save();
     //Act
     List<Stylist> testList = new List<Stylist>{testStylist};
     List<Stylist> result = Stylist.GetAll();
     //Assert
     Console.WriteLine(testList.Count);
     Console.WriteLine(result.Count);
     CollectionAssert.AreEqual(testList, result);
   }
}
}
