using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class BudgetModel: BaseModel
    {
        PersonRepository personRepository;
        BudgetRepository budgetRepository;
        public BudgetModel(DbContext dbContext) : base(dbContext)
        {
            personRepository = new PersonRepository(dbContext);
            budgetRepository = new BudgetRepository(dbContext);
        }

        public decimal Calculate(Budget budget)
        {
            var result = CalculateDev(budget.DevCount);
            result += CalculateDesigner(budget.DesignerCount);
            result += CalculatePO(budget.POCount);
            result += CalculateSM(budget.SMCount);
            result += CalculateDuration(budget.Duration);
            return result;
        }

        public decimal CalculateDev(decimal count)
        {
            var devPrice = Decimal.Multiply( 1000, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.15);
            return devPrice + add;
        }

        public decimal CalculateDesigner(decimal count)
        {
            var devPrice = Decimal.Multiply(1000, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.05);
            return devPrice + add;
        }

        public decimal CalculateSM(decimal count)
        {
            var devPrice = Decimal.Multiply(900, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.12);
            return devPrice + add;
        }

        public decimal CalculatePO(decimal count)
        {
            var devPrice = Decimal.Multiply(1500, count);
            var add = Decimal.Multiply(devPrice, (decimal)0.1);
            return devPrice + add;
        }

        public decimal CalculateDuration(decimal count)
        {
            return Decimal.Multiply(200,count);
        }

        public IEnumerable<Budget> GetBudgets(int person)
        {
            if (person == 0)
            {
                throw new ArgumentException("Usuário não informado", nameof(person));
            }
            return this.budgetRepository.GetBudgetsByPerson(person);
        }

        public Budget CreateBudget(int person, int devCount, int desCount, int smCount, int poCount, int duration)
        {
            var budget = new Budget() { 
                PersonId = person,
                DevCount = devCount,
                DesignerCount = desCount,
                SMCount = smCount,
                POCount = poCount,
                Duration = duration
            };

            var p = personRepository.Find(person);

            if (p == null) throw new BusinessException("Informe para quem(Pessoa) o orçamento será feito");

            p.Budgets = new List<Budget>();
            p.Budgets.Add(budget);
            personRepository.Update(p);

            return budget;
        }
    }
}
