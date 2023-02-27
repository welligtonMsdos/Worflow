using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using Worflow.Dto;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Dados.Dapper
{
    public class UsuarioDapper : IUsuarioRepository
    {
        IDbConnection _connection;
        IConfiguration _configuration;

        public UsuarioDapper(IConfiguration configuration)
        {
            _configuration = configuration;

            _connection = new SqlConnection(_configuration.GetConnectionString("WorkflowDb"));
        }

        public void Alterar(Usuario obj)
        {
            string query = "UPDATE USUARIO SET NOME = @Nome, ATIVO = @Ativo, PERFILID = @PerfilId WHERE ID = @Id";

            _connection.Execute(query, obj);
        }

        public Usuario BuscarPorId(int id)
        {
            string query = string.Format(" SELECT U.ID,U.NOME,U.RACF,U.ATIVO " +
                                         " FROM Usuario U " +
                                         " WHERE U.ATIVO = 1 " +
                                         " AND ID = {0}", id);

            return _connection.QueryFirst<Usuario>(query);
        }

        public ICollection<Usuario> BuscarTodos()
        {
            string query = " SELECT U.ID,U.NOME,U.RACF,U.ATIVO " +
                           " FROM Usuario U " +
                           " WHERE U.ATIVO = 1 ";

            return _connection.Query<Usuario>(query).ToList();
        }

        public void Excluir(Usuario obj)
        {
            string query = "DELETE FROM USUARIO WHERE ID = @ID";

            _connection.Execute(query, obj);
        }

        public void Incluir(Usuario obj)
        {
            string query = "INSERT INTO USUARIO(NOME,RACF,ATIVO,PERFILID) VALUES (@Nome,@Racf,@Ativo,@PerfilId)";

            _connection.Execute(query, obj);
        }

        public ICollection<Usuario> Pesquisar(string value)
        {
            if (value == null)
                return BuscarTodos();

            string query = string.Format(" SELECT U.ID,U.NOME,U.RACF,U.ATIVO " +
                                          " FROM Usuario U " +
                                          " WHERE U.ATIVO = 1 " +
                                          " AND NOME LIKE '%{0}%' OR " + 
                                          " RACF LIKE '%{0}%'", value);

            return _connection.Query<Usuario>(query).ToList(); ;
        }

        public bool UsuarioExiste(Usuario obj)
        {
            return false;
        }
    }
}
