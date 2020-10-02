using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev.budget.business.Entities;
using dev.budget.business.Models;
using dev.budget.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dev.budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : AppController
    {
        BudgetModel budgetModel;
        private PersonModel personModel;

        public BudgetController(DevBudgetContext context)
        {
            budgetModel = new BudgetModel(context);
            personModel = new PersonModel(context);
        }
        
        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                List<BudgetTO> budgetTOs = new List<BudgetTO>();
                var budgets = budgetModel.GetBudgets(id);
                foreach (var budget in budgets)
                {
                    var budgetTo = new BudgetTO(budget);
                    budgetTo.Total = budgetModel.Calculate(budget);
                    budgetTOs.Add(budgetTo);
                }
                var response = new ResponseTO()
                {
                    Code = 200,
                    Message = "Ok",
                    Data = budgetTOs
                };
                return JsonConvert.SerializeObject(response);
            }
            catch (Exception)
            {
                var response = new ResponseTO()
                {
                    Code = 500,
                    Message = "Falha ao pequisar orçamentos."
                };
                return JsonConvert.SerializeObject(response);
            }
        }

        // POST api/<BudgetController>
        [HttpPost("{id}")]
        public void Post(int id,[FromBody]BudgetTO budget)
        {

            bool exists = personModel.Exists(id);
            if (exists)
            {
                budgetModel.CreateBudget(id, budget.DevCount, budget.DesCount, budget.SMCount, budget.POCount, budget.Duration);
            }
        }

    }
}
