using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.API.Models;
public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um erro válido!")]
    [StringLength(150, ErrorMessage = "O e-mail deve ter no maximo 150 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da cidade deve conter no maximo 100 caracteres.")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O estado é obriagatório.")]
    [StringLength(100, ErrorMessage = "O estado deve conter no máximo 100 caracteres.")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(20, ErrorMessage = "O telefone deve conter no máximo 20 caracteres.")]
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }

}
