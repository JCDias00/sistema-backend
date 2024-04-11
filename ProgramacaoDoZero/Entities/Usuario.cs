

using System;

namespace ProgramacaoDoZero.Entities
{
    public class usuario
    {
        

        public string ID { get; set; }

        public string nome { get; set; }

        public string Sobrenome { get; set; }

        public string email { get; set; }

        public string Telefone { get; set; }

        public string Genero { get; set; }

        public string senha { get; set; }

        public Guid usuarioGuid { get; set; }


    }
}
