using System.ComponentModel;

namespace ExerMVC.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [DisplayName("Número de Telefone")]
        public string Number { get; set; }
        [DisplayName("Endereço")]
        public string Adress { get; set; }

        public string nomeCompleto()
        {
            return $"{Name} {LastName}";
        }
    }
}
