﻿using FluentValidation;
using Worflow.Models;

namespace Worflow.Dto;

public class CotacaoValidator : AbstractValidator<Cotacao>
{
    public CotacaoValidator()
    {       
        RuleFor(c => c.Valor).GreaterThan(0);      
    }
}