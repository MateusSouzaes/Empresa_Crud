namespace CRUD_Empresa.Models
{
    public class Empresa
    {
        public required int Id { get; set; }
        
        public required string NomeFantasia { get; set; }

        public required string Cnpj {  get; set; }

        public string InscEstadual { get; set; }

        public required string Telefone {  get; set; }
        
        public required string Email { get; set; }

        public required string Cidade {  get; set; }

        public required int EstadoUF { get; set; }
        public required string cep { get; set; }
        public  DateTime DataCadastro { get; set; } = DateTime.Now;


    }
}
