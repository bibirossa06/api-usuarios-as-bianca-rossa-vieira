using APIUsuarios.Application.DTOs;

namespace APIUsuarios.Application.Interfaces;

public interface IUsuarioService
{
    Task<List<UsuarioReadDto>> GetAllAsync(CancellationToken ct = default);
    Task<UsuarioReadDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<UsuarioReadDto> CreateAsync(UsuarioCreateDto dto, CancellationToken ct = default);
    Task<UsuarioReadDto?> UpdateAsync(int id, UsuarioUpdateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
