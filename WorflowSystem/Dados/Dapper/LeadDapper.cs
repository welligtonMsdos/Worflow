using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Worflow.Dto;
using Worflow.Models;
using Worflow.Repository;
using X.PagedList;

namespace Worflow.Dados.Dapper
{
    public class LeadDapper : ILeadDao
    {
        private IDbConnection _connection;
        IConfiguration _configuration;
        public LeadDapper(IConfiguration configuration)
        {
            _configuration = configuration;

            _connection = new SqlConnection(_configuration.GetConnectionString("WorkflowDb"));
        }
        public void Alterar(Lead obj)
        {
            throw new System.NotImplementedException();
        }

        public IPagedList<Lead> BuscarLeadsByPageList(int pagina)
        {
            string query = "SELECT * FROM LEAD";

            return _connection.Query<Lead>(query).ToPagedList(pagina, 10);
        }

        public Lead BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Lead> BuscarTodos()
        {
            return _connection.Query<Lead>("SELECT * FROM LEAD").ToList();
        }

        public void Excluir(Lead obj)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(List<Lead> obj)
        {
            throw new System.NotImplementedException();
        }

        public void Incluir(Lead obj)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Lead> Pesquisar(string value)
        {
            throw new System.NotImplementedException();
        }

        public IPagedList<Lead> PesquisarByPageList(string value, int pagina)
        {
            return _connection.Query<Lead>("SELECT * FROM LEAD").ToPagedList(pagina, 10);
        }

        public ICollection<Lead> PesquisarPorId(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}
