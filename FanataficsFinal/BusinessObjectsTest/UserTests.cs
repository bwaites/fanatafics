﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessObjects;
namespace BusinessObjectsTest
{
    [TestClass]
    public class UserTests
    {
        User target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new User();
        }

        [TestMethod]
        public void User_GetByIdPass()
        {
            //Arrange

            Guid userId = new Guid("7A89628D-7051-46ED-A52D-21971FE2F6C7");
            String expectedUserName = "Sibaas";

            //Act
            
            target.GetById(userId);
            String actualUserName = target.UserName;
            
            //Assert

            Assert.AreEqual(expectedUserName, actualUserName, "Hurray! They match!");
        }

        [TestMethod]
        public void User_InsertPass()
        {
            //Arrange
            target.IsNew = true;
            target.UserName = "testUserName";
            target.Password = "testPassword";
            target.Email = "testEmail";
            target.SecurityQuestion = "testQuestion";
            target.SecurityAnswer = "testAnswer";
            String expectedUserName = "testUserName";           
            //Act

            target.Save();
            
            Guid targetID = new Guid(target.Id.ToString());
            target.GetById(targetID);
            String actualUserName = target.UserName;

            //Assert

            Assert.AreEqual(expectedUserName, actualUserName, "Hurray!");
            

            
        }



    }
}
