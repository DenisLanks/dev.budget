using Xunit;
using dev.budget.business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using dev.budget.business.Exceptions;

namespace dev.budget.business.Models.Tests
{
    public class EnterpriseModelTests
    {
        [Fact()]
        public void CreateEnterpriseTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void CannotCreateEnterpriseWithoutNameTest()
        {
            var model = new EnterpriseModel();
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise("", "123123213213");
            });

            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise(" ", "123123213213");
            });

            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise(null, "123123213213");
            });
        }

        [Fact()]
        public void CannotCreateEnterpriseWithoutCNPJTest()
        {
            var model = new EnterpriseModel();
            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise("teste", "");
            });

            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise("teste", " ");
            });

            Assert.Throws<BusinessException>(() =>
            {
                model.CreateEnterprise("teste", null);
            });
        }
    }
}