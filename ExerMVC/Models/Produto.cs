using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ExerMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }
        [DisplayName("Preço da unidade")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }
        [DisplayName("Produtos vendidos")]
        public int Quantidade { get; set; }
        [DisplayName("Preço Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get { return calcularTotal(); } set { } }
        private decimal calcularTotal()
        {
            return Preco * Quantidade;
        }
    }
}
