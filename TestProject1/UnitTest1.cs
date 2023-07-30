//using Microsoft.AspNetCore.Mvc;
//using JRSystem.Controllers;
//using JRSystem.Models;
//using System;
//using Xunit;


//namespace TestProject1
//{
//    public class UnitTest1
//    {
//        Account account;
//        ReferralDBContext _context = new ReferralDBContext();

//        [Fact]
//        public void Test1()
//        {
//            Assert.True(true);

//        }

//        [Fact]
//        public void About()
//        {
//            HomeController controller = new HomeController();

//            ViewResult result = controller.About() as ViewResult;

//            Assert.Equal("Your application description page.", result.ViewData["Message"]);
//        }
//    }
//}