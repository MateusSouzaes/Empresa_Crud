using CRUD_Empresa.Models;
using CRUD_Empresa.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CRUD_Empresa.Models
{
    [Table("Estado")]
    public class Estado
    {
        [Key] 
        [Column("id_est")]
        public int Id { get; set; }

        [Column("uf_est")]
        public required string Uf { get; set; }

        [Column("nome_est")]
        public required string Nome { get; set; }

        [JsonIgnore]
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
    }
}