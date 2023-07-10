using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using JRSystem.Controllers;
//using JRSystem.Models;

//namespace UnitTest01
//{
//    [TestClass]
public class Class1
{
    //        [TestMethod]
    //        public void Login_ValidCredentials_RedirectsToIndex()
    //        {
    //            // Arrange
    //            var mockContext = new Mock<ReferralDBContext>();
    //            var mockSession = new Mock<ISession>();
    //            mockContext.Setup(c => c.AccountSets).Returns(/* your mock account data */);
    //            var controller = new AccountController(mockContext.Object);
    //            controller.ControllerContext.HttpContext = new DefaultHttpContext();
    //            controller.ControllerContext.HttpContext.Session = mockSession.Object;

    //            var model = new Account
    //            {
    //                UserName = "testuser",
    //                Password = "password"
    //            };

    //            // Act
    //            var result = controller.Login(model) as RedirectToActionResult;

    //            // Assert
    //            Assert.IsNotNull(result);
    //            Assert.AreEqual("Index", result.ActionName);
    //            Assert.AreEqual("Referrals", result.ControllerName);
    //            Assert.AreEqual(1, mockSession.Object.GetInt32("_Login"));
    //        }

    //        [TestMethod]
    //        public void Login_InvalidCredentials_RedirectsToFail()
    //        {
    //            // Arrange
    //            var mockContext = new Mock<ReferralDBContext>();
    //            var mockSession = new Mock<ISession>();
    //            mockContext.Setup(c => c.AccountSets).Returns(/* your mock account data */);
    //            var controller = new AccountController(mockContext.Object);
    //            controller.ControllerContext.HttpContext = new DefaultHttpContext();
    //            controller.ControllerContext.HttpContext.Session = mockSession.Object;

    //            var model = new Account
    //            {
    //                UserName = "testuser",
    //                Password = "wrongpassword"
    //            };

    //            // Act
    //            var result = controller.Login(model) as RedirectToActionResult;

    //            // Assert
    //            Assert.IsNotNull(result);
    //            Assert.AreEqual("Fail", result.ActionName);
}
//    }
//}
