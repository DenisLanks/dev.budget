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
    public class PersonModelTests: BaseModelTest
    {

        public PersonModelTests():base()
        {
           
        }

        [Fact()]
        public void CreatePersonTest()
        {
            var model = new PersonModel(context);
            var person = model.CreatePerson("FULANO", "DE TAL", "12345678909");
            Assert.NotNull(person);
            Assert.True(person.Id != 0, "Falha ao cadastrar pessoa.");
        }

        [Fact()]
        public void CannotCreatePersonTest()
        {
            var model = new PersonModel(context);
            Assert.Throws<ArgumentException>(() =>
            {
                model.CreatePerson("", "de tal", "0000000000");
            });
            Assert.Throws<ArgumentException>(() =>
            {
                model.CreatePerson("fulano", "", "0000000000");
            });

            Assert.Throws<BusinessException>(() =>
            {
                model.CreatePerson("fulano", "de tal", "132321323u");
            });
            Assert.Throws<BusinessException>(() =>
            {
                model.CreatePerson("fulano", "de tal", "000.000.000-00");
            });
        }

    }
}