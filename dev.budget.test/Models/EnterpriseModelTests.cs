using Xunit;
using dev.budget.business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using dev.budget.business.Exceptions;
using dev.budget.test.Models;

namespace dev.budget.business.Models.Tests
{
    public class EnterpriseModelTests: BaseModelTest
    {
        public  EnterpriseModelTests():base()
        {
        }

        [Fact()]
        public void CreateEnterpriseTest()
        {
            var model = new EnterpriseModel(context);
            var enterprise = model.CreateEnterprise("Fantasia", "123456000132");
            Assert.True(enterprise.Id != 0, "Falha ao inserir uma nova empresa");
        }

        [Fact()]
        public void CannotCreateEnterpriseWithoutNameTest()
        {
            var model = new EnterpriseModel(context);
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
            var model = new EnterpriseModel(context);
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