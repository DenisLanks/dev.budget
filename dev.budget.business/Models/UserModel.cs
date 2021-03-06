﻿using dev.budget.business.Entities;
using dev.budget.business.Exceptions;
using dev.budget.business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class UserModel: BaseModel
    {
        UserRepository userRepository;
        public UserModel(DbContext dbContext) : base(dbContext)
        {
            userRepository = new UserRepository(dbContext);
        }

        public User CreateUser(int person,string username,string password)
        {
            ValidatePerson(person);
            ValidateUsername(username);
            ValidatePassword(password);

            var user = new User()
            {
                PersonId = person,
                Username = username,
                Password = password
            };

            userRepository.Insert(user);

            return user;
        }

        private void ValidateUsername(string username)
        {
            try
            {
                ValidateString(username);
                if (!username.Contains("@"))
                {
                    throw new BusinessException("Usuário inválido. Informe um e-mail válido");
                }
                else
                {
                    var token = username.Split('@');
                    if (!token[1].Contains("."))
                    {
                        throw new BusinessException("Usuário inválido. Informe um e-mail válido");
                    }
                }
            }
            catch (ArgumentException)
            {

                throw new BusinessException("Usuário não informado.");
            }
        }

        private void ValidatePassword(string password)
        {
            try
            {
                ValidateString(password);
                if (password.Length < 8)
                {
                    throw new BusinessException("Senha muito curta");
                }

                var hasUppercase = false;
                var hasLowercase = false;

                foreach (var c in password)
                {
                    if (!hasLowercase) hasLowercase = char.IsLower(c);
                    if (!hasUppercase) hasUppercase = char.IsUpper(c);                    
                }

                if (!hasUppercase) throw new BusinessException("A senha precisa conter pelo menos uma letra maiúscula.");
                if (!hasLowercase) throw new BusinessException("A senha precisa conter pelo menos uma letra minúscula.");
            }
            catch (ArgumentException)
            {

                throw new BusinessException("Informe uma senha");
            }
        }

        

        private static void ValidatePerson(int person)
        {
            if (person == 0) throw new BusinessException("Dados pessoais não encontrado.");
        }

        public User GetUser(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrWhiteSpace(username) ||
                String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Usuário ou Senha não informado.", "username password");
            }

            return userRepository.GetByUsernamePassword(username,password);
        }
    }
}
