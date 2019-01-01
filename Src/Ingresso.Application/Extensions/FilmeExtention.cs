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


        public static Filme MapToModel(this FilmeDTO filme, bool setId = false)
        {
            var f = new Filme
            {
                Nome = filme.Nome,
                FimEmCartaz = filme.FimEmCartaz,
                InicioEmCartaz = filme.FimEmCartaz,
            };

            if (setId)
            {
                f.Id = new ObjectId(filme.Id);
            }

            return f;
        }
    }
}
