using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        private readonly ICountriesRepository _Countriesrepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : base(repository)
        {
            _Countriesrepository = countriesRepository;
        }

        public override async Task<ActionResponse<Country>> GetAsync(int id) => await _Countriesrepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _Countriesrepository.GetAsync();
    }
}
