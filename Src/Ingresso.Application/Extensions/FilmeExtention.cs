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
                Nome = filme.Nome,
                FimEmCartaz = filme.FimEmCartaz,
                InicioEmCartaz = filme.FimEmCartaz,
            };
        }


        public static Filme MapToModel(this FilmeDTO filme)
        {
            var f = new Filme
            {
                Nome = filme.Nome,
                FimEmCartaz = filme.FimEmCartaz,
                InicioEmCartaz = filme.FimEmCartaz,
            };
            return f;
        }

        public static Filme MapToNewValues(this Filme currentValue, FilmeDTO newValue)
        {
            currentValue.Nome = newValue.Nome;
            currentValue.FimEmCartaz = newValue.FimEmCartaz;
            currentValue.InicioEmCartaz = newValue.FimEmCartaz;

            return currentValue;
        }
    }
}
