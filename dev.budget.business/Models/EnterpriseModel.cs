using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class EnterpriseModel: BaseModel
    {
        EnterpriseRepository enterpriseRepository;
        public EnterpriseModel(DbContext dbContext) : base(dbContext)
        {
            enterpriseRepository = new EnterpriseRepository(dbContext);
        }

        public Enterprise CreateEnterprise(string name, string cnpj)
        {
            try
            {
                ValidateString(name);
                ValidateString(cnpj);
                var enterprise = new Enterprise() { 
                    Name = name,
                    CNPJ = cnpj
                };

                enterpriseRepository.Insert(enterprise);
                return enterprise;
            }
            catch (ArgumentException)
            {

                throw new BusinessException("Informe o nome e o CNPJ da empresa.");
            }

        }
    }
}
