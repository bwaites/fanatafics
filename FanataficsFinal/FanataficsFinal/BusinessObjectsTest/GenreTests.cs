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
        public void Genre_GetByIdPass()
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

        [TestMethod]
        public void Genre_DeletePass()
        {
            // Arrange
            GenreList expectedGenreList = new GenreList();
            expectedGenreList.GetAll();
            target.IsNew = true;
            target.GenreType = "TestAction";
                    
            // Act
            target.Save();

            target.Deleted = true;
            target.IsNew = false;
            target.IsDirty = true;
            target.Save();
           
            GenreList actualGenreList = new GenreList();
            actualGenreList.GetAll();
                    
             // Assert
            Assert.AreEqual(expectedGenreList.List.Count, actualGenreList.List.Count, "It deleted! yay!");
            

        }

    }
}
