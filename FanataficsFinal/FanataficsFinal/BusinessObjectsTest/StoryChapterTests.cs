using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;

namespace BusinessObjectsTest
{
    [TestClass]
    public class StoryChapterTests
    {
        StoryChapter target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new StoryChapter();
        }
        [TestMethod]
        public void Chapter_GetByIdPass()
        {
            //Arrange
            Guid chapterId = new Guid("5F2D49EF-876D-42B6-9191-A5DE0AE16298");
            String expectedChapterName = "MiniBat is found";

            //Act
            target.GetById(chapterId);
            String actualChapterName = target.Title;

            //Assert
            Assert.AreEqual(expectedChapterName, actualChapterName, "Hurray! They match!");
            
        }
    }
}
