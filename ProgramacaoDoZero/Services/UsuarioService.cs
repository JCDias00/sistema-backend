

using ProgramacaoDoZero.Api.Common;

using ProgramacaoDoZero.Entities;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;
using System;

namespace ProgramacaoDoZero.Services
{
    public class usuarioService
    {
        private string _connectionString;


        public usuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        


        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new usuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterusuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario existe

                if (usuario.senha == senha)
                {
                    //senha válida

                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "usuario ou senha inválidos";
                }
            }

            else
            {
                //usuario não existe

                result.sucesso = false;
                result.mensagem = "usuario ou senha inválidos";
            }

            return result;
        }


        public CadastroResult Cadastro(string nome, 
            string sobrenome, 
            string telefone, 
            string email,
            string genero,
            string senha)
        {
            var result = new CadastroResult();


            var usuarioRepository = new usuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterusuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario já existe

                result.sucesso = false;
                result.mensagem = "usuario já existe no sistema";
            }

            else
            {
                //usuario não existe

                usuario = new Entities.usuario();

                usuario.nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.email = email;
                usuario.Genero = genero;
                usuario.senha = senha;
                usuario.usuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if (affectedRows >0)
                {   //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.usuarioGuid;
                }
                else
                {   //erro ao enserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuario. Tente novamente!";
                }
            }

            return result;
        }

        public  EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new usuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterusuarioPorEmail(email);

            if (usuario == null)
            {
                //não existe
                result.sucesso = false;
                result.mensagem = "usuario não existe para este e-mail";
            }

            else
            {
                //usuario existe

                var assunto = "Recuperação de Senha";

                var corpo = "Sua senha é " + usuario.senha;

                var emailSender = new EmailSender();

                emailSender.Enviar(assunto, corpo, usuario.email);
            }

            return result;
        }

        public usuario Obterusuario(Guid usuarioGuid)
        {
            var usuario = new usuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }

       
    }
}
