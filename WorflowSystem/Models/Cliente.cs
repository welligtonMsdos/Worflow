using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Cliente
    {
        public Cliente()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endereco"></param>
        /// <param name="cnpj"></param>
        /// <param name="razaoSocial"></param>
        /// <param name="fantasia"></param>
        /// <param name="agencia"></param>
        /// <param name="conta"></param>
        /// <param name="email"></param>
        /// <param name="telefone"></param>
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
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [Display(Name = "Endereço", Prompt = "Digite o endereço")]
        public int EnderecoId { get; set; }

        public Endereco Endereco { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [Display(Name ="CNPJ", Prompt = "Digite o CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatória")]
        [Display(Name ="Razão Social", Prompt = "Digite a Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Fantasia é obrigatória")]
        [Display(Name = "Fantasia", Prompt = "Digite a Fantasia")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Agência é obrigatória")]
        [Display(Name = "Agência", Prompt = "Digite a agência")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "Conta é obrigatória")]
        [Display(Name = "Conta", Prompt = "Digite a conta")]
        public string Conta { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }      
    }
}
