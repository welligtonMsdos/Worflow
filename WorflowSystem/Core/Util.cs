using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Core
{
    public static class Util
    {
        public static List<Opcao> GetOpcoesAprovadaNegada()
        {
            List<Opcao> opcoes = new List<Opcao>();
            
            opcoes.Add(new Opcao(1, "Aprovada"));
            opcoes.Add(new Opcao(2, "Negada"));

            return opcoes;
        }
    }
}
