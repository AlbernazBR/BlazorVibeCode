using CatalogoMotos2026.Dados;
using CatalogoMotos2026.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CatalogoMotos2026.Servicos;

public class MotoService : IMotoService
{
    private readonly AppDbContext _contexto;

    public MotoService(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Motocicleta>> ObterTodasAsync()
    {
        return await _contexto.Motocicletas
            .AsNoTracking()
            .OrderBy(m => m.Familia)
            .ThenBy(m => m.Modelo)
            .ToListAsync();
    }

    public async Task<Motocicleta?> ObterPorIdAsync(int id)
    {
        return await _contexto.Motocicletas
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<List<Motocicleta>> ObterPorFamiliaAsync(string familia)
    {
        return await _contexto.Motocicletas
            .AsNoTracking()
            .Where(m => m.Familia == familia)
            .OrderBy(m => m.Modelo)
            .ToListAsync();
    }

    public async Task AdicionarAsync(Motocicleta motocicleta)
    {
        await _contexto.Motocicletas.AddAsync(motocicleta);
        await _contexto.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Motocicleta motocicleta)
    {
        _contexto.Motocicletas.Update(motocicleta);
        await _contexto.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var motocicleta = await _contexto.Motocicletas.FindAsync(id);
        if (motocicleta is not null)
        {
            _contexto.Motocicletas.Remove(motocicleta);
            await _contexto.SaveChangesAsync();
        }
    }
}
