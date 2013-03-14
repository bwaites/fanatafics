using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;

namespace BusinessObjectsTest
{
    [TestClass]
    public class GenreListTests
    {
        GenreList target;


        [TestInitialize]
        public void TestInitialize()
        {
            target = new GenreList();
        }
        
        [TestMethod]
        public void Pass_GetAll()
        {
            // Arrange
            GenreList expectedGenreList = new GenreList();
            
            
            // Act
            target.GetAll();
            GenreList actualGenreList = target;

            //Assert
            Assert.AreEqual(expectedGenreList.List.Count, actualGenreList.List.Count, "It matched! Hurray!");
        }
    }
}
