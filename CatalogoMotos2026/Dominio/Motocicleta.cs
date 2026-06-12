using System.ComponentModel.DataAnnotations;

namespace CatalogoMotos2026.Dominio;

public class Motocicleta
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O modelo é obrigatório.")]
    [MaxLength(100)]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A família é obrigatória.")]
    [MaxLength(100)]
    public string Familia { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cilindrada é obrigatória.")]
    [Range(1, 9999, ErrorMessage = "A cilindrada deve estar entre 1 e 9999 cc.")]
    public int Cilindrada { get; set; }

    public int Ano { get; set; } = 2026;
}
