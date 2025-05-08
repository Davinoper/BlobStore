using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlobStore.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("preco")]
        public decimal Preco { get; set; }
        [Column("url_image")]
        public string ImageUrl { get; set; }
        [Column("data_cadastro")]
        public DateTime? DataCadastro { get; set; }
    }
}
