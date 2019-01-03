using Microsoft.Extensions.Options;

namespace Ingresso.Data.Repositories
{
    public class BaseRepository
    {
        private readonly IOptions<MongoDbSettings> settings;
        protected readonly DbContext _context = null;

        public BaseRepository(IOptions<MongoDbSettings> settings)
        {
            this.settings = settings;
            _context = new DbContext(settings);
        }
    }
}