using Xunit;
using dev.budget.business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.test.Models;

namespace dev.budget.business.Models.Tests
{
    public class UnitTestBudget: BaseModelTest
    {
        public UnitTestBudget():base()
        {

        }
        [Fact()]
        public void CalculateTest()
        {
            var model = new BudgetModel(context);
            var entity = new Budget()
            {
                DesignerCount = 1,
                DevCount = 1,
                Duration = 1,
                POCount = 1,
                SMCount = 1
            };
            var total = model.Calculate(entity);
            Assert.Equal(5058, total, 2);
            //Assert.True(total == 1150, "Cálculo do orçamento incorreto");
        }

        [Fact()]
        public void CalculateDevTest()
        {
            var model = new BudgetModel(context);
            var total = model.CalculateDev(1);
            Assert.Equal(1150, total, 2);
        }

        [Fact()]
        public void CalculateDurationTest()
        {
            var model = new BudgetModel(context);
            var total = model.CalculateDuration(1);
            Assert.Equal(200, total, 2);
        }

        [Fact()]
        public void CalculatePOTest()
        {
            var model = new BudgetModel(context);
            var total = model.CalculatePO(1);
            Assert.Equal(1650, total, 2);
        }

        [Fact()]
        public void CalculateSMTest()
        {
            var model = new BudgetModel(context);
            var total = model.CalculateSM(1);
            Assert.Equal(1008, total, 2);
        }

        [Fact()]
        public void CalculateDesignerTest()
        {
            var model = new BudgetModel(context);
            var total = model.CalculateDesigner(1);
            Assert.Equal(1050, total, 2);
        }

        [Fact()]
        public void GetBudgetsTest()
        {
            var model = new BudgetModel(context);
            var personModel = new PersonModel(context);
            var person = personModel.CreatePerson("FULANO", "DE TAL", "12345678909");
            model.CreateBudget(person.Id, 1, 1, 1, 1, 1);
            Assert.NotEmpty(model.GetBudgets(person.Id));
        }

        [Fact()]
        public void CannotGetBudgetsTest()
        {
            var model = new BudgetModel(context);
            Assert.Throws<ArgumentException>(()=> {
                model.GetBudgets(0);
            });
        }
    }
}