using APIUsuarios.Application.DTOs;
using FluentValidation;

namespace APIUsuarios.Application.Validators;

public class UsuarioUpdateDtoValidator : AbstractValidator<UsuarioUpdateDto>
{
    public UsuarioUpdateDtoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("Senha é obrigatória")
            .MinimumLength(6).WithMessage("Senha deve ter pelo menos 6 caracteres");

        RuleFor(x => x.DataNascimento)
            .Must(SerMaiorDeIdade)
            .WithMessage("Usuário deve ter 18 anos ou mais");
    }

    private static bool SerMaiorDeIdade(DateTime dataNascimento)
    {
        var hoje = DateTime.UtcNow.Date;
        var idade = hoje.Year - dataNascimento.Year;
        if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;
        return idade >= 18;
    }
}
