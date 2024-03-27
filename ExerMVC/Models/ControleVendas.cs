namespace ExerMVC.Models
{
    public class ControleVendas
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
