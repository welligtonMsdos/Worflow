using FluentValidation;
using System;
using System.Runtime.ConstrainedExecution;
using Worflow.Dados.EFCore;
using Worflow.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Worflow.ValidatorFluent;

public class CotacaoValidator : AbstractValidator<Cotacao>
{
    public CotacaoValidator()
    {
        RuleFor(c => c.Valor).GreaterThan(0);

        RuleFor(c => c.DataEmissao)
        .NotEmpty().WithMessage("Data de emissão deve ser informada.")
        .Must(dataMaiorOuIgual).WithMessage("Data de emissão deve ser maior que data atual.");

        RuleFor(c => c.DataVencimento)
       .NotEmpty().WithMessage("Data de vencimento deve ser informada.")
       .Must(dataMaiorOuIgual).WithMessage("Data de vencimento deve ser maior que data atual.");

        RuleFor(c => c.SeguradoraId).GreaterThan(0).WithMessage("Selecione uma seguradora");
    }

    private static bool dataMaiorOuIgual(DateTime data)
    {
        return data >= DateTime.Now.Date;
    }

}

