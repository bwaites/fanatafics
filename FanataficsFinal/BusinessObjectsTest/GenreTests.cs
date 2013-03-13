using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;

namespace BusinessObjectsTest
{
    [TestClass]
    public class GenreTests
    {
        Genre target;

        
        [TestInitialize]
        public void TestInitialize()
        {
            target = new Genre();
        }


        [TestMethod]
        public void Pass_GetById()
        {
            // Arrange
            Guid genreId = new Guid("24b8a590-e9fd-47a6-852e-144dd8227d23");
            String expectedGenreType = "Adventure";

            
            // Act

            target.GetById(genreId);
            String actualGenreType = target.GenreType;

            // Assert

            Assert.AreEqual(expectedGenreType, actualGenreType, "Genre Types Match!");
        }
    }
}
