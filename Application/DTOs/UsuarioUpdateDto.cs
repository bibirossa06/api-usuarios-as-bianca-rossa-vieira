namespace APIUsuarios.Application.DTOs;

public record UsuarioUpdateDto(
    string Nome,
    string Email,
    string Senha,
    DateTime DataNascimento,
    string? Telefone
);
