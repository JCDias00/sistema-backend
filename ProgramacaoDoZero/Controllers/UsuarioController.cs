using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Services;
using System;

namespace ProgramacaoDoZero.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public string mensagem { get; private set; }

        public usuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
 
        {
            var result = new LoginResult();
            
            if (result == null ||
                string.IsNullOrWhiteSpace(request.email)||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios!";
            }

            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuarioService = new usuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);

            }


            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null || 
                string.IsNullOrWhiteSpace(request.nome)||
                string.IsNullOrWhiteSpace(request.sobrenome)||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero)||
                string.IsNullOrWhiteSpace(request.email)||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios!";
            }

            else
            {
               var connectionString =  _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuarioService = new usuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome,
                    request.sobrenome, 
                    request.telefone, 
                    request.email, 
                    request.genero, 
                    request.senha);
            }

            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result =  new EsqueceuSenhaResult();

            if (request  == null ||
                string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "O campo de email é obrigatório!";

                return result;

                
            }

            else
            {

                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                var usuarioService = new usuarioService(connectionString);

                if (!string.IsNullOrEmpty(mensagem))
                {
                    result.sucesso = false;

                    result.mensagem = "Erro ao enviar o e-mail!";

                }

                else
                {
                    result.sucesso = true;
                }
                result = usuarioService.EsqueceuSenha(request.email);


            }
            return result;



        }

        [HttpGet]
        [Route("obterusuario")]
        public ObterusuarioResult ObterUuario(Guid usuarioGuid)
        {
            var result = new ObterusuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid Vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuario = new usuarioService(connectionString).Obterusuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "usuario não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.nome;
                }
            }

            return result;
        }

        

    }
}
