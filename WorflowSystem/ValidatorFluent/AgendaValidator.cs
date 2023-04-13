using FluentValidation;
using Worflow.Models;

namespace Worflow.ValidatorFluent;

public class AgendaValidator: AbstractValidator<Agenda>
{
    public AgendaValidator()
    {
        RuleFor(c => c.Horario)
        .NotEmpty().WithMessage("Horário deve ser preenchido.");

        RuleFor(c => c.Comentario)
       .NotEmpty().WithMessage("Comentário deve ser preenchido.");        
    }
}
