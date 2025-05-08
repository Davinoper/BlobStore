using System.ComponentModel.DataAnnotations.Schema;

namespace BlobStore.Models.ViewModels
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public IFormFile file { get; set; }


        public Produto ConvertViewModelToEntity()
        {
            return new Produto
            {
                Nome = this.Nome,
                Descricao = this.Descricao,
                Preco = this.Preco
            };
        }
    }
}
