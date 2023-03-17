using GameFantasy.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Entities
{
    public sealed class Time : Entity
    {
        public string Name { get; private set; }
        public Time(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "O campo nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
               "Nome invalido, No minimo 3 caracteres");
        }
    }
}
