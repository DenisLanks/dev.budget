using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.budget.business.Models
{
    public class PersonModel: BaseModel
    {
        PersonRepository personRepository;
        public PersonModel(DbContext dbContext) : base(dbContext)
        {
            personRepository = new PersonRepository(context);
        }

        public Person CreatePerson(string name, string lastname, string cpf, string email, string phone)
        {
            ValidateString(name);
            ValidateString(lastname);
            ValidateString(cpf);
            ValidateString(email);
            ValidateString(phone);
            ValidateCPF(cpf);
            Person person = new Person() { 
                Name = name,
                LastName = lastname,
                CPF = cpf,
                Email = email,
                Phone = phone
            };
            personRepository.Insert(person);
            return person;
        }

        public bool Exists(int id)
        {
           return  personRepository.Find(id) != null;
        }

        private void ValidateCPF(string cpf)
        {

            foreach (var c in cpf)
            {
                if (char.IsWhiteSpace(c) || char.IsLetter(c)
                    || char.IsSymbol(c))
                {
                    throw new BusinessException("CPF inválido.");
                }

            }

            int dv1, dv2;
            dv1 = CalculateDV1(cpf);
            dv2 = CalculateDV2(cpf, dv1);
            ValidateDV(cpf, dv1, dv2);
            
        }

        private void ValidateDV(string cpf, int dv1, int dv2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dv1);
            sb.Append(dv2);

            if (!cpf.Substring(9).Equals(sb.ToString()))
            {
                throw new BusinessException("CPF Inválido");
            }
        }

        private int CalculateDV2(string cpf, int dv1)
        {
            var weight = 0;
            var str = cpf.Substring(0, 9);
            List<int> sums = new List<int>();
            foreach (var c in str)
            {
                var digit = (int)Char.GetNumericValue(c);
                sums.Add(digit * weight);
                weight++;
            }

            var sum = sums.Sum() + dv1;
            var result = sum % 11;
            return result < 10 ? result : 0;
        }

        private int CalculateDV1(string cpf)
        {
            var weight = 1;
            var str = cpf.Substring(0, 9);
            List<int> sums = new List<int>();
            foreach (var c in str)
            {
                
                var digit = (int)Char.GetNumericValue(c);
                sums.Add(digit * weight);
                weight++;
            }

            var sum = sums.Sum();
            var result = sum % 11;
            return result < 10 ? result : 0;
        }
    }
}
