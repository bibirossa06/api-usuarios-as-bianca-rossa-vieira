using APIUsuarios.Application.Interfaces;
using APIUsuarios.Domain.Entities;
using APIUsuarios.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace APIUsuarios.Infrastructure.Repositories;

public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
{
    private readonly AppDbContext _context = context;

    // O ID é gerado automaticamente pelo banco de dados, não precisamos definir aqui.
    public async Task<Usuario> AddAsync(Usuario entity, CancellationToken ct = default)
    {
        await _context.Usuarios.AddAsync(entity, ct);
        return entity;
    }

    public async Task<List<Usuario>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Usuarios.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Usuario?> GetByEmailAsync(string emailLower, CancellationToken ct = default)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == emailLower, ct);
    }

    public async Task<Usuario?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await _context.Usuarios.FindAsync([id], ct);
    }

    public async Task<bool> EmailExistsAsync(string emailLower, int? excludingId = null, CancellationToken ct = default)
    {
        return await _context.Usuarios
            .AnyAsync(u => u.Email == emailLower && (!excludingId.HasValue || u.Id != excludingId), ct);
    }

    public async Task RemoveAsync(Usuario entity, CancellationToken ct = default)
    {
        _context.Usuarios.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Usuario entity, CancellationToken ct = default)
    {
        _context.Usuarios.Update(entity);
        await Task.CompletedTask;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _context.SaveChangesAsync(ct);
}
