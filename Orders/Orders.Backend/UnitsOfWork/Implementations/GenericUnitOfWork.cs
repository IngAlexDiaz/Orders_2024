﻿using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<ActionResponse<T>> AddAsync(T model) => await _repository.AddAsync(model);

        public async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

        public Task<ActionResponse<IEnumerable<T>>> GetAsync() => _repository.GetAsync();

        public Task<ActionResponse<T>> UpdateAsync(T model) => _repository.UpdateAsync(model);
    }
}
