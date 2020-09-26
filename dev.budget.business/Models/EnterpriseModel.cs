using dev.budget.business.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class EnterpriseModel: BaseModel
    {
        public void CreateEnterprise(string name, string cnpj)
        {
            try
            {
                ValidateString(name);
                ValidateString(cnpj);
            }
            catch (ArgumentException)
            {

                throw new BusinessException("Informe o nome e o CNPJ da empresa.");
            }

            throw new NotImplementedException();
        }
    }
}
