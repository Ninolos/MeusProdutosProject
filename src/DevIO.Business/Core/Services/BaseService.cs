﻿using DevIO.Business.Core.Models;
using DevIO.Business.Core.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificator;

        public BaseService(INotificador notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade ) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate( entidade );

            if (validator.IsValid) return true;

            Notificar(validator);

            return validator.IsValid;
        }
    }
}
