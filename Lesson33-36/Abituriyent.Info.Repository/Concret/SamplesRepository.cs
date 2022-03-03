using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class SamplesRepository : ISamplesRepository
    {
        private readonly DbContext _context;

        public SamplesRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<City> GetAllCities()
        {
            return _context.Set<City>();
        }

        public IQueryable<School> GetScools(int cityId)
        {
            return _context.Set<School>().Where(s => s.CityId == cityId);
        }
    }
}