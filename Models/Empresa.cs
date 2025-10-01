using CRUD_Empresa.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Empresa.Models
{
    [Table("empresa")]
    public class Empresa
    {
        [Key]
        [Column("id_emp")]
        public int Id { get; set; }

        [Column("nome_razao_emp")]
        public required string NomeRazao { get; set; }

        [Column("nome_fantasia_emp")]
        public required string NomeFantasia { get; set; }


        [Column("cnpj_emp")]
        public required string Cnpj { get; set; }

        [Column("insc_emp")]
        public string? InscEstadual { get; set; } 

        [Column("telefone_emp")]
        public required string Telefone { get; set; }

        [Column("email_emp")]
        public required string Email { get; set; }

        [Column("cidade_emp")]
        public required string Cidade { get; set; }

        [Column("cep")]
        public required string Cep { get; set; }

        [Column("data_emp")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;


        [Column("fk_id_est")]
        public required int EstadoId { get; set; }


        [ForeignKey("EstadoId")]
        public Estado? Estado { get; set; }
    }
}