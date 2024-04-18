using Chinook.Models;
using Chinook.Repositories.Interfaces;

namespace Chinook.Repositories
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        protected readonly ChinookContext _dbContext;
        public TrackRepository(ChinookContext dbContext) : base(dbContext)
        {

        }
    }
}
