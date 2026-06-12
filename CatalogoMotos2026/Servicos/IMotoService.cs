using CatalogoMotos2026.Dominio;

namespace CatalogoMotos2026.Servicos;

public interface IMotoService
{
    Task<List<Motocicleta>> ObterTodasAsync();
    Task<Motocicleta?> ObterPorIdAsync(int id);
    Task<List<Motocicleta>> ObterPorFamiliaAsync(string familia);
    Task AdicionarAsync(Motocicleta motocicleta);
    Task AtualizarAsync(Motocicleta motocicleta);
    Task RemoverAsync(int id);
}
