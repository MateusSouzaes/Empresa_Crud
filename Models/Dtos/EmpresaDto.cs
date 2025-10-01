using System.ComponentModel.DataAnnotations;

namespace CRUD_Empresa.Models.Dtos
{
    public class EmpresaDto
    {   
        [Required(ErrorMessage = "A Razão Social é obrigatória.")]
        [StringLength(200, MinimumLength = 3, 
            ErrorMessage = "A Razão Social deve ter entre 3 e 200 caracteres.")]
        public required string NomeRazao { get; set; }

        [Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        [StringLength(200, MinimumLength = 3, 
            ErrorMessage = "O Nome Fantasia deve ter entre 3 e 200 caracteres.")]
        public required string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^(\d{14}|\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2})$", 
            ErrorMessage = "O formato do CNPJ é inválido. Use 14 dígitos ou o formato XX.XXX.XXX/XXXX-XX.")]
        public required string Cnpj { get; set; }

        [StringLength(20, ErrorMessage = "A Inscrição Estadual deve ter no máximo 20 caracteres.")]
        public string? InscEstadual { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$", 
            ErrorMessage = "O formato do Telefone é inválido. Use (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do E-mail é inválido.")]
        [StringLength(200)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        [StringLength(100, MinimumLength = 3, 
            ErrorMessage = "A Cidade deve ter entre 3 e 100 caracteres.")]
        public required string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado (UF) é obrigatório.")]
        [StringLength(2, MinimumLength = 2, 
            ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
        public required string Uf { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-?\d{3}$", 
            ErrorMessage = "O formato do CEP é inválido. Use XXXXX-XXX.")]
        public required string Cep { get; set; }
    }
}