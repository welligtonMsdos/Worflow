using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string cep, string logadouro,string numero,string bairro,string cidade,string uf)
        {
            CEP = cep;
            Logadouro = logadouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [Display(Name = "CEP", Prompt = "Digite o CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Logadouro é obrigatório")]
        [Display(Name = "Rua/Av", Prompt = "Digite o Logadouro")]
        public string Logadouro { get; set; }

        [Required(ErrorMessage = "Número é obrigatório")]
        [Display(Name = "Número", Prompt = "Digite o Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [Display(Name = "Bairro", Prompt = "Digite o Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        [Display(Name = "Cidade", Prompt = "Digite a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "UF é obrigatória")]
        [Display(Name = "UF", Prompt = "Digite a UF")]
        public string UF { get; set; }
    }
}
