using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
namespace BusinessObjectsTest
{
    [TestClass]
    public class ReviewTests
    {
        Review target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Review();
        }
        [TestMethod]
        public void Review_GetByIdPass()
        {
            //Arrange

            Guid reviewId = new Guid("375BD4F7-18D7-44A9-B550-4E38967D2DFF");
            String expectedReviewerName= "YoMama";

            //Act
            target.GetById(reviewId);
            String actualReviewerName = target.GuestName;

            //Assert

            Assert.AreEqual(expectedReviewerName, actualReviewerName, "Hurray! They match!");


        }
    }
}
