using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dev.budget.business.Entities;
using dev.budget.business.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dev.budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        BudgetModel budgetModel;
        public BudgetController(BudgetModel model)
        {
            budgetModel = model;
        }
        
        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public IEnumerable<Budget> Get(int id)
        {
            return budgetModel.GetBudgets(id);
        }

        // POST api/<BudgetController>
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] string value)
        {
            budgetModel.CreateBudget(id, 0, 0, 0, 0, 0);
        }

    }
}
