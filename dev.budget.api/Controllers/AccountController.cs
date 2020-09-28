using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.business.Models;
using dev.budget.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dev.budget.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : AppController
    {
        UserModel userModel;
        private PersonModel personModel;

        public AccountController(DevBudgetContext context)
        {
            userModel = new UserModel(context);
            personModel = new PersonModel(context);
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost()]
        public string Post()
        {
            var content = Body;
            var account = JsonConvert.DeserializeObject<AccountTO>(content);
            var person = personModel.CreatePerson(account.Name, account.LastName, account.CPF, account.Email, account.Phone);

            userModel.CreateUser(person.Id, account.User.Username, account.User.Password);
            return "";
        }

        // PUT api/<AccountController>/5
        [HttpPost("login")]
        public string login()
        {
            var content = Body;
            var user = JsonConvert.DeserializeObject<User>(content);
            var deserialize = JsonConvert.DeserializeObject(content);
            try
            {
                user = userModel.GetUser(user.Username, user.Password);
                if (user == null)
                {
                    throw new BusinessException("Login ou senha incorreta.");
                }
                return JsonConvert.SerializeObject(user);
            }
            catch (BusinessException be)
            {
                return be.Message;
            }
            catch (Exception e)
            {
                return "Erro ao verificar usuário";
            }

        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
