using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
namespace BusinessObjectsTest
{
    [TestClass]
    public class MaturityTests
    {
        Maturity target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Maturity();
        }

        [TestMethod]
        public void Maturity_GetByIdPass()
        {
            //Arrange
            Guid maturityID = new Guid("288D45F1-C435-4044-A679-DBC473552DC4");
            String expectedMaturityLevel = "PG-13";

            
            //Act

            target.GetById(maturityID);
            string actualMaturityLevel = target.MaturityLevel;

            
            //Assert

            Assert.AreEqual(expectedMaturityLevel, actualMaturityLevel, "Hurray!");

        }

        [TestMethod]
        public void Maturity_DeletePass()
        {
            //Arrange
            MaturityList expectedMaturityList = new MaturityList();
            expectedMaturityList.GetAll();
            target.IsNew = true;
            target.MaturityLevel = "XXX";

            //Act
            target.Save();
            target.Deleted = true;
            target.IsNew = false;
            target.IsDirty = true;
             target.Save();

            MaturityList actualMaturityList = new MaturityList();
            actualMaturityList.GetAll();

            //Assert
            Assert.AreEqual(expectedMaturityList.List.Count(), actualMaturityList.List.Count(), "Hurray!");

        }


    }
}
