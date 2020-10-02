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
        private EnterpriseModel enterpriseModel;

        public AccountController(DevBudgetContext context)
        {
            userModel = new UserModel(context);
            personModel = new PersonModel(context);
            enterpriseModel = new EnterpriseModel(context);
        }
        
        // POST api/<AccountController>
        [HttpPost()]
        public string Post()
        {
            var content = Body;
            var account = JsonConvert.DeserializeObject<AccountTO>(content);
            try
            {
                var person = personModel.CreatePerson(account.Name, account.LastName, account.CPF, account.Email, account.Phone);
                enterpriseModel.CreateEnterprise(account.Enterprise.Name, account.Enterprise.Cnpj);
                userModel.CreateUser(person.Id, account.User.Username, account.User.Password);
                return JsonConvert.SerializeObject(new ResponseTO() {
                    Code= 200,
                    Message = "Conta cadastrada com sucesso.",
                    Data = person.Id
                });

            }
            catch (BusinessException be)
            {
                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 500,
                    Message = be.Message
                });
            }
            catch (ArgumentException ae)
            {

                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 500,
                    Message = ae.Message
                });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 500,
                    Message = "Erro desconhecido. Tente novamente mais tarde."
                });
            }
        }

        // PUT api/<AccountController>/5
        [HttpPost("login")]
        public string login()
        {
            var content = Body;
            var user = JsonConvert.DeserializeObject<User>(content);
            try
            {
                user = userModel.GetUser(user.Username, user.Password);
                if (user == null)
                {
                    throw new BusinessException("Login ou senha incorreta.");
                }

                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 200,
                    Message = "OK",
                    Data = JsonConvert.SerializeObject(user)
            });
            }
            catch (BusinessException be)
            {
                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 500,
                    Message = be.Message
                });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new ResponseTO()
                {
                    Code = 500,
                    Message = "Erro ao verificar usuário. Tente novamente mais tarde."
                });
            }

        }

    }
}
