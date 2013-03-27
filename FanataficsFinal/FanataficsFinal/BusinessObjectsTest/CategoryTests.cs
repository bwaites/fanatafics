using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
namespace BusinessObjectsTest
{
    [TestClass]
    public class CategoryTests
    {
        Category target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Category();
        }

        [TestMethod]
        public void Pass_GetById()
        {
            //Arrange
            Guid categoryId = new Guid("7C0547B8-6475-4D0C-8EB7-F0B842CF35AC");
            String expectedCategory = "Anime";
            
            //Act
            target.GetById(categoryId);
            String actualCategory = target.Type;


            //Assert

            Assert.AreEqual(expectedCategory, actualCategory, "Hurray! It passed!");
            
        }

        [TestMethod]

        public void Pass_Delete()
        {
            // Arrange
            CategoryList expectedCategoryList = new CategoryList();
            expectedCategoryList.GetAll();
            target.IsNew = true;
            target.Type = "TestAction";



            // Act
            target.Save();

            target.Deleted = true;
            target.IsNew = false;
            target.IsDirty = true;
            target.Save();

            CategoryList actualCategoryList = new CategoryList();
            actualCategoryList.GetAll();



            // Assert
            Assert.AreEqual(expectedCategoryList.List.Count, actualCategoryList.List.Count, "It deleted! yay!");


        }
    }
}
