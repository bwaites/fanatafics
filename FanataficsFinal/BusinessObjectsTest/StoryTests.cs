using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
namespace BusinessObjectsTest
{
    [TestClass]
    public class StoryTests
    {
        Story target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Story();
        }
        [TestMethod]
        public void Story_GetByIdPass()
        {
            //Arrange
            
            Guid storyId = new Guid("0D037E25-E146-4DDE-9912-EA2FFA0ABD8B");
            String expectedStoryTitle = "MiniBatman";
            
            //Act
            
            target.GetById(storyId);
            String actualStoryTitle = target.Title;
            
            //Assert

            Assert.AreEqual(expectedStoryTitle, actualStoryTitle, "Hurray! They match!");
        }

                                                                                                                                                                                                                                                                                                               
      
    }
}
