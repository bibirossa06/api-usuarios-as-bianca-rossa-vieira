using APIUsuarios.Application.DTOs;
using APIUsuarios.Application.Interfaces;
using APIUsuarios.Domain.Entities;

namespace APIUsuarios.Application.Services;

public class UsuarioService(IUsuarioRepository repository) : IUsuarioService
{
    private readonly IUsuarioRepository _repository = repository;

    public async Task<UsuarioReadDto> CreateAsync(UsuarioCreateDto dto, CancellationToken ct = default)
    {
        var emailLower = dto.Email.Trim().ToLowerInvariant();

        var exists = await _repository.EmailExistsAsync(emailLower, null, ct);
        if (exists)
            throw new InvalidOperationException("Email já está em uso.");

        var entity = new Usuario
        {
            Nome = dto.Nome.Trim(),
            Email = emailLower,
            Senha = dto.Senha,
            DataNascimento = dto.DataNascimento,
            Telefone = dto.Telefone,
            Ativo = true,
            DataCriacao = DateTime.UtcNow,
            DataAtualizacao = null
        };

        await _repository.AddAsync(entity, ct);
        await _repository.SaveChangesAsync(ct);

        return ToReadDto(entity);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity is null)
            return false;

        if (!entity.Ativo)
            return true;

        entity.Ativo = false;
        entity.DataAtualizacao = DateTime.UtcNow;
        await _repository.UpdateAsync(entity, ct);
        await _repository.SaveChangesAsync(ct);
        return true;
    }

    public async Task<List<UsuarioReadDto>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _repository.GetAllAsync(ct);
        return list.Select(ToReadDto).ToList();
    }

    public async Task<UsuarioReadDto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        return entity is null ? null : ToReadDto(entity);
    }

    public async Task<UsuarioReadDto?> UpdateAsync(int id, UsuarioUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _repository.GetByIdAsync(id, ct);
        if (entity is null)
            return null;

        var emailLower = dto.Email.Trim().ToLowerInvariant();
        var exists = await _repository.EmailExistsAsync(emailLower, excludingId: id, ct);
        if (exists)
            throw new InvalidOperationException("Email já está em uso por outro usuário.");

        entity.Nome = dto.Nome.Trim();
        entity.Email = emailLower;
        entity.Senha = dto.Senha;
        entity.DataNascimento = dto.DataNascimento;
        entity.Telefone = dto.Telefone;
        entity.DataAtualizacao = DateTime.UtcNow;

        await _repository.UpdateAsync(entity, ct);
        await _repository.SaveChangesAsync(ct);

        return ToReadDto(entity);
    }

    private static UsuarioReadDto ToReadDto(Usuario u) => new(
        u.Id,
        u.Nome,
        u.Email,
        u.DataNascimento,
        u.Telefone,
        u.Ativo,
        u.DataCriacao,
        u.DataAtualizacao
    );
}
