
using Microsoft.AspNetCore.Mvc;


namespace ProgramacaoDoZero.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controler : ControllerBase
    {   [Route("olaMundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá Mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]

        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;

            return mensagem;
        }
        [Route("somar")]
        [HttpGet]
        public string Somar(int valor1, int valor2)
        {
            var soma = valor1 + valor2;

            var mensagem = "A soma é " + soma;

            return mensagem;
        }

        [Route("media")]
        [HttpGet]

        public string Media(int valor1, int valor2)
        {
            var media = (valor1 + valor2) / 2;

            var mensagem = "A media é " + media;

            return mensagem;

        }

        [Route("terreno")]
        [HttpGet]

        public string Terreno(decimal valor1, decimal valor2, decimal valor3)
        {
            var largura = valor1;

            var comprimento = valor2;

            var valorM2 = valor3;

            var terreno = largura * comprimento;

            var precoTerreno = terreno * valorM2;

            var mensagem = "O terreno é de " + terreno + " e o valor é de R$ " + precoTerreno;

            return mensagem;
        }

        [Route("troco")]
        [HttpGet]

        public string Troco(decimal precoUnitario, int quantidade, decimal dinheiro)
        {
            var totalaPagar = precoUnitario * quantidade;

            var troco = dinheiro - totalaPagar;

            var mensagem = "O total das compras foi de " + totalaPagar + ". O dinheiro foi "+dinheiro+ ". O troco é de R$  " + troco;

            return mensagem;
        }

        [Route("pagamento")]
        [HttpGet]

        public string Pagamento(string nome, decimal valorHoraTrabalhada, decimal totalHoraTrabalhada)
        {
            var salario = valorHoraTrabalhada * totalHoraTrabalhada;

            var mensagem = "O funcionario " + nome + ", deverá receber R$ " + salario;

            return mensagem;
        }

        [Route("consumo")]
        [HttpGet]

        public string Consumo(decimal distancia, decimal combustivel)
        {
            var consumo = distancia / combustivel;

            var mensagem = "O consumo medio foi de " + consumo;

            return mensagem;
        }
    }

       
           
}
