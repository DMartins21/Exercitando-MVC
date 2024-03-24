using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExerMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Sobrenome")]
        public string LastName { get; set; }
        [DisplayName("Telefone")]
        [MaxLength(100)]
        public string Phone { get; set; }
        [DisplayName("Endereço")]
        public string Adress { get; set; }
    }
}
