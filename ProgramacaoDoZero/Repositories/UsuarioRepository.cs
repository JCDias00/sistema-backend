using MySql.Data.MySqlClient;

using ProgramacaoDoZero.Entities;

using System;

namespace ProgramacaoDoZero.Repositories
{

    public class usuarioRepository
    {


        private string _connectionString;
        public usuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserir(usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);

            cnn.Open();

            var cmd = new MySqlCommand();


            cmd.Connection = cnn;

            cmd.CommandText = "insert into usuario(nome, sobrenome, telefone, email, genero, senha, usuarioGuid) value(@nome, @sobrenome, @telefone, @email, @genero, @senha, @usuarioGuid)";
            cmd.Parameters.AddWithValue("nome", usuario.nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.Telefone);
            cmd.Parameters.AddWithValue("email", usuario.email);
            cmd.Parameters.AddWithValue("genero", usuario.Genero);
            cmd.Parameters.AddWithValue("senha", usuario.senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.usuarioGuid);





            var affecteRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affecteRows;


        }


        public usuario ObterusuarioPorEmail(string email)
        {
            usuario usuario = null;
            MySqlConnection cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM programacao_do_zero.usuario WHERE email = @email";
            cmd.Parameters.AddWithValue("email", email);

            cnn.Open();
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new usuario();
                usuario.nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.senha = reader["senha"].ToString();
                usuario.usuarioGuid = new Guid(reader["usuarioGuid"].ToString());
                cnn.Close();

            }
            return usuario;
        }

        public usuario ObterPorGuid(Guid usuarioGuid)
        {
            usuario usuario = null;
            MySqlConnection cnn = new MySqlConnection(_connectionString);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM programacao_do_zero.usuario WHERE usuarioGuid = @usuarioGuid";
            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new usuario();
                usuario.nome = reader["nome"].ToString();
                usuario.Sobrenome = reader["sobrenome"].ToString();
                usuario.Telefone = reader["telefone"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.email = reader["email"].ToString();
                usuario.senha = reader["senha"].ToString();
                var Guid = reader["usuarioGuid"].ToString();
                usuario.usuarioGuid = new Guid(Guid);
                
            }

            cnn.Close();

            return usuario;



        }


       

        
    }
}
