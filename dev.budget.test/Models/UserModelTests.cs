using Xunit;
using dev.budget.business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using dev.budget.business.Exceptions;
using Microsoft.EntityFrameworkCore;
using dev.budget.test.Models;

namespace dev.budget.business.Models.Tests
{
    public class UserModelTests: BaseModelTest
    {
        public  UserModelTests():base()
        {
        }

        [Fact()]
        public void CreateUserTest()
        {
            var model = new UserModel(this.context);
            const string Username = "usuario@teste.com";
            const string Password = "senhaTeste";
            model.CreateUser(1, Username, Password);
            var user = model.GetUser(Username, Password);
            Assert.NotNull(user);
        }

        [Fact()]
        public void CannotUsernameEmptyTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "", "senhaTeste");
            });
        }

        [Fact()]
        public void CannotUsernameNullTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, null, "senhaTeste");
            });
        }

        [Fact()]
        public void CannotUsernameWhiteSpaceTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, " ", "senhaTeste");
            });
        }

        [Fact]
        public void CannotPasswordLessThan8Test()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", "testeSe");
            });
        }

        [Fact]
        public void CannotPasswordWithoutLowerTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", "TESTESENHA");
            });
        }

        [Fact]
        public void CannotPasswordWithoutUpperTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", "testesenha");
            });
        }

        [Fact()]
        public void CannotPasswordEmptyTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", " ");
            });
        }

        [Fact()]
        public void CannotPasswordNullTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", null);
            });
        }

        [Fact()]
        public void CannotPasswordWhiteSpaceTest()
        {
            var model = new UserModel(this.context);
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateUser(1, "teste@teste.com", " ");
            });
        }


        [Fact()]
        public void GetUserTest()
        {
            var model = new UserModel(this.context);
            const string Username = "usuario@teste.com";
            const string Password = "senhaTeste";
            model.CreateUser(1000, Username, Password);
            var user = model.GetUser(Username, Password);
            Assert.NotNull(user);

        }
    }
}