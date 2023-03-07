using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Cliente
    {
        public Cliente()
        {

        }
       
        public Cliente(Endereco endereco, string cnpj,string razaoSocial,string fantasia,string agencia,string conta,string email,string telefone)
        {
            Endereco = endereco;
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Agencia = agencia;
            Conta = conta;
            Email = email;
            Telefone = telefone;
        }

        public Cliente(int id, Endereco endereco, string cnpj, string razaoSocial, string fantasia, string agencia, string conta, string email, string telefone): this(endereco,cnpj,razaoSocial,fantasia,agencia,conta,email,telefone)
        {
            this.Id = id;
            this.EnderecoId = endereco.Id;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [Display(Name = "Endereço", Prompt = "Digite o endereço")]
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [Display(Name ="CNPJ", Prompt = "Digite o CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória")]
        [Display(Name ="Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Fantasia é obrigatória")]
        [Display(Name = "Fantasia")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Agência é obrigatória")]
        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "Conta é obrigatória")]
        [Display(Name = "Conta")]
        public string Conta { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }       
        public ICollection<Lead> Lead { get; set; }
    }
}
