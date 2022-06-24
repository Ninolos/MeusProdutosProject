using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                .WithMessage("O Campo {PropertyName} precisa ser fornecido")
                .Length(2, 200)
                .WithMessage("O Campo {PropertyName} precisa ser entre {MinLength} e {MaxLength}");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {

            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {

            });
        }
    }
}
