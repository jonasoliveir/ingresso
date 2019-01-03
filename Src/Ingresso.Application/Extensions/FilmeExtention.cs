namespace Ingresso.Application.Extensions
{
    using global::Application.DTO;
    using Ingresso.Domain;
    using MongoDB.Bson;

    public static class FilmeExtention
    {
        public static FilmeDTO MapToDto(this Filme filme)
        {
            if (filme == null)
            {
                return null;
            }

            return new FilmeDTO
            {
                Id = filme.Id.ToString(),
                Titulo = filme.Titulo,
                Lancamento = filme.Lancamento,
                QtDiasExibicao = filme.QtDiasExibicao,
                Descricao = filme.Descricao,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
            };
        }


        public static Filme MapToModel(this FilmeDTO filme)
        {
            var f = new Filme
            {
                Titulo = filme.Titulo,
                Lancamento = filme.Lancamento,
                QtDiasExibicao = filme.QtDiasExibicao,
                Descricao = filme.Descricao,
                Genero = filme.Genero,
                Diretor = filme.Diretor,
            };
            return f;
        }

        public static Filme MapToNewValues(this Filme currentValue, FilmeDTO newValue)
        {
            currentValue.Titulo = currentValue.Titulo;
            currentValue.Lancamento = currentValue.Lancamento;
            currentValue.QtDiasExibicao = currentValue.QtDiasExibicao;
            currentValue.Descricao = currentValue.Descricao;
            currentValue.Genero = currentValue.Genero;
            currentValue.Diretor = currentValue.Diretor;

            return currentValue;
        }
    }
}
