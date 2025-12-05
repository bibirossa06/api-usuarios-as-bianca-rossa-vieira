using APIUsuarios.Domain.Entities;

namespace APIUsuarios.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync(CancellationToken ct = default);
    Task<Usuario?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Usuario?> GetByEmailAsync(string emailLower, CancellationToken ct = default);
    Task<bool> EmailExistsAsync(string emailLower, int? excludingId = null, CancellationToken ct = default);
    Task<Usuario> AddAsync(Usuario entity, CancellationToken ct = default);
    Task UpdateAsync(Usuario entity, CancellationToken ct = default);
    Task RemoveAsync(Usuario entity, CancellationToken ct = default);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
