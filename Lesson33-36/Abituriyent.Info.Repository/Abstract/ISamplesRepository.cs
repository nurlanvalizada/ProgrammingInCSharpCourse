using System.Linq;
using Abituriyent.Info.Core.Domain;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface ISamplesRepository
    {
        IQueryable<City> GetAllCities();
        IQueryable<School> GetScools(int cityId);
    }
}