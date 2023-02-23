using System;

namespace Worflow.Models
{
    public class DatasAgenda
    {
        public DatasAgenda(string datas, string identificadores)
        {
            Datas = datas;
            Identificadores = identificadores;                       
        }

        public string Datas { get; set; }
        public string Identificadores { get; set; }
    }
}
