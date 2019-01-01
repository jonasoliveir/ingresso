namespace Application.DTO
{
    using System;
    using System.Collections.Generic;

    public class FilmeDTO
    {
        public string Nome { get; set; }

        public DateTime InicioEmCartaz { get; set; }

        public DateTime FimEmCartaz { get; set; }

        public List<SessaoDTO> Sessoes { get; set; }

        public List<SalaDTO> Salas { get; set; }

        public string Id { get; set; }
    }
}
