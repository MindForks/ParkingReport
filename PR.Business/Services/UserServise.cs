using PR.Entities;
using PR.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PR.Business.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<User> _repository;

        public UserService(IMapper mapper, IRepositoryAsync<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async System.Threading.Tasks.Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async System.Threading.Tasks.Task<User> GetItemAsync(string id)
        {
            return await _repository.GetItemAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            await _repository.UpdateAsync(user);
        }
    }
}
