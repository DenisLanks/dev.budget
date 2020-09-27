using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.budget.business.Models
{
    public class PersonModel: BaseModel
    {
        public Person CreatePerson(string name, string lastname, string cpf)
        {
            ValidateString(name);
            ValidateString(lastname);
            ValidateString(cpf);
            ValidateCPF(cpf);
            throw new NotImplementedException();
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
                var digit = Convert.ToInt32(c);
                sums.Add(digit * weight);
                weight++;
            }

            var sum = sums.Sum();
            var result = sum % 11;
            return result < 10 ? result : 0;
        }

        private int CalculateDV1(string cpf)
        {
            var weight = 1;
            var str = cpf.Substring(0, 8);
            List<int> sums = new List<int>();
            foreach (var c in str)
            {
                var digit = Convert.ToInt32(c);
                sums.Add(digit * weight);
                weight++;
            }

            var sum = sums.Sum();
            var result = sum % 11;
            return result < 10 ? result : 0;
        }
    }
}
