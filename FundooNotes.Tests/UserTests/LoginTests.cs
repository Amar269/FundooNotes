using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Service;
using DataBaseLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using Moq;


namespace FundooNotes.Tests.UserTests
{
    [TestClass]
    public class LoginTests
    {

        private Mock <IUserDAL> _mockUserDAL;
        private Mock<IEmailService> _mockEmailService;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IRabbitMQProducer> _mockRabbitMQProducer;


        private UserBLL _userBLL; 


        [TestInitialize]

        public void Setup()
        {
            _mockUserDAL = new Mock<IUserDAL>();
            _mockEmailService = new Mock<IEmailService>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockRabbitMQProducer = new Mock<IRabbitMQProducer>();


            _userBLL = new UserBLL(

                _mockUserDAL.Object,
                _mockEmailService.Object,
                _mockConfiguration.Object,
                _mockRabbitMQProducer.Object
                
                );
        }



        [TestMethod]
        public async Task LoginUser_ValidCredentials_ReturnsToken()
        {
            //Arrange

            var loginRequest = new LoginRequest
            {
                Email = "test@gmail.com",
                Password = "Password@2603"
            };

            var user = new User
            {
                UserId = 1,
                FirstName = "Amar",
                LastName = "Kolla",
                Email = "test@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Password@2603")
            };

            _mockUserDAL
                .Setup(x => x.LoginUser(loginRequest.Email))
                .Returns(user);

            _mockConfiguration
                .Setup(x => x["Jwt:Key"])
                .Returns("THisIsMySuperSecretKey2610343");

            _mockConfiguration
                .Setup(x => x["Jwt:Issuer"])
                .Returns("Fundoo");

            _mockConfiguration
                .Setup(x => x["Jwt:Audience"])
                .Returns("FundooUsers");
            _mockConfiguration
                .Setup(x => x["Jwt:DurationInMinutes"])
                .Returns("60");

            // Act

            var result = await _userBLL.LoginUser(loginRequest);

            //Assert

            Assert.IsNotNull(result);

            Assert.IsFalse(string.IsNullOrEmpty(result.Token));

            Assert.AreEqual(
                "Login Successful", 
                result.Message);

        }

    }
}
